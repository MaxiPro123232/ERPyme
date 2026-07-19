namespace ERPyME.WinForms.Vistas;

partial class ProductoForm
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
        lblRubro = new System.Windows.Forms.Label();
        cboRubro = new System.Windows.Forms.ComboBox();
        lblPrecio = new System.Windows.Forms.Label();
        txtPrecio = new System.Windows.Forms.TextBox();
        lblStock = new System.Windows.Forms.Label();
        txtStock = new System.Windows.Forms.TextBox();
        lblStockMin = new System.Windows.Forms.Label();
        txtStockMin = new System.Windows.Forms.TextBox();
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
        lblTitulo.Text = "Producto";
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
        lblNombre.Location = new System.Drawing.Point(26, 126);
        lblNombre.Name = "lblNombre";
        lblNombre.Text = "Nombre *";
        //
        // txtNombre
        //
        txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtNombre.Location = new System.Drawing.Point(26, 146);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new System.Drawing.Size(365, 30);
        txtNombre.TabIndex = 1;
        //
        // lblRubro
        //
        lblRubro.AutoSize = true;
        lblRubro.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblRubro.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblRubro.Location = new System.Drawing.Point(26, 188);
        lblRubro.Name = "lblRubro";
        lblRubro.Text = "Rubro / Categoría *";
        //
        // cboRubro
        //
        cboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboRubro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        cboRubro.Font = new System.Drawing.Font("Segoe UI", 10F);
        cboRubro.Location = new System.Drawing.Point(26, 208);
        cboRubro.Name = "cboRubro";
        cboRubro.Size = new System.Drawing.Size(365, 31);
        cboRubro.TabIndex = 2;
        //
        // lblPrecio
        //
        lblPrecio.AutoSize = true;
        lblPrecio.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblPrecio.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblPrecio.Location = new System.Drawing.Point(26, 250);
        lblPrecio.Name = "lblPrecio";
        lblPrecio.Text = "Precio *";
        //
        // txtPrecio
        //
        txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtPrecio.Location = new System.Drawing.Point(26, 270);
        txtPrecio.Name = "txtPrecio";
        txtPrecio.Size = new System.Drawing.Size(365, 30);
        txtPrecio.TabIndex = 3;
        //
        // lblStock
        //
        lblStock.AutoSize = true;
        lblStock.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblStock.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblStock.Location = new System.Drawing.Point(26, 312);
        lblStock.Name = "lblStock";
        lblStock.Text = "Stock *";
        //
        // txtStock
        //
        txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtStock.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtStock.Location = new System.Drawing.Point(26, 332);
        txtStock.Name = "txtStock";
        txtStock.Size = new System.Drawing.Size(175, 30);
        txtStock.TabIndex = 4;
        //
        // lblStockMin
        //
        lblStockMin.AutoSize = true;
        lblStockMin.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblStockMin.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblStockMin.Location = new System.Drawing.Point(216, 312);
        lblStockMin.Name = "lblStockMin";
        lblStockMin.Text = "Stock Mínimo *";
        //
        // txtStockMin
        //
        txtStockMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtStockMin.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtStockMin.Location = new System.Drawing.Point(216, 332);
        txtStockMin.Name = "txtStockMin";
        txtStockMin.Size = new System.Drawing.Size(175, 30);
        txtStockMin.TabIndex = 5;
        //
        // chkActivo
        //
        chkActivo.AutoSize = true;
        chkActivo.Checked = true;
        chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
        chkActivo.Location = new System.Drawing.Point(26, 374);
        chkActivo.Name = "chkActivo";
        chkActivo.TabIndex = 6;
        chkActivo.Text = "Producto activo";
        //
        // lblError
        //
        lblError.Font = new System.Drawing.Font("Segoe UI", 8.75F);
        lblError.ForeColor = System.Drawing.Color.FromArgb(225, 29, 72);
        lblError.Location = new System.Drawing.Point(26, 406);
        lblError.Name = "lblError";
        lblError.Size = new System.Drawing.Size(365, 34);
        lblError.Visible = false;
        //
        // btnCancelar
        //
        btnCancelar.Location = new System.Drawing.Point(171, 446);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new System.Drawing.Size(105, 36);
        btnCancelar.TabIndex = 8;
        btnCancelar.Text = "Cancelar";
        btnCancelar.Click += BtnCancelar_Click;
        //
        // btnGuardar
        //
        btnGuardar.Location = new System.Drawing.Point(286, 446);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new System.Drawing.Size(105, 36);
        btnGuardar.TabIndex = 7;
        btnGuardar.Text = "Guardar";
        btnGuardar.Click += BtnGuardar_Click;
        //
        // ProductoForm
        //
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(424, 502);
        Controls.Add(lblTitulo);
        Controls.Add(lblCodigo);
        Controls.Add(txtCodigo);
        Controls.Add(lblNombre);
        Controls.Add(txtNombre);
        Controls.Add(lblRubro);
        Controls.Add(cboRubro);
        Controls.Add(lblPrecio);
        Controls.Add(txtPrecio);
        Controls.Add(lblStock);
        Controls.Add(txtStock);
        Controls.Add(lblStockMin);
        Controls.Add(txtStockMin);
        Controls.Add(chkActivo);
        Controls.Add(lblError);
        Controls.Add(btnCancelar);
        Controls.Add(btnGuardar);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ProductoForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Producto";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.Label lblCodigo;
    private System.Windows.Forms.TextBox txtCodigo;
    private System.Windows.Forms.Label lblNombre;
    private System.Windows.Forms.TextBox txtNombre;
    private System.Windows.Forms.Label lblRubro;
    private System.Windows.Forms.ComboBox cboRubro;
    private System.Windows.Forms.Label lblPrecio;
    private System.Windows.Forms.TextBox txtPrecio;
    private System.Windows.Forms.Label lblStock;
    private System.Windows.Forms.TextBox txtStock;
    private System.Windows.Forms.Label lblStockMin;
    private System.Windows.Forms.TextBox txtStockMin;
    private System.Windows.Forms.CheckBox chkActivo;
    private System.Windows.Forms.Label lblError;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Button btnGuardar;
}
