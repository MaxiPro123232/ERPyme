using System.Collections.Generic;
using System.Linq;
using ERPyME.WinForms.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ERPyME.WinForms.Controladoras;

public record RegistroAuditoria(string FechaHora, string Usuario, string Accion, string Detalle);

/// <summary>Controladora de auditoría e historial (RF28 / RNF07).</summary>
public class ControladoraAuditoria
{
    public List<RegistroAuditoria> Listar(int maximo = 300)
    {
        using var db = new AppDbContext();
        return db.Auditorias.Include(a => a.Usuario)
            .OrderByDescending(a => a.FechaHora).ThenByDescending(a => a.Id)
            .Take(maximo).ToList()
            .Select(a => new RegistroAuditoria(
                a.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"),
                a.Usuario?.NombreUsuario ?? "",
                a.Accion,
                a.Detalle))
            .ToList();
    }
}
