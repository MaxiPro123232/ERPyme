using System;
using System.Collections.Generic;
using System.Linq;
using ERPyME.WinForms.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ERPyME.WinForms.Controladoras;

public record VentaDia(string Etiqueta, decimal Monto);

public record VentaReciente(string Numero, string Fecha, string Cliente, string FormaPago, string Total);

/// <summary>Datos que el dashboard necesita para dibujarse.</summary>
public record DatosDashboard(
    decimal VentasMesTotal, int VentasMesCantidad,
    decimal VentasHoyTotal, int VentasHoyCantidad,
    int ClientesActivos,
    List<Producto> ProductosBajoStock,
    List<VentaDia> VentasPorDia,
    List<VentaReciente> UltimasVentas);

/// <summary>Controladora del dashboard e indicadores (RF27).</summary>
public class ControladoraDashboard
{
    public DatosDashboard Obtener()
    {
        using var db = new AppDbContext();
        var hoy = DateTime.Today;
        var inicioMes = new DateTime(hoy.Year, hoy.Month, 1);

        var ventasMes = db.Ventas.Where(v => v.Fecha >= inicioMes).ToList();
        var ventasHoy = ventasMes.Where(v => v.Fecha >= hoy).ToList();

        var bajoStock = db.Productos
            .Where(p => p.Estado && p.StockActual <= p.StockMinimo)
            .OrderBy(p => p.StockActual)
            .ToList();

        var desde = hoy.AddDays(-6);
        var ventasSemana = db.Ventas.Where(v => v.Fecha >= desde).ToList();
        var porDia = new List<VentaDia>();
        for (int i = 0; i < 7; i++)
        {
            var dia = desde.AddDays(i);
            porDia.Add(new VentaDia(dia.ToString("dd/MM"),
                ventasSemana.Where(v => v.Fecha.Date == dia).Sum(v => v.Total)));
        }

        var ultimas = db.Ventas.Include(v => v.Cliente)
            .OrderByDescending(v => v.Fecha).ThenByDescending(v => v.Id)
            .Take(8).ToList()
            .Select(v => new VentaReciente(
                v.Numero,
                v.Fecha.ToString("dd/MM/yyyy"),
                v.Cliente?.Nombre ?? "",
                v.FormaPago,
                $"$ {v.Total:N0}"))
            .ToList();

        return new DatosDashboard(
            ventasMes.Sum(v => v.Total), ventasMes.Count,
            ventasHoy.Sum(v => v.Total), ventasHoy.Count,
            db.Clientes.Count(c => c.Estado),
            bajoStock, porDia, ultimas);
    }
}
