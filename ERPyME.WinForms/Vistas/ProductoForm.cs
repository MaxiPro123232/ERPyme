using System;
using System.Windows.Forms;
using ERPyME.WinForms.Controladoras;
using ERPyME.WinForms.Ui;

namespace ERPyME.WinForms.Vistas;

/// <summary>Vista de alta / modificación de producto (RF15). La lógica está en ControladoraProductos.</summary>
public partial class ProductoForm : Form
{
    private readonly ControladoraProductos _controladora = new();
    private readonly int? _productoId;

    public ProductoForm(int? productoId)
    {
        InitializeComponent();
        _productoId = productoId;

        Estilos.EstilizarBotonPrimario(btnGuardar);
        Estilos.EstilizarBotonGris(btnCancelar);

        Text = productoId is null ? "Nuevo Producto" : "Modificar Producto";
        lblTitulo.Text = Text;

        cboRubro.DataSource = _controladora.ListarRubros();
        cboRubro.DisplayMember = "Nombre";
        cboRubro.ValueMember = "Id";

        if (_productoId is null)
        {
            txtCodigo.Text = _controladora.GenerarCodigo();
            txtStock.Text = "0";
            txtStockMin.Text = "0";
        }
        else
        {
            var p = _controladora.Obtener(_productoId.Value)!;
            txtCodigo.Text = p.Codigo;
            txtNombre.Text = p.Nombre;
            cboRubro.SelectedValue = p.RubroId;
            txtPrecio.Text = p.Precio.ToString("0.##");
            txtStock.Text = p.StockActual.ToString();
            txtStockMin.Text = p.StockMinimo.ToString();
            chkActivo.Checked = p.Estado;
        }
    }

    private void BtnCancelar_Click(object? sender, EventArgs e) => DialogResult = DialogResult.Cancel;

    private void BtnGuardar_Click(object? sender, EventArgs e)
    {
        lblError.Visible = false;

        // RNF14: la vista valida el formato numérico; las reglas de negocio las valida la controladora
        if (!decimal.TryParse(txtPrecio.Text.Replace(',', '.'),
            System.Globalization.NumberStyles.Number,
            System.Globalization.CultureInfo.InvariantCulture, out var precio))
        { Error("El precio debe ser un número válido."); return; }
        if (!int.TryParse(txtStock.Text, out var stock))
        { Error("El stock debe ser un número entero."); return; }
        if (!int.TryParse(txtStockMin.Text, out var stockMin))
        { Error("El stock mínimo debe ser un número entero."); return; }

        var error = _controladora.Guardar(_productoId, txtCodigo.Text, txtNombre.Text,
            cboRubro.SelectedValue as int?, precio, stock, stockMin, chkActivo.Checked);

        if (error is not null) { Error(error); return; }
        DialogResult = DialogResult.OK;
    }

    private void Error(string mensaje)
    {
        lblError.Text = mensaje;
        lblError.Visible = true;
    }
}
