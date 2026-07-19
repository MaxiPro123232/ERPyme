using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ERPyME.WinForms.Controladoras;
using ERPyME.WinForms.Ui;

namespace ERPyME.WinForms.Vistas;

/// <summary>Vista del dashboard (RF27). Los datos vienen de ControladoraDashboard.</summary>
public partial class DashboardView : UserControl
{
    private List<VentaDia> _dias = new();

    public DashboardView()
    {
        InitializeComponent();

        Estilos.EstilizarCard(cardVentasMes);
        Estilos.EstilizarCard(cardVentasHoy);
        Estilos.EstilizarCard(cardClientes);
        Estilos.EstilizarCard(cardStockBajo);
        Estilos.EstilizarCard(cardGrafico);
        Estilos.EstilizarCard(cardStockLista);
        Estilos.EstilizarCard(cardUltimas);
        Estilos.EstilizarGrilla(gridUltimas);
        colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        panelGrafico.Paint += PanelGrafico_Paint;
        panelGrafico.Resize += (s, e) => panelGrafico.Invalidate();

        var cultura = new CultureInfo("es-AR");
        lblFecha.Text = "Resumen del negocio · " +
            DateTime.Now.ToString("dddd d 'de' MMMM 'de' yyyy", cultura);

        Cargar();
    }

    private void Cargar()
    {
        var datos = new ControladoraDashboard().Obtener();
        _dias = datos.VentasPorDia;

        lblVentasMesValor.Text = $"$ {datos.VentasMesTotal:N0}";
        lblVentasMesDetalle.Text = $"{datos.VentasMesCantidad} operaciones este mes";
        lblVentasHoyValor.Text = $"$ {datos.VentasHoyTotal:N0}";
        lblVentasHoyDetalle.Text = $"{datos.VentasHoyCantidad} operaciones hoy";
        lblClientesValor.Text = datos.ClientesActivos.ToString();
        lblStockBajoValor.Text = datos.ProductosBajoStock.Count.ToString();

        // Lista de productos con stock bajo
        flowStock.Controls.Clear();
        if (datos.ProductosBajoStock.Count == 0)
        {
            flowStock.Controls.Add(new Label
            {
                Text = "No hay productos con stock bajo 🎉",
                ForeColor = Paleta.TextoSuave,
                AutoSize = true
            });
        }
        foreach (var p in datos.ProductosBajoStock.Take(6))
        {
            flowStock.Controls.Add(new Label
            {
                Text = $"{p.Nombre}   ({p.Codigo})",
                Font = new Font("Segoe UI Semibold", 9f),
                ForeColor = Paleta.Texto,
                AutoSize = true,
                Margin = new Padding(0, 6, 0, 0)
            });
            flowStock.Controls.Add(new Label
            {
                Text = $"Stock: {p.StockActual} · mínimo: {p.StockMinimo}",
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Paleta.Rojo,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 4)
            });
        }

        // Últimas ventas
        gridUltimas.DataSource = datos.UltimasVentas;
        var hayVentas = datos.UltimasVentas.Count > 0;
        gridUltimas.Visible = hayVentas;
        lblSinVentas.Visible = !hayVentas;

        panelGrafico.Invalidate();
    }

    private void PanelGrafico_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        var area = panelGrafico.ClientRectangle;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        if (_dias.Count == 0) return;
        var max = Math.Max(_dias.Max(d => d.Monto), 1);

        int margenInf = 26, margenSup = 22;
        int anchoCol = area.Width / _dias.Count;
        int anchoBarra = Math.Min(Math.Max(anchoCol - 26, 12), 44);
        int altoUtil = area.Height - margenInf - margenSup;

        using var fEtiqueta = new Font("Segoe UI", 8f);
        using var fMonto = new Font("Segoe UI Semibold", 7.75f);
        using var brochaEtiqueta = new SolidBrush(Paleta.TextoSuave);
        using var formato = new StringFormat { Alignment = StringAlignment.Center };

        // líneas de guía horizontales sutiles
        using (var lapizGuia = new Pen(Color.FromArgb(243, 244, 246)))
        {
            for (int linea = 1; linea <= 3; linea++)
            {
                int yGuia = area.Bottom - margenInf - altoUtil * linea / 3;
                g.DrawLine(lapizGuia, area.X, yGuia, area.Right, yGuia);
            }
        }
        using (var lapizBase = new Pen(Paleta.Borde))
            g.DrawLine(lapizBase, area.X, area.Bottom - margenInf, area.Right, area.Bottom - margenInf);

        for (int i = 0; i < _dias.Count; i++)
        {
            var d = _dias[i];
            int alto = (int)(altoUtil * (double)(d.Monto / max));
            if (alto < 3) alto = 3;
            int x = area.X + i * anchoCol + (anchoCol - anchoBarra) / 2;
            int y = area.Bottom - margenInf - alto;

            // barra con la parte superior redondeada
            int radio = Math.Min(6, alto / 2);
            using var camino = new System.Drawing.Drawing2D.GraphicsPath();
            camino.AddArc(x, y, radio * 2, radio * 2, 180, 90);
            camino.AddArc(x + anchoBarra - radio * 2, y, radio * 2, radio * 2, 270, 90);
            camino.AddLine(x + anchoBarra, area.Bottom - margenInf, x, area.Bottom - margenInf);
            camino.CloseFigure();
            using var brochaBarra = new SolidBrush(d.Monto > 0 ? Paleta.Acento : Paleta.Borde);
            g.FillPath(brochaBarra, camino);

            var centro = area.X + i * anchoCol + anchoCol / 2f;
            if (d.Monto > 0)
                g.DrawString($"$ {d.Monto / 1000:N0}k", fMonto, brochaEtiqueta, centro, y - 17, formato);
            g.DrawString(d.Etiqueta, fEtiqueta, brochaEtiqueta, centro, area.Bottom - margenInf + 7, formato);
        }
    }
}
