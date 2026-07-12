using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ERPyME.WinForms.Modelos;

/// <summary>RNF15: las claves se almacenan hasheadas, nunca en texto plano.</summary>
public static class PasswordHasher
{
    public static string Hash(string clave)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes("ERPyME::" + clave));
        return Convert.ToHexString(bytes);
    }

    public static bool Verificar(string clave, string hash)
        => Hash(clave).Equals(hash, StringComparison.OrdinalIgnoreCase);
}

/// <summary>Sesión del usuario autenticado (RF01/RF03).</summary>
public static class Sesion
{
    public static Usuario? UsuarioActual { get; set; }
    public static string GrupoActual { get; set; } = "";
}

/// <summary>RF28 / RNF07: registro de acciones críticas con usuario, fecha y detalle.</summary>
public static class Auditor
{
    public static void Registrar(AppDbContext db, string accion, string detalle,
                                 int? ventaId = null, int? compraId = null)
    {
        db.Auditorias.Add(new Auditoria
        {
            FechaHora = DateTime.Now,
            Accion = accion,
            Detalle = detalle.Length > 255 ? detalle[..255] : detalle,
            UsuarioId = Sesion.UsuarioActual!.Id,
            VentaId = ventaId,
            CompraId = compraId
        });
    }
}
