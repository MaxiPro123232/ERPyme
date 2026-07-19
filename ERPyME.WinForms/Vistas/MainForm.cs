using System;
using System.Drawing;
using System.Windows.Forms;
using ERPyME.WinForms.Controladoras;
using ERPyME.WinForms.Modelos;
using ERPyME.WinForms.Ui;

namespace ERPyME.WinForms.Vistas;

/// <summary>Vista principal: menú lateral + contenido (RNF12).</summary>
public partial class MainForm : Form
{
    public bool VolverAlLogin { get; private set; }

    private readonly ControladoraLogin _controladoraLogin = new();
    private Button? _navActivo;

    public MainForm()
    {
        InitializeComponent();

        // Estilos que el diseñador no maneja (hover, tipografías del sistema)
        foreach (var b in new[] { btnNavDashboard, btnNavVenta, btnNavProductos, btnNavRubros,
                                  btnNavStock, btnNavClientes, btnNavProveedores, btnNavCompras,
                                  btnNavCuentas, btnNavReportes, btnNavAuditoria, btnNavUsuarios })
            Estilos.EstilizarBotonNav(b);
        Estilos.EstilizarBotonRojo(btnCerrarSesion);
        Animaciones.AparecerVentana(this);
        panelLogo.Paint += PanelLogo_Paint;

        lblUsuario.Text = Sesion.UsuarioActual?.NombreCompleto ?? "";
        lblGrupo.Text = Sesion.GrupoActual;

        Load += (s, e) => Navegar("dashboard", btnNavDashboard);
    }

    private void PanelLogo_Paint(object? sender, PaintEventArgs e)
    {
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        e.Graphics.DrawString("🏢", new Font("Segoe UI Emoji", 15f), Brushes.White, 16, 22);
        using var f1 = new Font("Segoe UI", 12f, FontStyle.Bold);
        using var f2 = new Font("Segoe UI", 7.75f);
        e.Graphics.DrawString("MiEmpresa ERP", f1, Brushes.White, 52, 18);
        e.Graphics.DrawString("Gestión Empresarial", f2, new SolidBrush(Color.FromArgb(152, 162, 179)), 54, 42);
    }

    private void NavBoton_Click(object? sender, EventArgs e)
    {
        if (sender is Button b && b.Tag is string clave)
            Navegar(clave, b);
    }

    private void Navegar(string clave, Button boton)
    {
        Estilos.MarcarNavActivo(_navActivo, boton);
        _navActivo = boton;

        Control vista = clave switch
        {
            "dashboard" => new DashboardView(),
            "venta" => new VentaView(),
            "productos" => new ProductosView(),
            "clientes" => new ClientesView(),
            "auditoria" => new AuditoriaView(),
            "rubros" => new PlaceholderView("Gestión de Rubros", "RF16"),
            "stock" => new PlaceholderView("Consulta de Stock", "RF17"),
            "proveedores" => new PlaceholderView("Gestión de Proveedores", "RF12 / RF13"),
            "compras" => new PlaceholderView("Registro de Compras", "RF18 / RF19"),
            "cuentas" => new PlaceholderView("Cuentas Corrientes", "RF23 / RF24"),
            "reportes" => new PlaceholderView("Reportes de Ventas y Stock", "RF25 / RF26"),
            "usuarios" => new PlaceholderView("Gestión de Usuarios y Grupos", "RF06 – RF09"),
            _ => new DashboardView()
        };

        foreach (Control c in panelContenido.Controls) c.Dispose();
        panelContenido.Controls.Clear();
        Animaciones.EntrarVista(vista, panelContenido); // entrada suave (180 ms, ease-out)
    }

    private void BtnCerrarSesion_Click(object? sender, EventArgs e)
    {
        var r = MessageBox.Show("¿Seguro que querés cerrar la sesión?", "Cerrar Sesión",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (r != DialogResult.Yes) return;

        _controladoraLogin.CerrarSesion();
        VolverAlLogin = true;
        Close();
    }
}
