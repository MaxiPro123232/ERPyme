namespace ERPyME.WinForms.Vistas;

partial class VentaView
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
        cardProductos = new System.Windows.Forms.Panel();
        gridItems = new System.Windows.Forms.DataGridView();
        colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colBtnQuitar = new System.Windows.Forms.DataGridViewButtonColumn();
        panelSelector = new System.Windows.Forms.Panel();
        lblProducto = new System.Windows.Forms.Label();
        cboProducto = new System.Windows.Forms.ComboBox();
        lblCantidad = new System.Windows.Forms.Label();
        numCantidad = new System.Windows.Forms.NumericUpDown();
        btnAgregar = new System.Windows.Forms.Button();
        lblStockInfo = new System.Windows.Forms.Label();
        lblProductos = new System.Windows.Forms.Label();
        panelTotal = new System.Windows.Forms.Panel();
        lblTotal = new System.Windows.Forms.Label();
        lblTotalTexto = new System.Windows.Forms.Label();
        cardDatos = new System.Windows.Forms.Panel();
        lblNuevaVenta = new System.Windows.Forms.Label();
        lblFecha = new System.Windows.Forms.Label();
        txtFecha = new System.Windows.Forms.TextBox();
        lblCliente = new System.Windows.Forms.Label();
        cboCliente = new System.Windows.Forms.ComboBox();
        lblFormaPago = new System.Windows.Forms.Label();
        cboFormaPago = new System.Windows.Forms.ComboBox();
        panelBarra = new System.Windows.Forms.Panel();
        lblTitulo = new System.Windows.Forms.Label();
        lblSubtitulo = new System.Windows.Forms.Label();
        panelBotones = new System.Windows.Forms.Panel();
        btnConfirmar = new System.Windows.Forms.Button();
        btnCancelar = new System.Windows.Forms.Button();
        cardProductos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridItems).BeginInit();
        panelSelector.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
        panelTotal.SuspendLayout();
        cardDatos.SuspendLayout();
        panelBarra.SuspendLayout();
        panelBotones.SuspendLayout();
        SuspendLayout();
        //
        // cardProductos
        //
        cardProductos.BackColor = System.Drawing.Color.White;
        cardProductos.Controls.Add(gridItems);
        cardProductos.Controls.Add(panelSelector);
        cardProductos.Controls.Add(lblProductos);
        cardProductos.Controls.Add(panelTotal);
        cardProductos.Dock = System.Windows.Forms.DockStyle.Fill;
        cardProductos.Location = new System.Drawing.Point(26, 198);
        cardProductos.Name = "cardProductos";
        cardProductos.Padding = new System.Windows.Forms.Padding(20, 14, 20, 14);
        cardProductos.Size = new System.Drawing.Size(978, 446);
        cardProductos.TabIndex = 0;
        //
        // gridItems
        //
        gridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colCodigo, colProducto, colCantidad, colPrecioUnitario, colSubtotal, colBtnQuitar });
        gridItems.Dock = System.Windows.Forms.DockStyle.Fill;
        gridItems.Location = new System.Drawing.Point(20, 120);
        gridItems.Name = "gridItems";
        gridItems.Size = new System.Drawing.Size(938, 266);
        gridItems.TabIndex = 2;
        gridItems.CellContentClick += GridItems_CellContentClick;
        //
        // colCodigo
        //
        colCodigo.DataPropertyName = "Codigo";
        colCodigo.FillWeight = 12F;
        colCodigo.HeaderText = "Código";
        colCodigo.Name = "colCodigo";
        //
        // colProducto
        //
        colProducto.DataPropertyName = "Producto";
        colProducto.FillWeight = 36F;
        colProducto.HeaderText = "Producto";
        colProducto.Name = "colProducto";
        //
        // colCantidad
        //
        colCantidad.DataPropertyName = "Cantidad";
        colCantidad.FillWeight = 12F;
        colCantidad.HeaderText = "Cantidad";
        colCantidad.Name = "colCantidad";
        //
        // colPrecioUnitario
        //
        colPrecioUnitario.DataPropertyName = "PrecioUnitario";
        colPrecioUnitario.FillWeight = 14F;
        colPrecioUnitario.HeaderText = "Precio Unit.";
        colPrecioUnitario.Name = "colPrecioUnitario";
        //
        // colSubtotal
        //
        colSubtotal.DataPropertyName = "Subtotal";
        colSubtotal.FillWeight = 14F;
        colSubtotal.HeaderText = "Subtotal";
        colSubtotal.Name = "colSubtotal";
        //
        // colBtnQuitar
        //
        colBtnQuitar.DataPropertyName = "AccionQuitar";
        colBtnQuitar.FillWeight = 12F;
        colBtnQuitar.HeaderText = "";
        colBtnQuitar.Name = "quitar";
        //
        // panelSelector
        //
        panelSelector.BackColor = System.Drawing.Color.White;
        panelSelector.Controls.Add(lblProducto);
        panelSelector.Controls.Add(cboProducto);
        panelSelector.Controls.Add(lblCantidad);
        panelSelector.Controls.Add(numCantidad);
        panelSelector.Controls.Add(btnAgregar);
        panelSelector.Controls.Add(lblStockInfo);
        panelSelector.Dock = System.Windows.Forms.DockStyle.Top;
        panelSelector.Location = new System.Drawing.Point(20, 42);
        panelSelector.Name = "panelSelector";
        panelSelector.Size = new System.Drawing.Size(938, 78);
        panelSelector.TabIndex = 1;
        panelSelector.Resize += PanelSelector_Resize;
        //
        // lblProducto
        //
        lblProducto.AutoSize = true;
        lblProducto.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblProducto.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblProducto.Location = new System.Drawing.Point(0, 2);
        lblProducto.Name = "lblProducto";
        lblProducto.Text = "Producto";
        //
        // cboProducto
        //
        cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        cboProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
        cboProducto.Location = new System.Drawing.Point(0, 22);
        cboProducto.Name = "cboProducto";
        cboProducto.Size = new System.Drawing.Size(380, 31);
        cboProducto.TabIndex = 0;
        cboProducto.SelectedIndexChanged += CboProducto_SelectedIndexChanged;
        //
        // lblCantidad
        //
        lblCantidad.AutoSize = true;
        lblCantidad.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblCantidad.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblCantidad.Location = new System.Drawing.Point(396, 2);
        lblCantidad.Name = "lblCantidad";
        lblCantidad.Text = "Cantidad";
        //
        // numCantidad
        //
        numCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
        numCantidad.Location = new System.Drawing.Point(396, 22);
        numCantidad.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numCantidad.Name = "numCantidad";
        numCantidad.Size = new System.Drawing.Size(90, 30);
        numCantidad.TabIndex = 1;
        numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
        //
        // btnAgregar
        //
        btnAgregar.Location = new System.Drawing.Point(500, 19);
        btnAgregar.Name = "btnAgregar";
        btnAgregar.Size = new System.Drawing.Size(120, 34);
        btnAgregar.TabIndex = 2;
        btnAgregar.Text = "＋ Agregar";
        btnAgregar.Click += BtnAgregar_Click;
        //
        // lblStockInfo
        //
        lblStockInfo.AutoSize = true;
        lblStockInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        lblStockInfo.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblStockInfo.Location = new System.Drawing.Point(0, 58);
        lblStockInfo.Name = "lblStockInfo";
        //
        // lblProductos
        //
        lblProductos.Dock = System.Windows.Forms.DockStyle.Top;
        lblProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
        lblProductos.ForeColor = System.Drawing.Color.FromArgb(16, 24, 40);
        lblProductos.Location = new System.Drawing.Point(20, 14);
        lblProductos.Name = "lblProductos";
        lblProductos.Size = new System.Drawing.Size(938, 28);
        lblProductos.Text = "Productos";
        //
        // panelTotal
        //
        panelTotal.BackColor = System.Drawing.Color.White;
        panelTotal.Controls.Add(lblTotal);
        panelTotal.Controls.Add(lblTotalTexto);
        panelTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelTotal.Location = new System.Drawing.Point(20, 386);
        panelTotal.Name = "panelTotal";
        panelTotal.Size = new System.Drawing.Size(938, 46);
        panelTotal.TabIndex = 3;
        panelTotal.Resize += PanelTotal_Resize;
        //
        // lblTotal
        //
        lblTotal.AutoSize = true;
        lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTotal.ForeColor = System.Drawing.Color.FromArgb(16, 24, 40);
        lblTotal.Location = new System.Drawing.Point(880, 10);
        lblTotal.Name = "lblTotal";
        lblTotal.Text = "$ 0";
        lblTotal.TextChanged += LblTotal_TextChanged;
        //
        // lblTotalTexto
        //
        lblTotalTexto.AutoSize = true;
        lblTotalTexto.Font = new System.Drawing.Font("Segoe UI", 11F);
        lblTotalTexto.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblTotalTexto.Location = new System.Drawing.Point(820, 16);
        lblTotalTexto.Name = "lblTotalTexto";
        lblTotalTexto.Text = "Total:";
        //
        // cardDatos
        //
        cardDatos.BackColor = System.Drawing.Color.White;
        cardDatos.Controls.Add(lblNuevaVenta);
        cardDatos.Controls.Add(lblFecha);
        cardDatos.Controls.Add(txtFecha);
        cardDatos.Controls.Add(lblCliente);
        cardDatos.Controls.Add(cboCliente);
        cardDatos.Controls.Add(lblFormaPago);
        cardDatos.Controls.Add(cboFormaPago);
        cardDatos.Dock = System.Windows.Forms.DockStyle.Top;
        cardDatos.Location = new System.Drawing.Point(26, 86);
        cardDatos.Name = "cardDatos";
        cardDatos.Size = new System.Drawing.Size(978, 112);
        cardDatos.TabIndex = 1;
        cardDatos.Resize += CardDatos_Resize;
        //
        // lblNuevaVenta
        //
        lblNuevaVenta.AutoSize = true;
        lblNuevaVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
        lblNuevaVenta.ForeColor = System.Drawing.Color.FromArgb(16, 24, 40);
        lblNuevaVenta.Location = new System.Drawing.Point(20, 12);
        lblNuevaVenta.Name = "lblNuevaVenta";
        lblNuevaVenta.Text = "Nueva Venta";
        //
        // lblFecha
        //
        lblFecha.AutoSize = true;
        lblFecha.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblFecha.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblFecha.Location = new System.Drawing.Point(20, 42);
        lblFecha.Name = "lblFecha";
        lblFecha.Text = "Fecha";
        //
        // txtFecha
        //
        txtFecha.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
        txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtFecha.Location = new System.Drawing.Point(20, 62);
        txtFecha.Name = "txtFecha";
        txtFecha.ReadOnly = true;
        txtFecha.Size = new System.Drawing.Size(130, 30);
        txtFecha.TabIndex = 0;
        //
        // lblCliente
        //
        lblCliente.AutoSize = true;
        lblCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblCliente.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblCliente.Location = new System.Drawing.Point(170, 42);
        lblCliente.Name = "lblCliente";
        lblCliente.Text = "Cliente *";
        //
        // cboCliente
        //
        cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        cboCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
        cboCliente.Location = new System.Drawing.Point(170, 62);
        cboCliente.Name = "cboCliente";
        cboCliente.Size = new System.Drawing.Size(360, 31);
        cboCliente.TabIndex = 1;
        //
        // lblFormaPago
        //
        lblFormaPago.AutoSize = true;
        lblFormaPago.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F);
        lblFormaPago.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblFormaPago.Location = new System.Drawing.Point(550, 42);
        lblFormaPago.Name = "lblFormaPago";
        lblFormaPago.Text = "Forma de Pago *";
        //
        // cboFormaPago
        //
        cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboFormaPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        cboFormaPago.Font = new System.Drawing.Font("Segoe UI", 10F);
        cboFormaPago.Items.AddRange(new object[] { "Contado", "Cuenta Corriente" });
        cboFormaPago.Location = new System.Drawing.Point(550, 62);
        cboFormaPago.Name = "cboFormaPago";
        cboFormaPago.Size = new System.Drawing.Size(180, 31);
        cboFormaPago.TabIndex = 2;
        //
        // panelBarra
        //
        panelBarra.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
        panelBarra.Controls.Add(lblTitulo);
        panelBarra.Controls.Add(lblSubtitulo);
        panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
        panelBarra.Location = new System.Drawing.Point(26, 20);
        panelBarra.Name = "panelBarra";
        panelBarra.Size = new System.Drawing.Size(978, 66);
        panelBarra.TabIndex = 2;
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(16, 24, 40);
        lblTitulo.Location = new System.Drawing.Point(0, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Text = "Registrar Venta";
        //
        // lblSubtitulo
        //
        lblSubtitulo.AutoSize = true;
        lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblSubtitulo.Location = new System.Drawing.Point(2, 32);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Text = "Requerimiento core RC01 · valida stock, actualiza inventario y cuenta corriente";
        //
        // panelBotones
        //
        panelBotones.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
        panelBotones.Controls.Add(btnConfirmar);
        panelBotones.Controls.Add(btnCancelar);
        panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelBotones.Location = new System.Drawing.Point(26, 644);
        panelBotones.Name = "panelBotones";
        panelBotones.Size = new System.Drawing.Size(978, 56);
        panelBotones.TabIndex = 3;
        //
        // btnConfirmar
        //
        btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnConfirmar.Location = new System.Drawing.Point(798, 12);
        btnConfirmar.Name = "btnConfirmar";
        btnConfirmar.Size = new System.Drawing.Size(180, 40);
        btnConfirmar.TabIndex = 0;
        btnConfirmar.Text = "✓  Confirmar Venta";
        btnConfirmar.Click += BtnConfirmar_Click;
        //
        // btnCancelar
        //
        btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnCancelar.Location = new System.Drawing.Point(668, 12);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new System.Drawing.Size(118, 40);
        btnCancelar.TabIndex = 1;
        btnCancelar.Text = "Cancelar";
        btnCancelar.Click += BtnCancelar_Click;
        //
        // VentaView
        //
        BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
        Controls.Add(cardProductos);
        Controls.Add(cardDatos);
        Controls.Add(panelBarra);
        Controls.Add(panelBotones);
        Name = "VentaView";
        Padding = new System.Windows.Forms.Padding(26, 20, 26, 20);
        Size = new System.Drawing.Size(1030, 720);
        cardProductos.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridItems).EndInit();
        panelSelector.ResumeLayout(false);
        panelSelector.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
        panelTotal.ResumeLayout(false);
        panelTotal.PerformLayout();
        cardDatos.ResumeLayout(false);
        cardDatos.PerformLayout();
        panelBarra.ResumeLayout(false);
        panelBarra.PerformLayout();
        panelBotones.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel cardProductos;
    private System.Windows.Forms.DataGridView gridItems;
    private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
    private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
    private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnitario;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
    private System.Windows.Forms.DataGridViewButtonColumn colBtnQuitar;
    private System.Windows.Forms.Panel panelSelector;
    private System.Windows.Forms.Label lblProducto;
    private System.Windows.Forms.ComboBox cboProducto;
    private System.Windows.Forms.Label lblCantidad;
    private System.Windows.Forms.NumericUpDown numCantidad;
    private System.Windows.Forms.Button btnAgregar;
    private System.Windows.Forms.Label lblStockInfo;
    private System.Windows.Forms.Label lblProductos;
    private System.Windows.Forms.Panel panelTotal;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Label lblTotalTexto;
    private System.Windows.Forms.Panel cardDatos;
    private System.Windows.Forms.Label lblNuevaVenta;
    private System.Windows.Forms.Label lblFecha;
    private System.Windows.Forms.TextBox txtFecha;
    private System.Windows.Forms.Label lblCliente;
    private System.Windows.Forms.ComboBox cboCliente;
    private System.Windows.Forms.Label lblFormaPago;
    private System.Windows.Forms.ComboBox cboFormaPago;
    private System.Windows.Forms.Panel panelBarra;
    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.Label lblSubtitulo;
    private System.Windows.Forms.Panel panelBotones;
    private System.Windows.Forms.Button btnConfirmar;
    private System.Windows.Forms.Button btnCancelar;
}
