namespace ERPyME.WinForms.Vistas;

partial class PlaceholderView
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
        cardCentro = new System.Windows.Forms.Panel();
        lblIcono = new System.Windows.Forms.Label();
        lblModulo = new System.Windows.Forms.Label();
        lblEstado = new System.Windows.Forms.Label();
        lblRequerimiento = new System.Windows.Forms.Label();
        cardCentro.SuspendLayout();
        SuspendLayout();
        //
        // cardCentro
        //
        cardCentro.BackColor = System.Drawing.Color.White;
        cardCentro.Controls.Add(lblIcono);
        cardCentro.Controls.Add(lblModulo);
        cardCentro.Controls.Add(lblEstado);
        cardCentro.Controls.Add(lblRequerimiento);
        cardCentro.Location = new System.Drawing.Point(275, 235);
        cardCentro.Name = "cardCentro";
        cardCentro.Size = new System.Drawing.Size(480, 250);
        cardCentro.TabIndex = 0;
        //
        // lblIcono
        //
        lblIcono.Font = new System.Drawing.Font("Segoe UI Emoji", 30F);
        lblIcono.Location = new System.Drawing.Point(20, 26);
        lblIcono.Name = "lblIcono";
        lblIcono.Size = new System.Drawing.Size(440, 64);
        lblIcono.Text = "🚧";
        lblIcono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // lblModulo
        //
        lblModulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblModulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
        lblModulo.Location = new System.Drawing.Point(20, 96);
        lblModulo.Name = "lblModulo";
        lblModulo.Size = new System.Drawing.Size(440, 32);
        lblModulo.Text = "Módulo";
        lblModulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // lblEstado
        //
        lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lblEstado.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
        lblEstado.Location = new System.Drawing.Point(20, 130);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new System.Drawing.Size(440, 24);
        lblEstado.Text = "Módulo en desarrollo";
        lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // lblRequerimiento
        //
        lblRequerimiento.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
        lblRequerimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
        lblRequerimiento.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
        lblRequerimiento.Location = new System.Drawing.Point(70, 170);
        lblRequerimiento.Name = "lblRequerimiento";
        lblRequerimiento.Size = new System.Drawing.Size(340, 30);
        lblRequerimiento.Text = "Previsto en la especificación";
        lblRequerimiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // PlaceholderView
        //
        BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
        Controls.Add(cardCentro);
        Name = "PlaceholderView";
        Size = new System.Drawing.Size(1030, 720);
        cardCentro.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel cardCentro;
    private System.Windows.Forms.Label lblIcono;
    private System.Windows.Forms.Label lblModulo;
    private System.Windows.Forms.Label lblEstado;
    private System.Windows.Forms.Label lblRequerimiento;
}
