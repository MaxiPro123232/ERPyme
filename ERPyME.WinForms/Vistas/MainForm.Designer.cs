namespace ERPyME.WinForms.Vistas;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    private void InitializeComponent()
    {
        panelContenido = new System.Windows.Forms.Panel();
        panelSidebar = new System.Windows.Forms.Panel();
        panelNav = new System.Windows.Forms.Panel();
        btnNavUsuarios = new System.Windows.Forms.Button();
        lblSecAdministracion = new System.Windows.Forms.Label();
        btnNavAuditoria = new System.Windows.Forms.Button();
        btnNavReportes = new System.Windows.Forms.Button();
        lblSecAnalisis = new System.Windows.Forms.Label();
        btnNavCuentas = new System.Windows.Forms.Button();
        btnNavCompras = new System.Windows.Forms.Button();
        btnNavProveedores = new System.Windows.Forms.Button();
        btnNavClientes = new System.Windows.Forms.Button();
        btnNavProductos = new System.Windows.Forms.Button();
        lblSecGestion = new System.Windows.Forms.Label();
        btnNavVenta = new System.Windows.Forms.Button();
        btnNavDashboard = new System.Windows.Forms.Button();
        lblSecPrincipal = new System.Windows.Forms.Label();
        panelLogo = new System.Windows.Forms.Panel();
        panelPie = new System.Windows.Forms.Panel();
        btnCerrarSesion = new System.Windows.Forms.Button();
        lblGrupo = new System.Windows.Forms.Label();
        lblUsuario = new System.Windows.Forms.Label();
        panelSidebar.SuspendLayout();
        panelNav.SuspendLayout();
        panelPie.SuspendLayout();
        SuspendLayout();
        //
        // panelContenido
        //
        panelContenido.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
        panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
        panelContenido.Location = new System.Drawing.Point(235, 0);
        panelContenido.Name = "panelContenido";
        panelContenido.Size = new System.Drawing.Size(1029, 721);
        panelContenido.TabIndex = 0;
        //
        // panelSidebar
        //
        panelSidebar.BackColor = System.Drawing.Color.FromArgb(27, 42, 65);
        panelSidebar.Controls.Add(panelNav);
        panelSidebar.Controls.Add(panelPie);
        panelSidebar.Controls.Add(panelLogo);
        panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
        panelSidebar.Location = new System.Drawing.Point(0, 0);
        panelSidebar.Name = "panelSidebar";
        panelSidebar.Size = new System.Drawing.Size(235, 721);
        panelSidebar.TabIndex = 1;
        //
        // panelNav
        //
        panelNav.AutoScroll = true;
        panelNav.BackColor = System.Drawing.Color.FromArgb(27, 42, 65);
        panelNav.Controls.Add(btnNavUsuarios);
        panelNav.Controls.Add(lblSecAdministracion);
        panelNav.Controls.Add(btnNavAuditoria);
        panelNav.Controls.Add(btnNavReportes);
        panelNav.Controls.Add(lblSecAnalisis);
        panelNav.Controls.Add(btnNavCuentas);
        panelNav.Controls.Add(btnNavCompras);
        panelNav.Controls.Add(btnNavProveedores);
        panelNav.Controls.Add(btnNavClientes);
        panelNav.Controls.Add(btnNavProductos);
        panelNav.Controls.Add(lblSecGestion);
        panelNav.Controls.Add(btnNavVenta);
        panelNav.Controls.Add(btnNavDashboard);
        panelNav.Controls.Add(lblSecPrincipal);
        panelNav.Dock = System.Windows.Forms.DockStyle.Fill;
        panelNav.Location = new System.Drawing.Point(0, 74);
        panelNav.Name = "panelNav";
        panelNav.Size = new System.Drawing.Size(235, 529);
        panelNav.TabIndex = 2;
        //
        // lblSecPrincipal
        //
        lblSecPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
        lblSecPrincipal.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
        lblSecPrincipal.ForeColor = System.Drawing.Color.FromArgb(93, 112, 140);
        lblSecPrincipal.Name = "lblSecPrincipal";
        lblSecPrincipal.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
        lblSecPrincipal.Size = new System.Drawing.Size(235, 30);
        lblSecPrincipal.Text = "PRINCIPAL";
        //
        // btnNavDashboard
        //
        btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Top;
        btnNavDashboard.Name = "btnNavDashboard";
        btnNavDashboard.Size = new System.Drawing.Size(235, 42);
        btnNavDashboard.TabIndex = 0;
        btnNavDashboard.Tag = "dashboard";
        btnNavDashboard.Text = "   📊  Dashboard";
        btnNavDashboard.Click += NavBoton_Click;
        //
        // btnNavVenta
        //
        btnNavVenta.Dock = System.Windows.Forms.DockStyle.Top;
        btnNavVenta.Name = "btnNavVenta";
        btnNavVenta.Size = new System.Drawing.Size(235, 42);
        btnNavVenta.TabIndex = 1;
        btnNavVenta.Tag = "venta";
        btnNavVenta.Text = "   🛒  Registrar Venta";
        btnNavVenta.Click += NavBoton_Click;
        //
        // lblSecGestion
        //
        lblSecGestion.Dock = System.Windows.Forms.DockStyle.Top;
        lblSecGestion.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
        lblSecGestion.ForeColor = System.Drawing.Color.FromArgb(93, 112, 140);
        lblSecGestion.Name = "lblSecGestion";
        lblSecGestion.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
        lblSecGestion.Size = new System.Drawing.Size(235, 30);
        lblSecGestion.Text = "GESTIÓN";
        //
        // btnNavProductos
        //
        btnNavProductos.Dock = System.Windows.Forms.DockStyle.Top;
        btnNavProductos.Name = "btnNavProductos";
        btnNavProductos.Size = new System.Drawing.Size(235, 42);
        btnNavProductos.TabIndex = 2;
        btnNavProductos.Tag = "productos";
        btnNavProductos.Text = "   📦  Productos";
        btnNavProductos.Click += NavBoton_Click;
        //
        // btnNavClientes
        //
        btnNavClientes.Dock = System.Windows.Forms.DockStyle.Top;
        btnNavClientes.Name = "btnNavClientes";
        btnNavClientes.Size = new System.Drawing.Size(235, 42);
        btnNavClientes.TabIndex = 3;
        btnNavClientes.Tag = "clientes";
        btnNavClientes.Text = "   👥  Clientes";
        btnNavClientes.Click += NavBoton_Click;
        //
        // btnNavProveedores
        //
        btnNavProveedores.Dock = System.Windows.Forms.DockStyle.Top;
        btnNavProveedores.Name = "btnNavProveedores";
        btnNavProveedores.Size = new System.Drawing.Size(235, 42);
        btnNavProveedores.TabIndex = 4;
        btnNavProveedores.Tag = "proveedores";
        btnNavProveedores.Text = "   🚚  Proveedores";
        btnNavProveedores.Click += NavBoton_Click;
        //
        // btnNavCompras
        //
        btnNavCompras.Dock = System.Windows.Forms.DockStyle.Top;
        btnNavCompras.Name = "btnNavCompras";
        btnNavCompras.Size = new System.Drawing.Size(235, 42);
        btnNavCompras.TabIndex = 5;
        btnNavCompras.Tag = "compras";
        btnNavCompras.Text = "   🧾  Registrar Compra";
        btnNavCompras.Click += NavBoton_Click;
        //
        // btnNavCuentas
        //
        btnNavCuentas.Dock = System.Windows.Forms.DockStyle.Top;
        btnNavCuentas.Name = "btnNavCuentas";
        btnNavCuentas.Size = new System.Drawing.Size(235, 42);
        btnNavCuentas.TabIndex = 6;
        btnNavCuentas.Tag = "cuentas";
        btnNavCuentas.Text = "   💰  Cuentas Corrientes";
        btnNavCuentas.Click += NavBoton_Click;
        //
        // lblSecAnalisis
        //
        lblSecAnalisis.Dock = System.Windows.Forms.DockStyle.Top;
        lblSecAnalisis.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
        lblSecAnalisis.ForeColor = System.Drawing.Color.FromArgb(93, 112, 140);
        lblSecAnalisis.Name = "lblSecAnalisis";
        lblSecAnalisis.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
        lblSecAnalisis.Size = new System.Drawing.Size(235, 30);
        lblSecAnalisis.Text = "ANÁLISIS";
        //
        // btnNavReportes
        //
        btnNavReportes.Dock = System.Windows.Forms.DockStyle.Top;
        btnNavReportes.Name = "btnNavReportes";
        btnNavReportes.Size = new System.Drawing.Size(235, 42);
        btnNavReportes.TabIndex = 7;
        btnNavReportes.Tag = "reportes";
        btnNavReportes.Text = "   📈  Reportes";
        btnNavReportes.Click += NavBoton_Click;
        //
        // btnNavAuditoria
        //
        btnNavAuditoria.Dock = System.Windows.Forms.DockStyle.Top;
        btnNavAuditoria.Name = "btnNavAuditoria";
        btnNavAuditoria.Size = new System.Drawing.Size(235, 42);
        btnNavAuditoria.TabIndex = 8;
        btnNavAuditoria.Tag = "auditoria";
        btnNavAuditoria.Text = "   🕒  Auditoría";
        btnNavAuditoria.Click += NavBoton_Click;
        //
        // lblSecAdministracion
        //
        lblSecAdministracion.Dock = System.Windows.Forms.DockStyle.Top;
        lblSecAdministracion.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
        lblSecAdministracion.ForeColor = System.Drawing.Color.FromArgb(93, 112, 140);
        lblSecAdministracion.Name = "lblSecAdministracion";
        lblSecAdministracion.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
        lblSecAdministracion.Size = new System.Drawing.Size(235, 30);
        lblSecAdministracion.Text = "ADMINISTRACIÓN";
        //
        // btnNavUsuarios
        //
        btnNavUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
        btnNavUsuarios.Name = "btnNavUsuarios";
        btnNavUsuarios.Size = new System.Drawing.Size(235, 42);
        btnNavUsuarios.TabIndex = 9;
        btnNavUsuarios.Tag = "usuarios";
        btnNavUsuarios.Text = "   🔐  Usuarios y Grupos";
        btnNavUsuarios.Click += NavBoton_Click;
        //
        // panelLogo
        //
        panelLogo.BackColor = System.Drawing.Color.FromArgb(27, 42, 65);
        panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
        panelLogo.Location = new System.Drawing.Point(0, 0);
        panelLogo.Name = "panelLogo";
        panelLogo.Size = new System.Drawing.Size(235, 74);
        panelLogo.TabIndex = 0;
        //
        // panelPie
        //
        panelPie.BackColor = System.Drawing.Color.FromArgb(27, 42, 65);
        panelPie.Controls.Add(btnCerrarSesion);
        panelPie.Controls.Add(lblGrupo);
        panelPie.Controls.Add(lblUsuario);
        panelPie.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelPie.Location = new System.Drawing.Point(0, 603);
        panelPie.Name = "panelPie";
        panelPie.Padding = new System.Windows.Forms.Padding(16, 10, 16, 12);
        panelPie.Size = new System.Drawing.Size(235, 118);
        panelPie.TabIndex = 1;
        //
        // lblUsuario
        //
        lblUsuario.Dock = System.Windows.Forms.DockStyle.Top;
        lblUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
        lblUsuario.ForeColor = System.Drawing.Color.White;
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new System.Drawing.Size(203, 22);
        lblUsuario.Text = "Usuario";
        //
        // lblGrupo
        //
        lblGrupo.Dock = System.Windows.Forms.DockStyle.Top;
        lblGrupo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
        lblGrupo.ForeColor = System.Drawing.Color.FromArgb(124, 141, 166);
        lblGrupo.Name = "lblGrupo";
        lblGrupo.Size = new System.Drawing.Size(203, 20);
        lblGrupo.Text = "Grupo";
        //
        // btnCerrarSesion
        //
        btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
        btnCerrarSesion.Name = "btnCerrarSesion";
        btnCerrarSesion.Size = new System.Drawing.Size(203, 36);
        btnCerrarSesion.TabIndex = 0;
        btnCerrarSesion.Text = "⏻  Cerrar Sesión";
        btnCerrarSesion.Click += BtnCerrarSesion_Click;
        //
        // MainForm
        //
        BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
        ClientSize = new System.Drawing.Size(1264, 721);
        Controls.Add(panelContenido);
        Controls.Add(panelSidebar);
        Name = "MainForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "MiEmpresa ERP";
        WindowState = System.Windows.Forms.FormWindowState.Maximized;
        panelSidebar.ResumeLayout(false);
        panelNav.ResumeLayout(false);
        panelPie.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel panelContenido;
    private System.Windows.Forms.Panel panelSidebar;
    private System.Windows.Forms.Panel panelNav;
    private System.Windows.Forms.Panel panelLogo;
    private System.Windows.Forms.Panel panelPie;
    private System.Windows.Forms.Label lblSecPrincipal;
    private System.Windows.Forms.Button btnNavDashboard;
    private System.Windows.Forms.Button btnNavVenta;
    private System.Windows.Forms.Label lblSecGestion;
    private System.Windows.Forms.Button btnNavProductos;
    private System.Windows.Forms.Button btnNavClientes;
    private System.Windows.Forms.Button btnNavProveedores;
    private System.Windows.Forms.Button btnNavCompras;
    private System.Windows.Forms.Button btnNavCuentas;
    private System.Windows.Forms.Label lblSecAnalisis;
    private System.Windows.Forms.Button btnNavReportes;
    private System.Windows.Forms.Button btnNavAuditoria;
    private System.Windows.Forms.Label lblSecAdministracion;
    private System.Windows.Forms.Button btnNavUsuarios;
    private System.Windows.Forms.Label lblUsuario;
    private System.Windows.Forms.Label lblGrupo;
    private System.Windows.Forms.Button btnCerrarSesion;
}
