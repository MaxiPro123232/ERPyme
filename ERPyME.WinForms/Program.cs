using ERPyME.WinForms.Modelos;
using ERPyME.WinForms.Vistas;

namespace ERPyME.WinForms;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.SetDefaultFont(new Font("Segoe UI", 9.5f));

        try
        {
            AppDbContext.Inicializar();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No se pudo conectar a la base de datos (localhost\\SQLEXPRESS).\n\n" +
                "Verificá que el servicio de SQL Server Express esté iniciado.\n\nDetalle: " + ex.Message,
                "ERPyME - Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Ciclo login → sistema → (cerrar sesión vuelve al login)
        while (true)
        {
            using var login = new LoginForm();
            if (login.ShowDialog() != DialogResult.OK) break;

            using var main = new MainForm();
            main.ShowDialog();
            if (!main.VolverAlLogin) break;
        }
    }
}
