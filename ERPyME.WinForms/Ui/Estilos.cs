using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERPyME.WinForms.Ui;

/// <summary>Paleta de colores del sistema (RNF12: consistencia visual).</summary>
public static class Paleta
{
    public static readonly Color Sidebar = Color.FromArgb(27, 42, 65);
    public static readonly Color SidebarHover = Color.FromArgb(36, 54, 79);
    public static readonly Color SidebarActivo = Color.FromArgb(39, 75, 143);
    public static readonly Color Acento = Color.FromArgb(37, 99, 235);
    public static readonly Color AcentoClaro = Color.FromArgb(219, 234, 254);
    public static readonly Color Verde = Color.FromArgb(22, 163, 74);
    public static readonly Color Rojo = Color.FromArgb(220, 38, 38);
    public static readonly Color Naranja = Color.FromArgb(217, 119, 6);
    public static readonly Color Fondo = Color.FromArgb(241, 245, 249);
    public static readonly Color Carta = Color.White;
    public static readonly Color Borde = Color.FromArgb(226, 232, 240);
    public static readonly Color Texto = Color.FromArgb(15, 23, 42);
    public static readonly Color TextoSuave = Color.FromArgb(100, 116, 139);
    public static readonly Color GrisClaro = Color.FromArgb(148, 163, 184);
    public static readonly Color EncabezadoGrilla = Color.FromArgb(248, 250, 252);
}

/// <summary>Fábrica de controles con el estilo del sistema.</summary>
public static class Estilos
{
    // ===== Estilizadores para controles declarados en los .Designer.cs =====

    /// <summary>Aplica el estilo de botón del sistema a un botón declarado en el diseñador.</summary>
    public static void EstilizarBoton(Button b, Color fondo, Color? frente = null)
    {
        b.BackColor = fondo;
        b.ForeColor = frente ?? Color.White;
        b.FlatStyle = FlatStyle.Flat;
        b.Font = new Font("Segoe UI Semibold", 9.5f);
        b.Cursor = Cursors.Hand;
        b.UseVisualStyleBackColor = false;
        b.FlatAppearance.BorderSize = 0;
        b.FlatAppearance.MouseOverBackColor = ControlPaint.Light(fondo, 0.15f);
        b.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(fondo, 0.05f);
    }

    public static void EstilizarBotonPrimario(Button b) => EstilizarBoton(b, Paleta.Acento);
    public static void EstilizarBotonVerde(Button b) => EstilizarBoton(b, Paleta.Verde);
    public static void EstilizarBotonRojo(Button b) => EstilizarBoton(b, Paleta.Rojo);
    public static void EstilizarBotonGris(Button b) => EstilizarBoton(b, Paleta.Borde, Paleta.Texto);

    /// <summary>Dibuja el borde fino de tarjeta sobre un panel declarado en el diseñador.</summary>
    public static void EstilizarCard(Panel p)
    {
        p.BackColor = Paleta.Carta;
        p.Paint += (s, e) =>
        {
            using var pen = new Pen(Paleta.Borde);
            e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        };
        p.Resize += (s, e) => p.Invalidate();
    }

    /// <summary>Aplica el estilo de grilla del sistema a una grilla declarada en el diseñador (RNF12).</summary>
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
        g.GridColor = Paleta.Borde;
        g.EnableHeadersVisualStyles = false;
        g.ColumnHeadersHeight = 40;
        g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        g.Font = new Font("Segoe UI", 9.5f);
        g.RowTemplate.Height = 38;

        g.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Paleta.EncabezadoGrilla,
            SelectionBackColor = Paleta.EncabezadoGrilla,
            ForeColor = Paleta.TextoSuave,
            Font = new Font("Segoe UI Semibold", 9f),
            Padding = new Padding(8, 0, 0, 0),
            Alignment = DataGridViewContentAlignment.MiddleLeft
        };
        g.DefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.White,
            ForeColor = Paleta.Texto,
            SelectionBackColor = Paleta.AcentoClaro,
            SelectionForeColor = Paleta.Texto,
            Padding = new Padding(8, 0, 0, 0),
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
    }

    // ===== Fábricas (para controles creados dinámicamente) =====

    public static Button Boton(string texto, Color fondo, Color? frente = null)
    {
        var b = new Button
        {
            Text = texto,
            BackColor = fondo,
            ForeColor = frente ?? Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI Semibold", 9.5f),
            Cursor = Cursors.Hand,
            Height = 36,
            AutoSize = false,
            UseVisualStyleBackColor = false
        };
        b.FlatAppearance.BorderSize = 0;
        b.FlatAppearance.MouseOverBackColor = ControlPaint.Light(fondo, 0.15f);
        b.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(fondo, 0.05f);
        return b;
    }

    public static Button BotonPrimario(string texto) => Boton(texto, Paleta.Acento);
    public static Button BotonVerde(string texto) => Boton(texto, Paleta.Verde);
    public static Button BotonRojo(string texto) => Boton(texto, Paleta.Rojo);
    public static Button BotonGris(string texto) => Boton(texto, Paleta.Borde, Paleta.Texto);

    public static Label Titulo(string texto) => new()
    {
        Text = texto,
        Font = new Font("Segoe UI", 16f, FontStyle.Bold),
        ForeColor = Paleta.Texto,
        AutoSize = true
    };

    public static Label Subtitulo(string texto) => new()
    {
        Text = texto,
        Font = new Font("Segoe UI", 9.5f),
        ForeColor = Paleta.TextoSuave,
        AutoSize = true
    };

    public static Label Etiqueta(string texto) => new()
    {
        Text = texto,
        Font = new Font("Segoe UI Semibold", 8.75f),
        ForeColor = Paleta.TextoSuave,
        AutoSize = true
    };

    public static TextBox Input() => new()
    {
        Font = new Font("Segoe UI", 10f),
        BorderStyle = BorderStyle.FixedSingle,
        Height = 30
    };

    public static ComboBox Combo() => new()
    {
        Font = new Font("Segoe UI", 10f),
        DropDownStyle = ComboBoxStyle.DropDownList,
        FlatStyle = FlatStyle.Flat,
        BackColor = Color.White
    };

    /// <summary>Panel blanco con borde fino, estilo tarjeta.</summary>
    public static Panel Card()
    {
        var p = new Panel { BackColor = Paleta.Carta, Padding = new Padding(20) };
        p.Paint += (s, e) =>
        {
            using var pen = new Pen(Paleta.Borde);
            e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        };
        p.Resize += (s, e) => p.Invalidate();
        return p;
    }

    /// <summary>Grilla con estilo uniforme para todos los listados (RNF12).</summary>
    public static DataGridView Grilla()
    {
        var g = new DataGridView
        {
            Dock = DockStyle.Fill,
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            AllowUserToOrderColumns = false,
            ReadOnly = true,
            AutoGenerateColumns = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false,
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
            GridColor = Paleta.Borde,
            EnableHeadersVisualStyles = false,
            ColumnHeadersHeight = 40,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            Font = new Font("Segoe UI", 9.5f)
        };
        g.RowTemplate.Height = 38;

        g.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Paleta.EncabezadoGrilla,
            SelectionBackColor = Paleta.EncabezadoGrilla,
            ForeColor = Paleta.TextoSuave,
            Font = new Font("Segoe UI Semibold", 9f),
            Padding = new Padding(8, 0, 0, 0),
            Alignment = DataGridViewContentAlignment.MiddleLeft
        };
        g.DefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.White,
            ForeColor = Paleta.Texto,
            SelectionBackColor = Paleta.AcentoClaro,
            SelectionForeColor = Paleta.Texto,
            Padding = new Padding(8, 0, 0, 0),
            Alignment = DataGridViewContentAlignment.MiddleLeft
        };
        g.AlternatingRowsDefaultCellStyle = g.DefaultCellStyle;
        return g;
    }

    public static DataGridViewTextBoxColumn Col(string titulo, string propiedad, float peso,
        DataGridViewContentAlignment alineacion = DataGridViewContentAlignment.MiddleLeft)
    {
        return new DataGridViewTextBoxColumn
        {
            HeaderText = titulo,
            DataPropertyName = propiedad,
            FillWeight = peso,
            SortMode = DataGridViewColumnSortMode.NotSortable,
            DefaultCellStyle = { Alignment = alineacion }
        };
    }

    public static DataGridViewButtonColumn ColBoton(string nombre, string propiedad, float peso, Color color)
    {
        return new DataGridViewButtonColumn
        {
            Name = nombre,
            HeaderText = "",
            DataPropertyName = propiedad,
            FillWeight = peso,
            FlatStyle = FlatStyle.Flat,
            SortMode = DataGridViewColumnSortMode.NotSortable,
            DefaultCellStyle =
            {
                BackColor = Color.White,
                SelectionBackColor = Paleta.AcentoClaro,
                ForeColor = color,
                SelectionForeColor = color,
                Font = new Font("Segoe UI Semibold", 8.75f),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        };
    }
}
