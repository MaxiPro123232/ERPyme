using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ERPyME.WinForms.Controladoras;
using ERPyME.WinForms.Ui;

namespace ERPyME.WinForms.Vistas;

/// <summary>Vista de gestión de productos (RF14/RF15/RF17). La lógica está en ControladoraProductos.</summary>
public partial class ProductosView : UserControl
{
    private class Fila
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Rubro { get; set; } = "";
        public string Precio { get; set; } = "";
        public string Stock { get; set; } = "";
        public string Estado { get; set; } = "";
        public string AccionEditar { get; set; } = "✏ Editar";
        public string AccionEstado { get; set; } = "";
        public bool Activo { get; set; }
    }

    private readonly ControladoraProductos _controladora = new();

    public ProductosView()
    {
        InitializeComponent();

        Estilos.EstilizarBotonPrimario(btnNuevo);
        Estilos.EstilizarCard(cardGrilla);
        Estilos.EstilizarGrilla(gridProductos);
        colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colBtnEditar.DefaultCellStyle.ForeColor = Paleta.Acento;
        colBtnEditar.DefaultCellStyle.SelectionForeColor = Paleta.Acento;
        colBtnEstado.DefaultCellStyle.ForeColor = Paleta.Rojo;
        colBtnEstado.DefaultCellStyle.SelectionForeColor = Paleta.Rojo;

        Cargar();
    }

    private void Cargar()
    {
        gridProductos.DataSource = _controladora.Listar(txtBuscar.Text).Select(p => new Fila
        {
            Id = p.Id,
            Codigo = p.Codigo,
            Nombre = p.Nombre,
            Rubro = p.Rubro?.Nombre ?? "",
            Precio = $"$ {p.Precio:N0}",
            Stock = p.BajoStock && p.Estado ? $"{p.StockActual}  ⚠" : p.StockActual.ToString(),
            Estado = p.Estado ? "Activo" : "Inactivo",
            AccionEstado = p.Estado ? "🚫 Desactivar" : "✔ Activar",
            Activo = p.Estado
        }).ToList();
    }

    private void TxtBuscar_TextChanged(object? sender, EventArgs e) => Cargar();

    private void BtnNuevo_Click(object? sender, EventArgs e)
    {
        using var f = new ProductoForm(null);
        if (f.ShowDialog(this) == DialogResult.OK) Cargar();
    }

    private void GridProductos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var fila = (Fila)gridProductos.Rows[e.RowIndex].DataBoundItem!;
        var prop = gridProductos.Columns[e.ColumnIndex].DataPropertyName;

        if (prop == "Estado")
        {
            e.CellStyle!.ForeColor = fila.Activo ? Paleta.Verde : Paleta.GrisClaro;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            e.CellStyle.Font = new Font("Segoe UI Semibold", 9f);
        }
        if (prop == "Stock" && fila.Stock.Contains('⚠'))
        {
            e.CellStyle!.ForeColor = Paleta.Naranja;
            e.CellStyle.SelectionForeColor = Paleta.Naranja;
        }
    }

    private void GridProductos_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var fila = (Fila)gridProductos.Rows[e.RowIndex].DataBoundItem!;
        var col = gridProductos.Columns[e.ColumnIndex].Name;

        if (col == "editar")
        {
            using var f = new ProductoForm(fila.Id);
            if (f.ShowDialog(this) == DialogResult.OK) Cargar();
        }
        else if (col == "estado")
        {
            var accion = fila.Activo ? "desactivar" : "activar";
            var r = MessageBox.Show($"¿Seguro que querés {accion} el producto \"{fila.Nombre}\"?",
                                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            _controladora.CambiarEstado(fila.Id); // RN05: baja lógica
            Cargar();
        }
    }
}
