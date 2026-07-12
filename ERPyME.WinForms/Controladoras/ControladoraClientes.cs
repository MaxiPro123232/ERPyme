using System.Collections.Generic;
using System.Linq;
using ERPyME.WinForms.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ERPyME.WinForms.Controladoras;

/// <summary>Controladora de clientes (RF10 / RF11).</summary>
public class ControladoraClientes
{
    /// <summary>RF10 + RF22: listado (con cuenta corriente) y búsqueda.</summary>
    public List<Cliente> Listar(string filtro)
    {
        using var db = new AppDbContext();
        var query = db.Clientes.Include(c => c.CuentaCorriente).AsQueryable();
        if (!string.IsNullOrWhiteSpace(filtro))
        {
            filtro = filtro.Trim();
            query = query.Where(c => c.Codigo.Contains(filtro)
                                  || c.Nombre.Contains(filtro)
                                  || (c.Cuit ?? "").Contains(filtro)
                                  || (c.Email ?? "").Contains(filtro));
        }
        return query.OrderBy(c => c.Codigo).ToList();
    }

    public Cliente? Obtener(int id)
    {
        using var db = new AppDbContext();
        return db.Clientes.FirstOrDefault(c => c.Id == id);
    }

    public string GenerarCodigo()
    {
        using var db = new AppDbContext();
        var n = db.Clientes.Count() + 1;
        while (db.Clientes.Any(c => c.Codigo == $"CLI{n:000}")) n++;
        return $"CLI{n:000}";
    }

    /// <summary>RF11 + RNF14: alta o modificación. Devuelve null si fue exitoso, o el mensaje de error.</summary>
    public string? Guardar(int? id, string codigo, string nombre, string cuit,
                           string email, string telefono, string direccion, bool estado)
    {
        nombre = nombre.Trim();
        email = email.Trim();
        if (nombre.Length == 0) return "El nombre es obligatorio.";
        if (email.Length > 0 && (!email.Contains('@') || !email.Contains('.')))
            return "El email no tiene un formato válido.";

        using var db = new AppDbContext();
        Cliente c;
        if (id is null)
        {
            c = new Cliente { Codigo = codigo };
            db.Clientes.Add(c);
        }
        else
        {
            c = db.Clientes.First(x => x.Id == id);
        }

        c.Nombre = nombre;
        c.Cuit = cuit.Trim();
        c.Email = email;
        c.Telefono = telefono.Trim();
        c.Direccion = direccion.Trim();
        c.Estado = estado;

        Auditor.Registrar(db, id is null ? "Alta de cliente" : "Modificación de cliente",
                          $"Cliente {c.Codigo} - {c.Nombre}");
        db.SaveChanges();
        return null;
    }

    /// <summary>Baja lógica del cliente.</summary>
    public void CambiarEstado(int id)
    {
        using var db = new AppDbContext();
        var c = db.Clientes.First(x => x.Id == id);
        c.Estado = !c.Estado;
        Auditor.Registrar(db, c.Estado ? "Activación de cliente" : "Baja lógica de cliente",
                          $"Cliente {c.Codigo} - {c.Nombre}");
        db.SaveChanges();
    }
}
