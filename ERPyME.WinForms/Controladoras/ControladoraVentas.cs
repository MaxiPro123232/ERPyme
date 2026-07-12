using System;
using System.Collections.Generic;
using System.Linq;
using ERPyME.WinForms.Modelos;

namespace ERPyME.WinForms.Controladoras;

/// <summary>Ítem de venta que la vista arma antes de confirmar.</summary>
public class ItemVenta
{
    public int ProductoId { get; set; }
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal => Cantidad * PrecioUnitario;
}

/// <summary>Resultado de registrar una venta.</summary>
public record ResultadoVenta(bool Exito, string Mensaje, string Numero = "", decimal SaldoCuentaCorriente = 0);

/// <summary>
/// Controladora del requerimiento core RC01 - Registrar venta.
/// Valida stock (RF21/RN01), descuenta inventario (RN03),
/// impacta cuenta corriente (RN06) y audita (RN08), todo en una transacción.
/// </summary>
public class ControladoraVentas
{
    public List<Cliente> ListarClientesActivos()
    {
        using var db = new AppDbContext();
        return db.Clientes.Where(c => c.Estado).OrderBy(c => c.Codigo).ToList();
    }

    public List<Producto> ListarProductosActivos()
    {
        using var db = new AppDbContext();
        return db.Productos.Where(p => p.Estado).OrderBy(p => p.Codigo).ToList();
    }

    /// <summary>RF21/RN01: valida si se puede agregar la cantidad pedida de un producto.
    /// Devuelve null si hay stock, o el mensaje de error.</summary>
    public string? ValidarStock(Producto producto, int cantidadSolicitada)
    {
        if (cantidadSolicitada <= 0)
            return "La cantidad debe ser mayor a cero.";
        if (cantidadSolicitada > producto.StockActual)
            return $"Stock insuficiente para \"{producto.Nombre}\".\n\n" +
                   $"Solicitado: {cantidadSolicitada} · Disponible: {producto.StockActual}";
        return null;
    }

    private static string GenerarNumero(AppDbContext db)
    {
        var n = db.Ventas.Count() + 1;
        while (db.Ventas.Any(v => v.Numero == $"V-{n:00000}")) n++;
        return $"V-{n:00000}";
    }

    /// <summary>RC01 - flujo principal de registro de venta.</summary>
    public ResultadoVenta Registrar(int clienteId, string formaPago, List<ItemVenta> items)
    {
        if (items.Count == 0)
            return new ResultadoVenta(false, "Agregá al menos un producto a la venta.");

        var total = items.Sum(i => i.Subtotal);

        using var db = new AppDbContext();
        using var tx = db.Database.BeginTransaction();

        // RF21 / RN01: revalidar stock contra la base antes de confirmar
        foreach (var item in items)
        {
            var p = db.Productos.First(x => x.Id == item.ProductoId);
            if (p.StockActual < item.Cantidad)
                return new ResultadoVenta(false,
                    $"Stock insuficiente para \"{p.Nombre}\".\n\n" +
                    $"Solicitado: {item.Cantidad} · Disponible: {p.StockActual}\n\n" +
                    "La venta no puede confirmarse (RN01).");
        }

        var venta = new Venta
        {
            Numero = GenerarNumero(db),
            Fecha = DateTime.Today,
            Total = total,
            Estado = "Confirmada",
            FormaPago = formaPago,
            ImportePagado = formaPago == "Contado" ? total : 0,
            ClienteId = clienteId,
            UsuarioId = Sesion.UsuarioActual!.Id
        };

        foreach (var item in items)
        {
            var p = db.Productos.First(x => x.Id == item.ProductoId);
            venta.Detalles.Add(new DetalleVenta
            {
                ProductoId = p.Id,
                Cantidad = item.Cantidad,
                PrecioUnitario = item.PrecioUnitario,
                Subtotal = item.Subtotal
            });
            p.StockActual -= item.Cantidad; // RN03
        }
        db.Ventas.Add(venta);

        // RN06: la venta a cuenta corriente genera/actualiza el saldo del cliente
        var cliente = db.Clientes.First(c => c.Id == clienteId);
        decimal saldo = 0;
        if (formaPago == "Cuenta Corriente")
        {
            var cc = db.CuentasCorrientes.FirstOrDefault(x => x.ClienteId == clienteId);
            if (cc is null)
            {
                cc = new CuentaCorriente { ClienteId = clienteId };
                db.CuentasCorrientes.Add(cc);
            }
            cc.SaldoAnterior = cc.SaldoActual;
            cc.Debitos += total;
            cc.SaldoActual += total;
            cc.Estado = cc.SaldoActual > 0 ? "Con deuda" : "Al día";
            saldo = cc.SaldoActual;
        }

        db.SaveChanges(); // asigna venta.Id

        // RN08: auditoría de la operación con referencia a la venta
        Auditor.Registrar(db, "Registro de venta",
            $"Venta {venta.Numero} a {cliente.Codigo} - {cliente.Nombre} · {items.Count} ítems · Total $ {total:N0} · {formaPago}",
            ventaId: venta.Id);
        db.SaveChanges();
        tx.Commit();

        var mensaje = $"✔ Venta {venta.Numero} registrada correctamente.\n\nEl stock fue actualizado" +
                      (formaPago == "Cuenta Corriente"
                        ? $" y el saldo de cuenta corriente del cliente es $ {saldo:N0}." : ".");
        return new ResultadoVenta(true, mensaje, venta.Numero, saldo);
    }
}
