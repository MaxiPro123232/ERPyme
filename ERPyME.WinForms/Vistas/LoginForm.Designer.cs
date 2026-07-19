namespace ERPyME.WinForms.Vistas;

partial class LoginForm
{
    /// <summary>Variable del diseñador necesaria.</summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>Limpiar los recursos que se estén usando.</summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido de este método con el editor de código.
    /// </summary>
    private void InitializeComponent()
    {
        panelIzquierdo = new System.Windows.Forms.Panel();
        cardLogin = new System.Windows.Forms.Panel();
        lblTitulo = new System.Windows.Forms.Label();
        lblSubtitulo = new System.Windows.Forms.Label();
        lblUsuario = new System.Windows.Forms.Label();
        txtUsuario = new System.Windows.Forms.TextBox();
        lblClave = new System.Windows.Forms.Label();
        txtClave = new System.Windows.Forms.TextBox();
        lblError = new System.Windows.Forms.Label();
        btnIngresar = new System.Windows.Forms.Button();
        lblDemo = new System.Windows.Forms.Label();
        lblCopyright = new System.Windows.Forms.Label();
        cardLogin.SuspendLayout();
        SuspendLayout();
        //
        // panelIzquierdo
        //
        panelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
        panelIzquierdo.Location = new System.Drawing.Point(0, 0);
        panelIzquierdo.Name = "panelIzquierdo";
        panelIzquierdo.Size = new System.Drawing.Size(400, 521);
        panelIzquierdo.TabIndex = 1;
        //
        // cardLogin
        //
        cardLogin.BackColor = System.Drawing.Color.White;
        cardLogin.Controls.Add(lblTitulo);
        cardLogin.Controls.Add(lblSubtitulo);
        cardLogin.Controls.Add(lblUsuario);
        cardLogin.Controls.Add(txtUsuario);
        cardLogin.Controls.Add(lblClave);
        cardLogin.Controls.Add(txtClave);
        cardLogin.Controls.Add(lblError);
        cardLogin.Controls.Add(btnIngresar);
        cardLogin.Controls.Add(lblDemo);
        cardLogin.Controls.Add(lblCopyright);
        cardLogin.Location = new System.Drawing.Point(490, 70);
        cardLogin.Name = "cardLogin";
        cardLogin.Size = new System.Drawing.Size(340, 380);
        cardLogin.TabIndex = 0;
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(16, 24, 40);
        lblTitulo.Location = new System.Drawing.Point(30, 26);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Text = "Iniciar Sesión";
        //
        // lblSubtitulo
        //
        lblSubtitulo.AutoSize = true;
        lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblSubtitulo.Location = new System.Drawing.Point(30, 60);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Text = "Ingresá tus credenciales para acceder";
        //
        // lblUsuario
        //
        lblUsuario.AutoSize = true;
        lblUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblUsuario.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblUsuario.Location = new System.Drawing.Point(30, 100);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Text = "Usuario";
        //
        // txtUsuario
        //
        txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtUsuario.Location = new System.Drawing.Point(30, 120);
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Size = new System.Drawing.Size(280, 30);
        txtUsuario.TabIndex = 1;
        //
        // lblClave
        //
        lblClave.AutoSize = true;
        lblClave.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblClave.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblClave.Location = new System.Drawing.Point(30, 162);
        lblClave.Name = "lblClave";
        lblClave.Text = "Contraseña";
        //
        // txtClave
        //
        txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtClave.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtClave.Location = new System.Drawing.Point(30, 182);
        txtClave.Name = "txtClave";
        txtClave.Size = new System.Drawing.Size(280, 30);
        txtClave.TabIndex = 2;
        txtClave.UseSystemPasswordChar = true;
        //
        // lblError
        //
        lblError.Font = new System.Drawing.Font("Segoe UI", 8.75F);
        lblError.ForeColor = System.Drawing.Color.FromArgb(225, 29, 72);
        lblError.Location = new System.Drawing.Point(30, 220);
        lblError.Name = "lblError";
        lblError.Size = new System.Drawing.Size(280, 34);
        lblError.Visible = false;
        //
        // btnIngresar
        //
        btnIngresar.Location = new System.Drawing.Point(30, 258);
        btnIngresar.Name = "btnIngresar";
        btnIngresar.Size = new System.Drawing.Size(280, 40);
        btnIngresar.TabIndex = 3;
        btnIngresar.Text = "Iniciar Sesión";
        btnIngresar.Click += BtnIngresar_Click;
        //
        // lblDemo
        //
        lblDemo.AutoSize = true;
        lblDemo.Font = new System.Drawing.Font("Segoe UI", 8F);
        lblDemo.ForeColor = System.Drawing.Color.FromArgb(152, 162, 179);
        lblDemo.Location = new System.Drawing.Point(30, 314);
        lblDemo.Name = "lblDemo";
        lblDemo.Text = "Demo: admin / admin  ·  vendedor / vendedor";
        //
        // lblCopyright
        //
        lblCopyright.AutoSize = true;
        lblCopyright.Font = new System.Drawing.Font("Segoe UI", 8F);
        lblCopyright.ForeColor = System.Drawing.Color.FromArgb(229, 231, 235);
        lblCopyright.Location = new System.Drawing.Point(30, 336);
        lblCopyright.Name = "lblCopyright";
        lblCopyright.Text = "© 2026 MiEmpresa ERP";
        //
        // LoginForm
        //
        AcceptButton = btnIngresar;
        BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
        ClientSize = new System.Drawing.Size(904, 521);
        Controls.Add(cardLogin);
        Controls.Add(panelIzquierdo);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "LoginForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ERPyME - Iniciar Sesión";
        cardLogin.ResumeLayout(false);
        cardLogin.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel panelIzquierdo;
    private System.Windows.Forms.Panel cardLogin;
    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.Label lblSubtitulo;
    private System.Windows.Forms.Label lblUsuario;
    private System.Windows.Forms.TextBox txtUsuario;
    private System.Windows.Forms.Label lblClave;
    private System.Windows.Forms.TextBox txtClave;
    private System.Windows.Forms.Label lblError;
    private System.Windows.Forms.Button btnIngresar;
    private System.Windows.Forms.Label lblDemo;
    private System.Windows.Forms.Label lblCopyright;
}
