namespace ERPyME.WinForms.Vistas;

partial class ClienteForm
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
        lblTitulo = new System.Windows.Forms.Label();
        lblCodigo = new System.Windows.Forms.Label();
        txtCodigo = new System.Windows.Forms.TextBox();
        lblNombre = new System.Windows.Forms.Label();
        txtNombre = new System.Windows.Forms.TextBox();
        lblCuit = new System.Windows.Forms.Label();
        txtCuit = new System.Windows.Forms.TextBox();
        lblEmail = new System.Windows.Forms.Label();
        txtEmail = new System.Windows.Forms.TextBox();
        lblTelefono = new System.Windows.Forms.Label();
        txtTelefono = new System.Windows.Forms.TextBox();
        lblDireccion = new System.Windows.Forms.Label();
        txtDireccion = new System.Windows.Forms.TextBox();
        chkActivo = new System.Windows.Forms.CheckBox();
        lblError = new System.Windows.Forms.Label();
        btnCancelar = new System.Windows.Forms.Button();
        btnGuardar = new System.Windows.Forms.Button();
        SuspendLayout();
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(16, 24, 40);
        lblTitulo.Location = new System.Drawing.Point(26, 20);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Text = "Cliente";
        //
        // lblCodigo
        //
        lblCodigo.AutoSize = true;
        lblCodigo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblCodigo.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblCodigo.Location = new System.Drawing.Point(26, 64);
        lblCodigo.Name = "lblCodigo";
        lblCodigo.Text = "Código";
        //
        // txtCodigo
        //
        txtCodigo.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
        txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtCodigo.Location = new System.Drawing.Point(26, 84);
        txtCodigo.Name = "txtCodigo";
        txtCodigo.ReadOnly = true;
        txtCodigo.Size = new System.Drawing.Size(365, 30);
        txtCodigo.TabIndex = 0;
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblNombre.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblNombre.Location = new System.Drawing.Point(26, 124);
        lblNombre.Name = "lblNombre";
        lblNombre.Text = "Nombre / Razón Social *";
        //
        // txtNombre
        //
        txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtNombre.Location = new System.Drawing.Point(26, 144);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new System.Drawing.Size(365, 30);
        txtNombre.TabIndex = 1;
        //
        // lblCuit
        //
        lblCuit.AutoSize = true;
        lblCuit.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblCuit.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblCuit.Location = new System.Drawing.Point(26, 184);
        lblCuit.Name = "lblCuit";
        lblCuit.Text = "CUIT";
        //
        // txtCuit
        //
        txtCuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtCuit.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtCuit.Location = new System.Drawing.Point(26, 204);
        txtCuit.Name = "txtCuit";
        txtCuit.Size = new System.Drawing.Size(365, 30);
        txtCuit.TabIndex = 2;
        //
        // lblEmail
        //
        lblEmail.AutoSize = true;
        lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblEmail.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblEmail.Location = new System.Drawing.Point(26, 244);
        lblEmail.Name = "lblEmail";
        lblEmail.Text = "Email";
        //
        // txtEmail
        //
        txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtEmail.Location = new System.Drawing.Point(26, 264);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new System.Drawing.Size(365, 30);
        txtEmail.TabIndex = 3;
        //
        // lblTelefono
        //
        lblTelefono.AutoSize = true;
        lblTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblTelefono.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblTelefono.Location = new System.Drawing.Point(26, 304);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Text = "Teléfono";
        //
        // txtTelefono
        //
        txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtTelefono.Location = new System.Drawing.Point(26, 324);
        txtTelefono.Name = "txtTelefono";
        txtTelefono.Size = new System.Drawing.Size(365, 30);
        txtTelefono.TabIndex = 4;
        //
        // lblDireccion
        //
        lblDireccion.AutoSize = true;
        lblDireccion.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblDireccion.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblDireccion.Location = new System.Drawing.Point(26, 364);
        lblDireccion.Name = "lblDireccion";
        lblDireccion.Text = "Dirección";
        //
        // txtDireccion
        //
        txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtDireccion.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtDireccion.Location = new System.Drawing.Point(26, 384);
        txtDireccion.Name = "txtDireccion";
        txtDireccion.Size = new System.Drawing.Size(365, 30);
        txtDireccion.TabIndex = 5;
        //
        // chkActivo
        //
        chkActivo.AutoSize = true;
        chkActivo.Checked = true;
        chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
        chkActivo.Location = new System.Drawing.Point(26, 424);
        chkActivo.Name = "chkActivo";
        chkActivo.TabIndex = 6;
        chkActivo.Text = "Cliente activo";
        //
        // lblError
        //
        lblError.Font = new System.Drawing.Font("Segoe UI", 8.75F);
        lblError.ForeColor = System.Drawing.Color.FromArgb(225, 29, 72);
        lblError.Location = new System.Drawing.Point(26, 454);
        lblError.Name = "lblError";
        lblError.Size = new System.Drawing.Size(365, 30);
        lblError.Visible = false;
        //
        // btnCancelar
        //
        btnCancelar.Location = new System.Drawing.Point(171, 490);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new System.Drawing.Size(105, 36);
        btnCancelar.TabIndex = 8;
        btnCancelar.Text = "Cancelar";
        btnCancelar.Click += BtnCancelar_Click;
        //
        // btnGuardar
        //
        btnGuardar.Location = new System.Drawing.Point(286, 490);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new System.Drawing.Size(105, 36);
        btnGuardar.TabIndex = 7;
        btnGuardar.Text = "Guardar";
        btnGuardar.Click += BtnGuardar_Click;
        //
        // ClienteForm
        //
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(424, 546);
        Controls.Add(lblTitulo);
        Controls.Add(lblCodigo);
        Controls.Add(txtCodigo);
        Controls.Add(lblNombre);
        Controls.Add(txtNombre);
        Controls.Add(lblCuit);
        Controls.Add(txtCuit);
        Controls.Add(lblEmail);
        Controls.Add(txtEmail);
        Controls.Add(lblTelefono);
        Controls.Add(txtTelefono);
        Controls.Add(lblDireccion);
        Controls.Add(txtDireccion);
        Controls.Add(chkActivo);
        Controls.Add(lblError);
        Controls.Add(btnCancelar);
        Controls.Add(btnGuardar);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ClienteForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Cliente";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.Label lblCodigo;
    private System.Windows.Forms.TextBox txtCodigo;
    private System.Windows.Forms.Label lblNombre;
    private System.Windows.Forms.TextBox txtNombre;
    private System.Windows.Forms.Label lblCuit;
    private System.Windows.Forms.TextBox txtCuit;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.Label lblTelefono;
    private System.Windows.Forms.TextBox txtTelefono;
    private System.Windows.Forms.Label lblDireccion;
    private System.Windows.Forms.TextBox txtDireccion;
    private System.Windows.Forms.CheckBox chkActivo;
    private System.Windows.Forms.Label lblError;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Button btnGuardar;
}
