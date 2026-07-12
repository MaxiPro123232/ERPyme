using System.Linq;
using ERPyME.WinForms.Modelos;

namespace ERPyME.WinForms.Controladoras;

/// <summary>Controladora de autenticación (RF01 / RF03).</summary>
public class ControladoraLogin
{
    /// <summary>Valida credenciales y abre la sesión. Devuelve null si fue exitoso, o el mensaje de error.</summary>
    public string? IniciarSesion(string usuario, string clave)
    {
        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrEmpty(clave))
            return "Ingresá usuario y contraseña.";

        using var db = new AppDbContext();
        var u = db.Usuarios.FirstOrDefault(x => x.NombreUsuario == usuario.Trim() && x.Estado);

        if (u is null || !PasswordHasher.Verificar(clave, u.ClaveHash))
            return "Usuario o contraseña incorrectos.";

        Sesion.UsuarioActual = u;
        Sesion.GrupoActual = db.Grupos
            .Where(g => g.Usuarios.Any(x => x.Id == u.Id))
            .Select(g => g.Nombre)
            .FirstOrDefault() ?? "Sin grupo";

        Auditor.Registrar(db, "Inicio de sesión", $"El usuario '{u.NombreUsuario}' ingresó al sistema");
        db.SaveChanges();
        return null;
    }

    /// <summary>RF03: cierre de sesión seguro con registro de auditoría.</summary>
    public void CerrarSesion()
    {
        using var db = new AppDbContext();
        Auditor.Registrar(db, "Cierre de sesión",
            $"El usuario '{Sesion.UsuarioActual?.NombreUsuario}' cerró la sesión");
        db.SaveChanges();
        Sesion.UsuarioActual = null;
        Sesion.GrupoActual = "";
    }
}
