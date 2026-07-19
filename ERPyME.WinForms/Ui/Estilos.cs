using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ERPyME.WinForms.Ui;

/// <summary>Paleta de colores del sistema (RNF12: consistencia visual).</summary>
public static class Paleta
{
    public static readonly Color Sidebar = Color.FromArgb(16, 24, 40);        // #101828
    public static readonly Color SidebarHover = Color.FromArgb(30, 41, 59);   // #1E293B
    public static readonly Color SidebarActivo = Color.FromArgb(79, 70, 229); // #4F46E5
    public static readonly Color Acento = Color.FromArgb(79, 70, 229);        // indigo 600
    public static readonly Color AcentoOscuro = Color.FromArgb(67, 56, 202);  // indigo 700
    public static readonly Color AcentoClaro = Color.FromArgb(238, 242, 255); // indigo 50
    public static readonly Color Verde = Color.FromArgb(5, 150, 105);         // emerald 600
    public static readonly Color VerdeClaro = Color.FromArgb(236, 253, 245);  // emerald 50
    public static readonly Color Rojo = Color.FromArgb(225, 29, 72);          // rose 600
    public static readonly Color RojoClaro = Color.FromArgb(255, 241, 242);   // rose 50
    public static readonly Color Naranja = Color.FromArgb(234, 88, 12);       // orange 600
    public static readonly Color NaranjaClaro = Color.FromArgb(255, 247, 237);// orange 50
    public static readonly Color Fondo = Color.FromArgb(248, 249, 252);
    public static readonly Color Carta = Color.White;
    public static readonly Color Borde = Color.FromArgb(229, 231, 235);       // gray 200
    public static readonly Color Texto = Color.FromArgb(16, 24, 40);          // gray 900
    public static readonly Color TextoSuave = Color.FromArgb(102, 112, 133);  // gray 500
    public static readonly Color GrisClaro = Color.FromArgb(152, 162, 179);   // gray 400
    public static readonly Color EncabezadoGrilla = Color.FromArgb(249, 250, 251);
    public static readonly Color FilaHover = Color.FromArgb(249, 250, 251);
}

/// <summary>
/// Estilizadores del sistema de diseño. Los botones y tarjetas se pintan a mano
/// (esquinas redondeadas antialiased) y el hover se anima con ease-out corto;
/// la presión da feedback instantáneo.
/// </summary>
public static class Estilos
{
    // ================= utilitarios de dibujo =================

    private static GraphicsPath Redondear(Rectangle r, int radio)
    {
        var path = new GraphicsPath();
        int d = radio * 2;
        path.AddArc(r.X, r.Y, d, d, 180, 90);
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }

    private static Color Mezclar(Color desde, Color hasta, double t)
    {
        t = Math.Clamp(t, 0, 1);
        return Color.FromArgb(
            (int)(desde.R + (hasta.R - desde.R) * t),
            (int)(desde.G + (hasta.G - desde.G) * t),
            (int)(desde.B + (hasta.B - desde.B) * t));
    }

    /// <summary>Estado de animación de color por botón.</summary>
    private class EstadoAnimado
    {
        public Color Actual, Origen, Destino;
        public double T = 1;
        public System.Windows.Forms.Timer? Timer;
        public bool Hover, Activo;
    }

    private static readonly Dictionary<Control, EstadoAnimado> _estados = new();

    private static EstadoAnimado Estado(Control c, Color inicial)
    {
        if (!_estados.TryGetValue(c, out var e))
        {
            e = new EstadoAnimado { Actual = inicial, Origen = inicial, Destino = inicial };
            _estados[c] = e;
            c.Disposed += (s, _) => { e.Timer?.Dispose(); _estados.Remove(c); };
        }
        return e;
    }

    /// <summary>Anima el color de fondo hacia un destino con ease-out (~140 ms).</summary>
    private static void AnimarHacia(Control c, EstadoAnimado e, Color destino, bool instantaneo = false)
    {
        if (instantaneo)
        {
            e.Timer?.Stop();
            e.Actual = e.Origen = e.Destino = destino;
            e.T = 1;
            c.Invalidate();
            return;
        }

        e.Origen = e.Actual;
        e.Destino = destino;
        e.T = 0;
        if (e.Timer is null)
        {
            e.Timer = new System.Windows.Forms.Timer { Interval = 15 };
            e.Timer.Tick += (s, _) =>
            {
                e.T += 15.0 / 140.0;
                var eased = 1 - Math.Pow(1 - Math.Min(e.T, 1), 3); // ease-out cúbico
                e.Actual = Mezclar(e.Origen, e.Destino, eased);
                c.Invalidate();
                if (e.T >= 1) e.Timer!.Stop();
            };
        }
        e.Timer.Stop();
        e.Timer.Start();
    }

    // ================= botones =================

    /// <summary>Botón moderno: esquinas redondeadas, hover animado, presión instantánea.</summary>
    public static void EstilizarBoton(Button b, Color fondo, Color? frente = null, int radio = 8)
    {
        var hover = Mezclar(fondo, Color.White, 0.10);
        var presion = Mezclar(fondo, Color.Black, 0.10);
        if (fondo == Paleta.Borde) // botón gris: hover apenas más oscuro
        {
            hover = Mezclar(fondo, Color.Black, 0.05);
            presion = Mezclar(fondo, Color.Black, 0.12);
        }

        b.FlatStyle = FlatStyle.Flat;
        b.FlatAppearance.BorderSize = 0;
        b.FlatAppearance.MouseOverBackColor = fondo;
        b.FlatAppearance.MouseDownBackColor = fondo;
        b.BackColor = fondo;
        b.ForeColor = frente ?? Color.White;
        b.Font = new Font("Segoe UI Semibold", 9.5f);
        b.Cursor = Cursors.Hand;
        b.UseVisualStyleBackColor = false;
        b.TabStop = false;

        var e = Estado(b, fondo);

        b.Paint += (s, pe) =>
        {
            var g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var bg = new SolidBrush(b.Parent?.BackColor ?? Paleta.Fondo))
                g.FillRectangle(bg, b.ClientRectangle);
            using var path = Redondear(new Rectangle(0, 0, b.Width - 1, b.Height - 1), radio);
            using var brocha = new SolidBrush(e.Actual);
            g.FillPath(brocha, path);
            TextRenderer.DrawText(g, b.Text, b.Font, b.ClientRectangle, b.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        };
        b.MouseEnter += (s, _) => { e.Hover = true; AnimarHacia(b, e, hover); };
        b.MouseLeave += (s, _) => { e.Hover = false; AnimarHacia(b, e, fondo); };
        b.MouseDown += (s, _) => AnimarHacia(b, e, presion, instantaneo: true); // feedback inmediato
        b.MouseUp += (s, _) => AnimarHacia(b, e, e.Hover ? hover : fondo);
    }

    public static void EstilizarBotonPrimario(Button b) => EstilizarBoton(b, Paleta.Acento);
    public static void EstilizarBotonVerde(Button b) => EstilizarBoton(b, Paleta.Verde);
    public static void EstilizarBotonRojo(Button b) => EstilizarBoton(b, Paleta.Rojo);
    public static void EstilizarBotonGris(Button b) => EstilizarBoton(b, Paleta.Borde, Paleta.Texto);

    // ================= navegación lateral =================

    /// <summary>Botón de navegación de la sidebar: pill redondeado con margen, hover animado.</summary>
    public static void EstilizarBotonNav(Button b)
    {
        b.FlatStyle = FlatStyle.Flat;
        b.FlatAppearance.BorderSize = 0;
        b.FlatAppearance.MouseOverBackColor = Paleta.Sidebar;
        b.FlatAppearance.MouseDownBackColor = Paleta.Sidebar;
        b.BackColor = Paleta.Sidebar;
        b.ForeColor = Color.FromArgb(152, 162, 179);
        b.Font = new Font("Segoe UI", 9.75f);
        b.Cursor = Cursors.Hand;
        b.UseVisualStyleBackColor = false;
        b.TabStop = false;

        var e = Estado(b, Paleta.Sidebar);

        b.Paint += (s, pe) =>
        {
            var g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var bg = new SolidBrush(Paleta.Sidebar))
                g.FillRectangle(bg, b.ClientRectangle);

            var pill = new Rectangle(10, 3, b.Width - 20, b.Height - 6);
            var color = e.Activo ? Paleta.SidebarActivo : e.Actual;
            if (color != Paleta.Sidebar)
            {
                using var path = Redondear(pill, 8);
                using var brocha = new SolidBrush(color);
                g.FillPath(brocha, path);
            }

            var fg = e.Activo ? Color.White : (e.Hover ? Color.White : Color.FromArgb(152, 162, 179));
            var fuente = e.Activo ? new Font("Segoe UI Semibold", 9.75f) : b.Font;
            TextRenderer.DrawText(g, b.Text, fuente, new Rectangle(24, 0, b.Width - 24, b.Height), fg,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        };
        b.MouseEnter += (s, _) => { e.Hover = true; if (!e.Activo) AnimarHacia(b, e, Paleta.SidebarHover); };
        b.MouseLeave += (s, _) => { e.Hover = false; if (!e.Activo) AnimarHacia(b, e, Paleta.Sidebar); };
    }

    /// <summary>Marca el pill activo del menú (y desmarca el anterior).</summary>
    public static void MarcarNavActivo(Button? anterior, Button nuevo)
    {
        if (anterior is not null && _estados.TryGetValue(anterior, out var ea))
        {
            ea.Activo = false;
            AnimarHacia(anterior, ea, Paleta.Sidebar, instantaneo: true);
        }
        var e = Estado(nuevo, Paleta.Sidebar);
        e.Activo = true;
        nuevo.Invalidate();
    }

    // ================= combos =================

    /// <summary>ComboBox visible sobre fondos blancos: fondo gris muy claro y borde propio
    /// pintado sobre el contenedor (con foco, el borde pasa al color de acento).</summary>
    public static void EstilizarCombo(ComboBox c)
    {
        c.FlatStyle = FlatStyle.Flat;
        c.BackColor = Color.FromArgb(242, 244, 247);
        c.ForeColor = Paleta.Texto;
        var padre = c.Parent;
        if (padre is null) return;

        padre.Paint += (s, e) =>
        {
            var r = new Rectangle(c.Left - 1, c.Top - 1, c.Width + 1, c.Height + 1);
            using var pen = new Pen(c.Focused ? Paleta.Acento : Color.FromArgb(203, 213, 225));
            e.Graphics.DrawRectangle(pen, r);
        };
        void Repintar(object? s, EventArgs e) => padre.Invalidate();
        c.GotFocus += Repintar;
        c.LostFocus += Repintar;
        c.LocationChanged += Repintar;
        c.SizeChanged += Repintar;
    }

    // ================= tarjetas =================

    /// <summary>Tarjeta blanca con esquinas redondeadas, borde fino y sombra suave.</summary>
    public static void EstilizarCard(Panel p, int radio = 12)
    {
        p.BackColor = Paleta.Carta;
        p.Paint += (s, e) =>
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // fondo del contenedor visible en las esquinas
            using (var fondo = new SolidBrush(p.Parent?.BackColor ?? Paleta.Fondo))
                g.FillRectangle(fondo, p.ClientRectangle);

            var r = new Rectangle(0, 0, p.Width - 1, p.Height - 3);

            // sombra suave debajo
            using (var sombra1 = Redondear(new Rectangle(r.X + 1, r.Y + 2, r.Width - 2, r.Height), radio))
            using (var bs1 = new SolidBrush(Color.FromArgb(14, 16, 24, 40)))
                g.FillPath(bs1, sombra1);
            using (var sombra2 = Redondear(new Rectangle(r.X + 2, r.Y + 3, r.Width - 4, r.Height), radio))
            using (var bs2 = new SolidBrush(Color.FromArgb(10, 16, 24, 40)))
                g.FillPath(bs2, sombra2);

            using var path = Redondear(r, radio);
            using (var blanco = new SolidBrush(Paleta.Carta))
                g.FillPath(blanco, path);
            using var pen = new Pen(Paleta.Borde);
            g.DrawPath(pen, path);
        };
        p.Resize += (s, e) => p.Invalidate();
    }

    // ================= grillas =================

    /// <summary>Grilla moderna: encabezado limpio, filas altas, hover, badges de estado (RNF12).</summary>
    public static void EstilizarGrilla(DataGridView g)
    {
        g.BackgroundColor = Color.White;
        g.BorderStyle = BorderStyle.None;
        g.RowHeadersVisible = false;
        g.AllowUserToAddRows = false;
        g.AllowUserToDeleteRows = false;
        g.AllowUserToResizeRows = false;
        g.AllowUserToOrderColumns = false;
        g.ReadOnly = true;
        g.AutoGenerateColumns = false;
        g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        g.MultiSelect = false;
        g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        g.GridColor = Color.FromArgb(243, 244, 246);
        g.EnableHeadersVisualStyles = false;
        g.ColumnHeadersHeight = 44;
        g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        g.Font = new Font("Segoe UI", 9.5f);
        g.RowTemplate.Height = 44;

        g.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Paleta.EncabezadoGrilla,
            SelectionBackColor = Paleta.EncabezadoGrilla,
            ForeColor = Paleta.TextoSuave,
            Font = new Font("Segoe UI Semibold", 8.75f),
            Padding = new Padding(10, 0, 0, 0),
            Alignment = DataGridViewContentAlignment.MiddleLeft
        };
        g.DefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.White,
            ForeColor = Paleta.Texto,
            SelectionBackColor = Paleta.AcentoClaro,
            SelectionForeColor = Paleta.Texto,
            Padding = new Padding(10, 0, 0, 0),
            Alignment = DataGridViewContentAlignment.MiddleLeft
        };
        g.AlternatingRowsDefaultCellStyle = g.DefaultCellStyle;

        foreach (DataGridViewColumn c in g.Columns)
        {
            c.SortMode = DataGridViewColumnSortMode.NotSortable;
            if (c is DataGridViewButtonColumn bc)
            {
                bc.FlatStyle = FlatStyle.Flat;
                bc.DefaultCellStyle.BackColor = Color.White;
                bc.DefaultCellStyle.SelectionBackColor = Paleta.AcentoClaro;
                bc.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 8.75f);
                bc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // hover de fila (feedback sutil e instantáneo)
        int filaHover = -1;
        g.CellMouseEnter += (s, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex == filaHover) return;
            if (filaHover >= 0 && filaHover < g.Rows.Count)
                g.Rows[filaHover].DefaultCellStyle.BackColor = Color.White;
            filaHover = e.RowIndex;
            g.Rows[filaHover].DefaultCellStyle.BackColor = Paleta.FilaHover;
        };
        g.MouseLeave += (s, e) =>
        {
            if (filaHover >= 0 && filaHover < g.Rows.Count)
                g.Rows[filaHover].DefaultCellStyle.BackColor = Color.White;
            filaHover = -1;
        };

        // badges tipo pill para valores de estado conocidos
        g.CellPainting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var valor = e.FormattedValue?.ToString();
            (Color bg, Color fg)? badge = valor switch
            {
                "Activo" => (Paleta.VerdeClaro, Color.FromArgb(4, 120, 87)),
                "Inactivo" => (Color.FromArgb(242, 244, 247), Paleta.TextoSuave),
                "Con deuda" => (Paleta.NaranjaClaro, Color.FromArgb(194, 65, 12)),
                "Al día" => (Paleta.VerdeClaro, Color.FromArgb(4, 120, 87)),
                _ => null
            };
            if (badge is null) return;

            e.PaintBackground(e.CellBounds, true);
            var gr = e.Graphics!;
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            var fuente = new Font("Segoe UI Semibold", 8.5f);
            var medida = TextRenderer.MeasureText(valor, fuente);
            var pill = new Rectangle(e.CellBounds.X + 10,
                                     e.CellBounds.Y + (e.CellBounds.Height - 22) / 2,
                                     medida.Width + 14, 22);
            using (var path = Redondear(pill, 11))
            using (var brocha = new SolidBrush(badge.Value.bg))
                gr.FillPath(brocha, path);
            TextRenderer.DrawText(gr, valor, fuente, pill, badge.Value.fg,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            e.Handled = true;
        };
    }
}
