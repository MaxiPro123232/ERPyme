namespace ERPyME.WinForms.Vistas;

partial class AuditoriaView
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
        gridAuditoria = new System.Windows.Forms.DataGridView();
        colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
        panelBarra = new System.Windows.Forms.Panel();
        lblTitulo = new System.Windows.Forms.Label();
        lblSubtitulo = new System.Windows.Forms.Label();
        btnActualizar = new System.Windows.Forms.Button();
        cardGrilla.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridAuditoria).BeginInit();
        panelBarra.SuspendLayout();
        SuspendLayout();
        //
        // cardGrilla
        //
        cardGrilla.BackColor = System.Drawing.Color.White;
        cardGrilla.Controls.Add(gridAuditoria);
        cardGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
        cardGrilla.Location = new System.Drawing.Point(26, 96);
        cardGrilla.Name = "cardGrilla";
        cardGrilla.Padding = new System.Windows.Forms.Padding(1);
        cardGrilla.Size = new System.Drawing.Size(978, 604);
        cardGrilla.TabIndex = 0;
        //
        // gridAuditoria
        //
        gridAuditoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colFechaHora, colUsuario, colAccion, colDetalle });
        gridAuditoria.Dock = System.Windows.Forms.DockStyle.Fill;
        gridAuditoria.Location = new System.Drawing.Point(1, 1);
        gridAuditoria.Name = "gridAuditoria";
        gridAuditoria.Size = new System.Drawing.Size(976, 602);
        gridAuditoria.TabIndex = 0;
        //
        // colFechaHora
        //
        colFechaHora.DataPropertyName = "FechaHora";
        colFechaHora.FillWeight = 16F;
        colFechaHora.HeaderText = "Fecha y Hora";
        colFechaHora.Name = "colFechaHora";
        //
        // colUsuario
        //
        colUsuario.DataPropertyName = "Usuario";
        colUsuario.FillWeight = 13F;
        colUsuario.HeaderText = "Usuario";
        colUsuario.Name = "colUsuario";
        //
        // colAccion
        //
        colAccion.DataPropertyName = "Accion";
        colAccion.FillWeight = 21F;
        colAccion.HeaderText = "Acción";
        colAccion.Name = "colAccion";
        //
        // colDetalle
        //
        colDetalle.DataPropertyName = "Detalle";
        colDetalle.FillWeight = 50F;
        colDetalle.HeaderText = "Detalle";
        colDetalle.Name = "colDetalle";
        //
        // panelBarra
        //
        panelBarra.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
        panelBarra.Controls.Add(lblTitulo);
        panelBarra.Controls.Add(lblSubtitulo);
        panelBarra.Controls.Add(btnActualizar);
        panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
        panelBarra.Location = new System.Drawing.Point(26, 20);
        panelBarra.Name = "panelBarra";
        panelBarra.Size = new System.Drawing.Size(978, 76);
        panelBarra.TabIndex = 1;
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
        lblTitulo.Location = new System.Drawing.Point(0, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Text = "Auditoría / Historial";
        //
        // lblSubtitulo
        //
        lblSubtitulo.AutoSize = true;
        lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
        lblSubtitulo.Location = new System.Drawing.Point(2, 32);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Text = "Registro de acciones críticas con usuario, fecha y detalle (RF28 / RNF07)";
        //
        // btnActualizar
        //
        btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnActualizar.Location = new System.Drawing.Point(848, 8);
        btnActualizar.Name = "btnActualizar";
        btnActualizar.Size = new System.Drawing.Size(130, 34);
        btnActualizar.TabIndex = 0;
        btnActualizar.Text = "⟳  Actualizar";
        btnActualizar.Click += BtnActualizar_Click;
        //
        // AuditoriaView
        //
        BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
        Controls.Add(cardGrilla);
        Controls.Add(panelBarra);
        Name = "AuditoriaView";
        Padding = new System.Windows.Forms.Padding(26, 20, 26, 20);
        Size = new System.Drawing.Size(1030, 720);
        cardGrilla.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridAuditoria).EndInit();
        panelBarra.ResumeLayout(false);
        panelBarra.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel cardGrilla;
    private System.Windows.Forms.DataGridView gridAuditoria;
    private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
    private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
    private System.Windows.Forms.DataGridViewTextBoxColumn colAccion;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDetalle;
    private System.Windows.Forms.Panel panelBarra;
    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.Label lblSubtitulo;
    private System.Windows.Forms.Button btnActualizar;
}
