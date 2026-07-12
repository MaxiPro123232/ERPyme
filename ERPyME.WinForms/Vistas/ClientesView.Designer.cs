namespace ERPyME.WinForms.Vistas;

partial class ClientesView
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
        cardGrilla = new System.Windows.Forms.Panel();
        gridClientes = new System.Windows.Forms.DataGridView();
        colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colCuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colBtnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
        colBtnEstado = new System.Windows.Forms.DataGridViewButtonColumn();
        panelBarra = new System.Windows.Forms.Panel();
        lblTitulo = new System.Windows.Forms.Label();
        lblSubtitulo = new System.Windows.Forms.Label();
        btnNuevo = new System.Windows.Forms.Button();
        txtBuscar = new System.Windows.Forms.TextBox();
        cardGrilla.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridClientes).BeginInit();
        panelBarra.SuspendLayout();
        SuspendLayout();
        //
        // cardGrilla
        //
        cardGrilla.BackColor = System.Drawing.Color.White;
        cardGrilla.Controls.Add(gridClientes);
        cardGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
        cardGrilla.Location = new System.Drawing.Point(26, 126);
        cardGrilla.Name = "cardGrilla";
        cardGrilla.Padding = new System.Windows.Forms.Padding(1);
        cardGrilla.Size = new System.Drawing.Size(978, 574);
        cardGrilla.TabIndex = 0;
        //
        // gridClientes
        //
        gridClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colCodigo, colNombre, colCuit, colEmail, colTelefono, colSaldo, colEstado, colBtnEditar, colBtnEstado });
        gridClientes.Dock = System.Windows.Forms.DockStyle.Fill;
        gridClientes.Location = new System.Drawing.Point(1, 1);
        gridClientes.Name = "gridClientes";
        gridClientes.Size = new System.Drawing.Size(976, 572);
        gridClientes.TabIndex = 0;
        gridClientes.CellContentClick += GridClientes_CellContentClick;
        gridClientes.CellFormatting += GridClientes_CellFormatting;
        //
        // colCodigo
        //
        colCodigo.DataPropertyName = "Codigo";
        colCodigo.FillWeight = 9F;
        colCodigo.HeaderText = "Código";
        colCodigo.Name = "colCodigo";
        //
        // colNombre
        //
        colNombre.DataPropertyName = "Nombre";
        colNombre.FillWeight = 24F;
        colNombre.HeaderText = "Nombre / Razón Social";
        colNombre.Name = "colNombre";
        //
        // colCuit
        //
        colCuit.DataPropertyName = "Cuit";
        colCuit.FillWeight = 13F;
        colCuit.HeaderText = "CUIT";
        colCuit.Name = "colCuit";
        //
        // colEmail
        //
        colEmail.DataPropertyName = "Email";
        colEmail.FillWeight = 18F;
        colEmail.HeaderText = "Email";
        colEmail.Name = "colEmail";
        //
        // colTelefono
        //
        colTelefono.DataPropertyName = "Telefono";
        colTelefono.FillWeight = 11F;
        colTelefono.HeaderText = "Teléfono";
        colTelefono.Name = "colTelefono";
        //
        // colSaldo
        //
        colSaldo.DataPropertyName = "Saldo";
        colSaldo.FillWeight = 11F;
        colSaldo.HeaderText = "Saldo Cta. Cte.";
        colSaldo.Name = "colSaldo";
        //
        // colEstado
        //
        colEstado.DataPropertyName = "Estado";
        colEstado.FillWeight = 8F;
        colEstado.HeaderText = "Estado";
        colEstado.Name = "colEstado";
        //
        // colBtnEditar
        //
        colBtnEditar.DataPropertyName = "AccionEditar";
        colBtnEditar.FillWeight = 8F;
        colBtnEditar.HeaderText = "";
        colBtnEditar.Name = "editar";
        //
        // colBtnEstado
        //
        colBtnEstado.DataPropertyName = "AccionEstado";
        colBtnEstado.FillWeight = 9F;
        colBtnEstado.HeaderText = "";
        colBtnEstado.Name = "estado";
        //
        // panelBarra
        //
        panelBarra.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
        panelBarra.Controls.Add(lblTitulo);
        panelBarra.Controls.Add(lblSubtitulo);
        panelBarra.Controls.Add(btnNuevo);
        panelBarra.Controls.Add(txtBuscar);
        panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
        panelBarra.Location = new System.Drawing.Point(26, 20);
        panelBarra.Name = "panelBarra";
        panelBarra.Size = new System.Drawing.Size(978, 106);
        panelBarra.TabIndex = 1;
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
        lblTitulo.Location = new System.Drawing.Point(0, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Text = "Gestión de Clientes";
        //
        // lblSubtitulo
        //
        lblSubtitulo.AutoSize = true;
        lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
        lblSubtitulo.Location = new System.Drawing.Point(2, 32);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Text = "Listado, búsqueda y administración de clientes (RF10 / RF11)";
        //
        // btnNuevo
        //
        btnNuevo.Location = new System.Drawing.Point(0, 62);
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Size = new System.Drawing.Size(160, 34);
        btnNuevo.TabIndex = 0;
        btnNuevo.Text = "＋  Nuevo Cliente";
        btnNuevo.Click += BtnNuevo_Click;
        //
        // txtBuscar
        //
        txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtBuscar.Location = new System.Drawing.Point(698, 64);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.PlaceholderText = "Buscar cliente...";
        txtBuscar.Size = new System.Drawing.Size(280, 30);
        txtBuscar.TabIndex = 1;
        txtBuscar.TextChanged += TxtBuscar_TextChanged;
        //
        // ClientesView
        //
        BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
        Controls.Add(cardGrilla);
        Controls.Add(panelBarra);
        Name = "ClientesView";
        Padding = new System.Windows.Forms.Padding(26, 20, 26, 20);
        Size = new System.Drawing.Size(1030, 720);
        cardGrilla.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridClientes).EndInit();
        panelBarra.ResumeLayout(false);
        panelBarra.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel cardGrilla;
    private System.Windows.Forms.DataGridView gridClientes;
    private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
    private System.Windows.Forms.DataGridViewTextBoxColumn colCuit;
    private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
    private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    private System.Windows.Forms.DataGridViewButtonColumn colBtnEditar;
    private System.Windows.Forms.DataGridViewButtonColumn colBtnEstado;
    private System.Windows.Forms.Panel panelBarra;
    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.Label lblSubtitulo;
    private System.Windows.Forms.Button btnNuevo;
    private System.Windows.Forms.TextBox txtBuscar;
}
