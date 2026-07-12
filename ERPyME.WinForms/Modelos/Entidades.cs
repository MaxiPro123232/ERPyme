using System;
using System.Collections.Generic;

namespace ERPyME.WinForms.Modelos;

// Entidades mapeadas 1 a 1 contra el esquema de "Base de datos.sql"

public class Grupo
{
    public int Id { get; set; }
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = true;
    public List<Usuario> Usuarios { get; set; } = new();
    public List<Permiso> Permisos { get; set; } = new();
}

public class Permiso
{
    public int Id { get; set; }
    public string Codigo { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public List<Grupo> Grupos { get; set; } = new();
}

public class Usuario
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Email { get; set; } = "";
    public string ClaveHash { get; set; } = "";
    public bool Estado { get; set; } = true;
    public List<Grupo> Grupos { get; set; } = new();

    public string NombreCompleto => $"{Nombre} {Apellido}".Trim();
}

public class Cliente
{
    public int Id { get; set; }
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string? Cuit { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Direccion { get; set; }
    public bool Estado { get; set; } = true;
    public CuentaCorriente? CuentaCorriente { get; set; }

    public string Descripcion => $"{Codigo} - {Nombre}";
}

public class Proveedor
{
    public int Id { get; set; }
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string? Cuit { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Direccion { get; set; }
    public bool Estado { get; set; } = true;
}

public class Rubro
{
    public int Id { get; set; }
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = true;
    public List<Producto> Productos { get; set; } = new();
}

public class Producto
{
    public int Id { get; set; }
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int StockActual { get; set; }
    public int StockMinimo { get; set; }
    public bool Estado { get; set; } = true;
    public int RubroId { get; set; }
    public Rubro? Rubro { get; set; }

    public bool BajoStock => StockActual <= StockMinimo;
}

public class Compra
{
    public int Id { get; set; }
    public string Numero { get; set; } = "";
    public DateTime Fecha { get; set; } = DateTime.Today;
    public decimal Total { get; set; }
    public int ProveedorId { get; set; }
    public Proveedor? Proveedor { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public List<DetalleCompra> Detalles { get; set; } = new();
}

public class DetalleCompra
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
    public int CompraId { get; set; }
    public Compra? Compra { get; set; }
    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }
}

public class Venta
{
    public int Id { get; set; }
    public string Numero { get; set; } = "";
    public DateTime Fecha { get; set; } = DateTime.Today;
    public decimal Total { get; set; }
    public string Estado { get; set; } = "Confirmada";
    public string FormaPago { get; set; } = "Contado";
    public decimal ImportePagado { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public List<DetalleVenta> Detalles { get; set; } = new();
}

public class DetalleVenta
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
    public int VentaId { get; set; }
    public Venta? Venta { get; set; }
    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }
}

public class CuentaCorriente
{
    public int Id { get; set; }
    public decimal SaldoAnterior { get; set; }
    public decimal Debitos { get; set; }
    public decimal Creditos { get; set; }
    public decimal SaldoActual { get; set; }
    public string Estado { get; set; } = "Al día";
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public List<Pago> Pagos { get; set; } = new();
}

public class Pago
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Today;
    public decimal Importe { get; set; }
    public string FormaPago { get; set; } = "Efectivo";
    public string? Observaciones { get; set; }
    public int CuentaCorrienteId { get; set; }
    public CuentaCorriente? CuentaCorriente { get; set; }
}

public class Auditoria
{
    public int Id { get; set; }
    public DateTime FechaHora { get; set; } = DateTime.Now;
    public string Accion { get; set; } = "";
    public string Detalle { get; set; } = "";
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public int? VentaId { get; set; }
    public int? CompraId { get; set; }
}
