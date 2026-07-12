using System.Collections.Generic;
using System.Linq;
using ERPyME.WinForms.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ERPyME.WinForms.Controladoras;

/// <summary>Controladora de productos y rubros (RF14 / RF15 / RF16 / RF17 / RN05).</summary>
public class ControladoraProductos
{
    /// <summary>RF14 + RF22: listado con búsqueda por código, nombre o rubro.</summary>
    public List<Producto> Listar(string filtro)
    {
        using var db = new AppDbContext();
        var query = db.Productos.Include(p => p.Rubro).AsQueryable();
        if (!string.IsNullOrWhiteSpace(filtro))
        {
            filtro = filtro.Trim();
            query = query.Where(p => p.Codigo.Contains(filtro)
                                  || p.Nombre.Contains(filtro)
                                  || p.Rubro!.Nombre.Contains(filtro));
        }
        return query.OrderBy(p => p.Codigo).ToList();
    }

    public Producto? Obtener(int id)
    {
        using var db = new AppDbContext();
        return db.Productos.FirstOrDefault(p => p.Id == id);
    }

    public List<Rubro> ListarRubros()
    {
        using var db = new AppDbContext();
        return db.Rubros.Where(r => r.Estado).OrderBy(r => r.Nombre).ToList();
    }

    public string GenerarCodigo()
    {
        using var db = new AppDbContext();
        var n = db.Productos.Count() + 1;
        while (db.Productos.Any(p => p.Codigo == $"PROD{n:000}")) n++;
        return $"PROD{n:000}";
    }

    /// <summary>RF15 + RNF14: alta o modificación con validación de reglas de negocio.
    /// Devuelve null si fue exitoso, o el mensaje de error.</summary>
    public string? Guardar(int? id, string codigo, string nombre, int? rubroId,
                           decimal precio, int stock, int stockMinimo, bool estado)
    {
        nombre = nombre.Trim();
        if (nombre.Length == 0) return "El nombre es obligatorio.";
        if (rubroId is null) return "Seleccioná un rubro.";
        if (precio < 0) return "El precio debe ser mayor o igual a cero.";
        if (stock < 0) return "El stock debe ser mayor o igual a cero.";
        if (stockMinimo < 0) return "El stock mínimo debe ser mayor o igual a cero.";

        using var db = new AppDbContext();
        Producto p;
        if (id is null)
        {
            p = new Producto { Codigo = codigo };
            db.Productos.Add(p);
        }
        else
        {
            p = db.Productos.First(x => x.Id == id);
        }

        p.Nombre = nombre;
        p.RubroId = rubroId.Value;
        p.Precio = precio;
        p.StockActual = stock;
        p.StockMinimo = stockMinimo;
        p.Estado = estado;

        Auditor.Registrar(db, id is null ? "Alta de producto" : "Modificación de producto",
                          $"Producto {p.Codigo} - {p.Nombre}");
        db.SaveChanges();
        return null;
    }

    /// <summary>RN05: baja lógica — activa/desactiva sin eliminar físicamente.</summary>
    public void CambiarEstado(int id)
    {
        using var db = new AppDbContext();
        var p = db.Productos.First(x => x.Id == id);
        p.Estado = !p.Estado;
        Auditor.Registrar(db, p.Estado ? "Activación de producto" : "Baja lógica de producto",
                          $"Producto {p.Codigo} - {p.Nombre}");
        db.SaveChanges();
    }
}
