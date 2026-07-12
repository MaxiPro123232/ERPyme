using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ERPyME.WinForms.Controladoras;
using ERPyME.WinForms.Ui;

namespace ERPyME.WinForms.Vistas;

/// <summary>Vista de inicio de sesión (RF01). La lógica está en ControladoraLogin.</summary>
public partial class LoginForm : Form
{
    private readonly ControladoraLogin _controladora = new();

    public LoginForm()
    {
        InitializeComponent();

        Estilos.EstilizarBotonPrimario(btnIngresar);
        Estilos.EstilizarCard(cardLogin);
        panelIzquierdo.Paint += PanelIzquierdo_Paint;

        // centrar la tarjeta en el sector derecho
        Load += (s, e) => cardLogin.Location = new Point(
            panelIzquierdo.Width + (ClientSize.Width - panelIzquierdo.Width - cardLogin.Width) / 2,
            (ClientSize.Height - cardLogin.Height) / 2);
    }

    /// <summary>Panel institucional con degradado y texto de presentación.</summary>
    private void PanelIzquierdo_Paint(object? sender, PaintEventArgs e)
    {
        using var brocha = new LinearGradientBrush(panelIzquierdo.ClientRectangle,
            Paleta.Sidebar, Paleta.SidebarActivo, 45f);
        e.Graphics.FillRectangle(brocha, panelIzquierdo.ClientRectangle);

        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        using var fTitulo = new Font("Segoe UI", 22f, FontStyle.Bold);
        using var fSub = new Font("Segoe UI", 10.5f);
        using var fItem = new Font("Segoe UI", 9.75f);
        e.Graphics.DrawString("🏢", new Font("Segoe UI Emoji", 34f), Brushes.White, 40, 110);
        e.Graphics.DrawString("MiEmpresa ERP", fTitulo, Brushes.White, 36, 180);
        e.Graphics.DrawString("Sistema Integral de Gestión Empresarial\npara PyMEs Comerciales",
            fSub, new SolidBrush(Color.FromArgb(184, 196, 212)), 40, 232);

        var items = new[]
        {
            "✓  Ventas, compras y stock integrados",
            "✓  Cuentas corrientes de clientes",
            "✓  Reportes e indicadores del negocio",
            "✓  Auditoría y trazabilidad de operaciones"
        };
        using var brochaItem = new SolidBrush(Color.FromArgb(147, 197, 253));
        for (int i = 0; i < items.Length; i++)
            e.Graphics.DrawString(items[i], fItem, brochaItem, 40, 310 + i * 30);
    }

    private void BtnIngresar_Click(object? sender, EventArgs e)
    {
        lblError.Visible = false;
        var error = _controladora.IniciarSesion(txtUsuario.Text, txtClave.Text);
        if (error is not null)
        {
            lblError.Text = error;
            lblError.Visible = true;
            return;
        }
        DialogResult = DialogResult.OK;
        Close();
    }
}
