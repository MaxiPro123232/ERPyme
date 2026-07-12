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
        foreach (var b in new[] { btnNavDashboard, btnNavVenta, btnNavProductos, btnNavClientes,
                                  btnNavProveedores, btnNavCompras, btnNavCuentas,
                                  btnNavReportes, btnNavAuditoria, btnNavUsuarios })
            EstilizarBotonNav(b);
        Estilos.EstilizarBotonRojo(btnCerrarSesion);
        panelLogo.Paint += PanelLogo_Paint;

        lblUsuario.Text = Sesion.UsuarioActual?.NombreCompleto ?? "";
        lblGrupo.Text = Sesion.GrupoActual;

        Load += (s, e) => Navegar("dashboard", btnNavDashboard);
    }

    private static void EstilizarBotonNav(Button b)
    {
        b.FlatStyle = FlatStyle.Flat;
        b.TextAlign = ContentAlignment.MiddleLeft;
        b.ForeColor = Color.FromArgb(184, 196, 212);
        b.BackColor = Paleta.Sidebar;
        b.Font = new Font("Segoe UI", 9.75f);
        b.Cursor = Cursors.Hand;
        b.UseVisualStyleBackColor = false;
        b.FlatAppearance.BorderSize = 0;
        b.FlatAppearance.MouseOverBackColor = Paleta.SidebarHover;
        b.FlatAppearance.MouseDownBackColor = Paleta.SidebarActivo;
    }

    private void PanelLogo_Paint(object? sender, PaintEventArgs e)
    {
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        e.Graphics.DrawString("🏢", new Font("Segoe UI Emoji", 15f), Brushes.White, 16, 22);
        using var f1 = new Font("Segoe UI", 12f, FontStyle.Bold);
        using var f2 = new Font("Segoe UI", 7.75f);
        e.Graphics.DrawString("MiEmpresa ERP", f1, Brushes.White, 52, 18);
        e.Graphics.DrawString("Gestión Empresarial", f2, new SolidBrush(Color.FromArgb(124, 141, 166)), 54, 42);
    }

    private void NavBoton_Click(object? sender, EventArgs e)
    {
        if (sender is Button b && b.Tag is string clave)
            Navegar(clave, b);
    }

    private void Navegar(string clave, Button boton)
    {
        if (_navActivo is not null)
        {
            _navActivo.BackColor = Paleta.Sidebar;
            _navActivo.ForeColor = Color.FromArgb(184, 196, 212);
            _navActivo.Font = new Font("Segoe UI", 9.75f);
        }
        _navActivo = boton;
        boton.BackColor = Paleta.SidebarActivo;
        boton.ForeColor = Color.White;
        boton.Font = new Font("Segoe UI Semibold", 9.75f);

        Control vista = clave switch
        {
            "dashboard" => new DashboardView(),
            "venta" => new VentaView(),
            "productos" => new ProductosView(),
            "clientes" => new ClientesView(),
            "auditoria" => new AuditoriaView(),
            "proveedores" => new PlaceholderView("Gestión de Proveedores", "RF12 / RF13"),
            "compras" => new PlaceholderView("Registro de Compras", "RF18 / RF19"),
            "cuentas" => new PlaceholderView("Cuentas Corrientes", "RF23 / RF24"),
            "reportes" => new PlaceholderView("Reportes de Ventas y Stock", "RF25 / RF26"),
            "usuarios" => new PlaceholderView("Gestión de Usuarios y Grupos", "RF06 – RF09"),
            _ => new DashboardView()
        };

        panelContenido.SuspendLayout();
        foreach (Control c in panelContenido.Controls) c.Dispose();
        panelContenido.Controls.Clear();
        vista.Dock = DockStyle.Fill;
        panelContenido.Controls.Add(vista);
        panelContenido.ResumeLayout();
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
