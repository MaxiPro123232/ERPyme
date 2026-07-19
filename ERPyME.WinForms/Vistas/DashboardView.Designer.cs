namespace ERPyME.WinForms.Vistas;

partial class DashboardView
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
        lblFecha = new System.Windows.Forms.Label();
        tlpTarjetas = new System.Windows.Forms.TableLayoutPanel();
        cardVentasMes = new System.Windows.Forms.Panel();
        lblVentasMesDetalle = new System.Windows.Forms.Label();
        lblVentasMesValor = new System.Windows.Forms.Label();
        lblVentasMesTitulo = new System.Windows.Forms.Label();
        cardVentasHoy = new System.Windows.Forms.Panel();
        lblVentasHoyDetalle = new System.Windows.Forms.Label();
        lblVentasHoyValor = new System.Windows.Forms.Label();
        lblVentasHoyTitulo = new System.Windows.Forms.Label();
        cardClientes = new System.Windows.Forms.Panel();
        lblClientesDetalle = new System.Windows.Forms.Label();
        lblClientesValor = new System.Windows.Forms.Label();
        lblClientesTitulo = new System.Windows.Forms.Label();
        cardStockBajo = new System.Windows.Forms.Panel();
        lblStockBajoDetalle = new System.Windows.Forms.Label();
        lblStockBajoValor = new System.Windows.Forms.Label();
        lblStockBajoTitulo = new System.Windows.Forms.Label();
        tlpMedio = new System.Windows.Forms.TableLayoutPanel();
        cardGrafico = new System.Windows.Forms.Panel();
        panelGrafico = new System.Windows.Forms.Panel();
        lblGraficoTitulo = new System.Windows.Forms.Label();
        cardStockLista = new System.Windows.Forms.Panel();
        flowStock = new System.Windows.Forms.FlowLayoutPanel();
        lblStockListaTitulo = new System.Windows.Forms.Label();
        cardUltimas = new System.Windows.Forms.Panel();
        gridUltimas = new System.Windows.Forms.DataGridView();
        colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colFechaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
        lblSinVentas = new System.Windows.Forms.Label();
        lblUltimasTitulo = new System.Windows.Forms.Label();
        tlpTarjetas.SuspendLayout();
        cardVentasMes.SuspendLayout();
        cardVentasHoy.SuspendLayout();
        cardClientes.SuspendLayout();
        cardStockBajo.SuspendLayout();
        tlpMedio.SuspendLayout();
        cardGrafico.SuspendLayout();
        cardStockLista.SuspendLayout();
        cardUltimas.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridUltimas).BeginInit();
        SuspendLayout();
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(16, 24, 40);
        lblTitulo.Location = new System.Drawing.Point(26, 20);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Text = "Dashboard";
        //
        // lblFecha
        //
        lblFecha.AutoSize = true;
        lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lblFecha.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblFecha.Location = new System.Drawing.Point(28, 54);
        lblFecha.Name = "lblFecha";
        lblFecha.Text = "Resumen del negocio";
        //
        // tlpTarjetas
        //
        tlpTarjetas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        tlpTarjetas.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
        tlpTarjetas.ColumnCount = 4;
        tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpTarjetas.Controls.Add(cardVentasMes, 0, 0);
        tlpTarjetas.Controls.Add(cardVentasHoy, 1, 0);
        tlpTarjetas.Controls.Add(cardClientes, 2, 0);
        tlpTarjetas.Controls.Add(cardStockBajo, 3, 0);
        tlpTarjetas.Location = new System.Drawing.Point(26, 84);
        tlpTarjetas.Name = "tlpTarjetas";
        tlpTarjetas.RowCount = 1;
        tlpTarjetas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpTarjetas.Size = new System.Drawing.Size(978, 118);
        tlpTarjetas.TabIndex = 0;
        //
        // cardVentasMes
        //
        cardVentasMes.BackColor = System.Drawing.Color.White;
        cardVentasMes.Controls.Add(lblVentasMesDetalle);
        cardVentasMes.Controls.Add(lblVentasMesValor);
        cardVentasMes.Controls.Add(lblVentasMesTitulo);
        cardVentasMes.Dock = System.Windows.Forms.DockStyle.Fill;
        cardVentasMes.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
        cardVentasMes.Name = "cardVentasMes";
        cardVentasMes.Padding = new System.Windows.Forms.Padding(18, 14, 12, 10);
        //
        // lblVentasMesDetalle
        //
        lblVentasMesDetalle.Dock = System.Windows.Forms.DockStyle.Top;
        lblVentasMesDetalle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
        lblVentasMesDetalle.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblVentasMesDetalle.Name = "lblVentasMesDetalle";
        lblVentasMesDetalle.Size = new System.Drawing.Size(200, 20);
        lblVentasMesDetalle.Text = "operaciones este mes";
        //
        // lblVentasMesValor
        //
        lblVentasMesValor.Dock = System.Windows.Forms.DockStyle.Top;
        lblVentasMesValor.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
        lblVentasMesValor.ForeColor = System.Drawing.Color.FromArgb(5, 150, 105);
        lblVentasMesValor.Name = "lblVentasMesValor";
        lblVentasMesValor.Size = new System.Drawing.Size(200, 40);
        lblVentasMesValor.Text = "$ 0";
        //
        // lblVentasMesTitulo
        //
        lblVentasMesTitulo.Dock = System.Windows.Forms.DockStyle.Top;
        lblVentasMesTitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
        lblVentasMesTitulo.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblVentasMesTitulo.Name = "lblVentasMesTitulo";
        lblVentasMesTitulo.Size = new System.Drawing.Size(200, 20);
        lblVentasMesTitulo.Text = "VENTAS DEL MES";
        //
        // cardVentasHoy
        //
        cardVentasHoy.BackColor = System.Drawing.Color.White;
        cardVentasHoy.Controls.Add(lblVentasHoyDetalle);
        cardVentasHoy.Controls.Add(lblVentasHoyValor);
        cardVentasHoy.Controls.Add(lblVentasHoyTitulo);
        cardVentasHoy.Dock = System.Windows.Forms.DockStyle.Fill;
        cardVentasHoy.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
        cardVentasHoy.Name = "cardVentasHoy";
        cardVentasHoy.Padding = new System.Windows.Forms.Padding(18, 14, 12, 10);
        //
        // lblVentasHoyDetalle
        //
        lblVentasHoyDetalle.Dock = System.Windows.Forms.DockStyle.Top;
        lblVentasHoyDetalle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
        lblVentasHoyDetalle.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblVentasHoyDetalle.Name = "lblVentasHoyDetalle";
        lblVentasHoyDetalle.Size = new System.Drawing.Size(200, 20);
        lblVentasHoyDetalle.Text = "operaciones hoy";
        //
        // lblVentasHoyValor
        //
        lblVentasHoyValor.Dock = System.Windows.Forms.DockStyle.Top;
        lblVentasHoyValor.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
        lblVentasHoyValor.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229);
        lblVentasHoyValor.Name = "lblVentasHoyValor";
        lblVentasHoyValor.Size = new System.Drawing.Size(200, 40);
        lblVentasHoyValor.Text = "$ 0";
        //
        // lblVentasHoyTitulo
        //
        lblVentasHoyTitulo.Dock = System.Windows.Forms.DockStyle.Top;
        lblVentasHoyTitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
        lblVentasHoyTitulo.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblVentasHoyTitulo.Name = "lblVentasHoyTitulo";
        lblVentasHoyTitulo.Size = new System.Drawing.Size(200, 20);
        lblVentasHoyTitulo.Text = "VENTAS DE HOY";
        //
        // cardClientes
        //
        cardClientes.BackColor = System.Drawing.Color.White;
        cardClientes.Controls.Add(lblClientesDetalle);
        cardClientes.Controls.Add(lblClientesValor);
        cardClientes.Controls.Add(lblClientesTitulo);
        cardClientes.Dock = System.Windows.Forms.DockStyle.Fill;
        cardClientes.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
        cardClientes.Name = "cardClientes";
        cardClientes.Padding = new System.Windows.Forms.Padding(18, 14, 12, 10);
        //
        // lblClientesDetalle
        //
        lblClientesDetalle.Dock = System.Windows.Forms.DockStyle.Top;
        lblClientesDetalle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
        lblClientesDetalle.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblClientesDetalle.Name = "lblClientesDetalle";
        lblClientesDetalle.Size = new System.Drawing.Size(200, 20);
        lblClientesDetalle.Text = "registrados en el sistema";
        //
        // lblClientesValor
        //
        lblClientesValor.Dock = System.Windows.Forms.DockStyle.Top;
        lblClientesValor.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
        lblClientesValor.ForeColor = System.Drawing.Color.FromArgb(16, 24, 40);
        lblClientesValor.Name = "lblClientesValor";
        lblClientesValor.Size = new System.Drawing.Size(200, 40);
        lblClientesValor.Text = "0";
        //
        // lblClientesTitulo
        //
        lblClientesTitulo.Dock = System.Windows.Forms.DockStyle.Top;
        lblClientesTitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
        lblClientesTitulo.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblClientesTitulo.Name = "lblClientesTitulo";
        lblClientesTitulo.Size = new System.Drawing.Size(200, 20);
        lblClientesTitulo.Text = "CLIENTES ACTIVOS";
        //
        // cardStockBajo
        //
        cardStockBajo.BackColor = System.Drawing.Color.White;
        cardStockBajo.Controls.Add(lblStockBajoDetalle);
        cardStockBajo.Controls.Add(lblStockBajoValor);
        cardStockBajo.Controls.Add(lblStockBajoTitulo);
        cardStockBajo.Dock = System.Windows.Forms.DockStyle.Fill;
        cardStockBajo.Margin = new System.Windows.Forms.Padding(0);
        cardStockBajo.Name = "cardStockBajo";
        cardStockBajo.Padding = new System.Windows.Forms.Padding(18, 14, 12, 10);
        //
        // lblStockBajoDetalle
        //
        lblStockBajoDetalle.Dock = System.Windows.Forms.DockStyle.Top;
        lblStockBajoDetalle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
        lblStockBajoDetalle.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblStockBajoDetalle.Name = "lblStockBajoDetalle";
        lblStockBajoDetalle.Size = new System.Drawing.Size(200, 20);
        lblStockBajoDetalle.Text = "productos requieren reposición";
        //
        // lblStockBajoValor
        //
        lblStockBajoValor.Dock = System.Windows.Forms.DockStyle.Top;
        lblStockBajoValor.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
        lblStockBajoValor.ForeColor = System.Drawing.Color.FromArgb(225, 29, 72);
        lblStockBajoValor.Name = "lblStockBajoValor";
        lblStockBajoValor.Size = new System.Drawing.Size(200, 40);
        lblStockBajoValor.Text = "0";
        //
        // lblStockBajoTitulo
        //
        lblStockBajoTitulo.Dock = System.Windows.Forms.DockStyle.Top;
        lblStockBajoTitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
        lblStockBajoTitulo.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblStockBajoTitulo.Name = "lblStockBajoTitulo";
        lblStockBajoTitulo.Size = new System.Drawing.Size(200, 20);
        lblStockBajoTitulo.Text = "STOCK BAJO";
        //
        // tlpMedio
        //
        tlpMedio.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        tlpMedio.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
        tlpMedio.ColumnCount = 2;
        tlpMedio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
        tlpMedio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
        tlpMedio.Controls.Add(cardGrafico, 0, 0);
        tlpMedio.Controls.Add(cardStockLista, 1, 0);
        tlpMedio.Location = new System.Drawing.Point(26, 218);
        tlpMedio.Name = "tlpMedio";
        tlpMedio.RowCount = 1;
        tlpMedio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMedio.Size = new System.Drawing.Size(978, 300);
        tlpMedio.TabIndex = 1;
        //
        // cardGrafico
        //
        cardGrafico.BackColor = System.Drawing.Color.White;
        cardGrafico.Controls.Add(panelGrafico);
        cardGrafico.Controls.Add(lblGraficoTitulo);
        cardGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
        cardGrafico.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
        cardGrafico.Name = "cardGrafico";
        cardGrafico.Padding = new System.Windows.Forms.Padding(20);
        //
        // panelGrafico
        //
        panelGrafico.BackColor = System.Drawing.Color.White;
        panelGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
        panelGrafico.Name = "panelGrafico";
        //
        // lblGraficoTitulo
        //
        lblGraficoTitulo.Dock = System.Windows.Forms.DockStyle.Top;
        lblGraficoTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
        lblGraficoTitulo.ForeColor = System.Drawing.Color.FromArgb(16, 24, 40);
        lblGraficoTitulo.Name = "lblGraficoTitulo";
        lblGraficoTitulo.Size = new System.Drawing.Size(200, 30);
        lblGraficoTitulo.Text = "Ventas por Día (Últimos 7 días)";
        //
        // cardStockLista
        //
        cardStockLista.BackColor = System.Drawing.Color.White;
        cardStockLista.Controls.Add(flowStock);
        cardStockLista.Controls.Add(lblStockListaTitulo);
        cardStockLista.Dock = System.Windows.Forms.DockStyle.Fill;
        cardStockLista.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
        cardStockLista.Name = "cardStockLista";
        cardStockLista.Padding = new System.Windows.Forms.Padding(20);
        //
        // flowStock
        //
        flowStock.AutoScroll = true;
        flowStock.BackColor = System.Drawing.Color.White;
        flowStock.Dock = System.Windows.Forms.DockStyle.Fill;
        flowStock.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowStock.Name = "flowStock";
        flowStock.WrapContents = false;
        //
        // lblStockListaTitulo
        //
        lblStockListaTitulo.Dock = System.Windows.Forms.DockStyle.Top;
        lblStockListaTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
        lblStockListaTitulo.ForeColor = System.Drawing.Color.FromArgb(16, 24, 40);
        lblStockListaTitulo.Name = "lblStockListaTitulo";
        lblStockListaTitulo.Size = new System.Drawing.Size(200, 30);
        lblStockListaTitulo.Text = "⚠ Productos con Stock Bajo";
        //
        // cardUltimas
        //
        cardUltimas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        cardUltimas.BackColor = System.Drawing.Color.White;
        cardUltimas.Controls.Add(gridUltimas);
        cardUltimas.Controls.Add(lblSinVentas);
        cardUltimas.Controls.Add(lblUltimasTitulo);
        cardUltimas.Location = new System.Drawing.Point(26, 534);
        cardUltimas.Name = "cardUltimas";
        cardUltimas.Padding = new System.Windows.Forms.Padding(20);
        cardUltimas.Size = new System.Drawing.Size(978, 330);
        cardUltimas.TabIndex = 2;
        //
        // gridUltimas
        //
        gridUltimas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colNumero, colFechaVenta, colCliente, colFormaPago, colTotal });
        gridUltimas.Dock = System.Windows.Forms.DockStyle.Fill;
        gridUltimas.Name = "gridUltimas";
        gridUltimas.TabIndex = 0;
        //
        // colNumero
        //
        colNumero.DataPropertyName = "Numero";
        colNumero.FillWeight = 12F;
        colNumero.HeaderText = "N°";
        colNumero.Name = "colNumero";
        //
        // colFechaVenta
        //
        colFechaVenta.DataPropertyName = "Fecha";
        colFechaVenta.FillWeight = 16F;
        colFechaVenta.HeaderText = "Fecha";
        colFechaVenta.Name = "colFechaVenta";
        //
        // colCliente
        //
        colCliente.DataPropertyName = "Cliente";
        colCliente.FillWeight = 34F;
        colCliente.HeaderText = "Cliente";
        colCliente.Name = "colCliente";
        //
        // colFormaPago
        //
        colFormaPago.DataPropertyName = "FormaPago";
        colFormaPago.FillWeight = 20F;
        colFormaPago.HeaderText = "Forma de Pago";
        colFormaPago.Name = "colFormaPago";
        //
        // colTotal
        //
        colTotal.DataPropertyName = "Total";
        colTotal.FillWeight = 18F;
        colTotal.HeaderText = "Total";
        colTotal.Name = "colTotal";
        //
        // lblSinVentas
        //
        lblSinVentas.Dock = System.Windows.Forms.DockStyle.Fill;
        lblSinVentas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lblSinVentas.ForeColor = System.Drawing.Color.FromArgb(102, 112, 133);
        lblSinVentas.Name = "lblSinVentas";
        lblSinVentas.Text = "Todavía no se registraron ventas. Usá el módulo «Registrar Venta» para cargar la primera.";
        lblSinVentas.Visible = false;
        //
        // lblUltimasTitulo
        //
        lblUltimasTitulo.Dock = System.Windows.Forms.DockStyle.Top;
        lblUltimasTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
        lblUltimasTitulo.ForeColor = System.Drawing.Color.FromArgb(16, 24, 40);
        lblUltimasTitulo.Name = "lblUltimasTitulo";
        lblUltimasTitulo.Size = new System.Drawing.Size(200, 30);
        lblUltimasTitulo.Text = "Últimas Ventas";
        //
        // DashboardView
        //
        AutoScroll = true;
        BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
        Controls.Add(lblTitulo);
        Controls.Add(lblFecha);
        Controls.Add(tlpTarjetas);
        Controls.Add(tlpMedio);
        Controls.Add(cardUltimas);
        Name = "DashboardView";
        Size = new System.Drawing.Size(1030, 890);
        tlpTarjetas.ResumeLayout(false);
        cardVentasMes.ResumeLayout(false);
        cardVentasHoy.ResumeLayout(false);
        cardClientes.ResumeLayout(false);
        cardStockBajo.ResumeLayout(false);
        tlpMedio.ResumeLayout(false);
        cardGrafico.ResumeLayout(false);
        cardStockLista.ResumeLayout(false);
        cardUltimas.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridUltimas).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.Label lblFecha;
    private System.Windows.Forms.TableLayoutPanel tlpTarjetas;
    private System.Windows.Forms.Panel cardVentasMes;
    private System.Windows.Forms.Label lblVentasMesDetalle;
    private System.Windows.Forms.Label lblVentasMesValor;
    private System.Windows.Forms.Label lblVentasMesTitulo;
    private System.Windows.Forms.Panel cardVentasHoy;
    private System.Windows.Forms.Label lblVentasHoyDetalle;
    private System.Windows.Forms.Label lblVentasHoyValor;
    private System.Windows.Forms.Label lblVentasHoyTitulo;
    private System.Windows.Forms.Panel cardClientes;
    private System.Windows.Forms.Label lblClientesDetalle;
    private System.Windows.Forms.Label lblClientesValor;
    private System.Windows.Forms.Label lblClientesTitulo;
    private System.Windows.Forms.Panel cardStockBajo;
    private System.Windows.Forms.Label lblStockBajoDetalle;
    private System.Windows.Forms.Label lblStockBajoValor;
    private System.Windows.Forms.Label lblStockBajoTitulo;
    private System.Windows.Forms.TableLayoutPanel tlpMedio;
    private System.Windows.Forms.Panel cardGrafico;
    private System.Windows.Forms.Panel panelGrafico;
    private System.Windows.Forms.Label lblGraficoTitulo;
    private System.Windows.Forms.Panel cardStockLista;
    private System.Windows.Forms.FlowLayoutPanel flowStock;
    private System.Windows.Forms.Label lblStockListaTitulo;
    private System.Windows.Forms.Panel cardUltimas;
    private System.Windows.Forms.DataGridView gridUltimas;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
    private System.Windows.Forms.DataGridViewTextBoxColumn colFechaVenta;
    private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
    private System.Windows.Forms.DataGridViewTextBoxColumn colFormaPago;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    private System.Windows.Forms.Label lblSinVentas;
    private System.Windows.Forms.Label lblUltimasTitulo;
}
