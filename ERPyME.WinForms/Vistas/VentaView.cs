using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ERPyME.WinForms.Controladoras;
using ERPyME.WinForms.Modelos;
using ERPyME.WinForms.Ui;

namespace ERPyME.WinForms.Vistas;

/// <summary>Vista del registro de venta (RC01). La lógica está en ControladoraVentas.</summary>
public partial class VentaView : UserControl
{
    private class FilaItem
    {
        public string Codigo { get; set; } = "";
        public string Producto { get; set; } = "";
        public int Cantidad { get; set; }
        public string PrecioUnitario { get; set; } = "";
        public string Subtotal { get; set; } = "";
        public string AccionQuitar { get; set; } = "✕ Quitar";
    }

    private class ProductoOpcion
    {
        public Producto Producto { get; init; } = null!;
        public override string ToString() => $"{Producto.Codigo} - {Producto.Nombre}  ($ {Producto.Precio:N0})";
    }

    private readonly ControladoraVentas _controladora = new();
    private readonly List<ItemVenta> _items = new();

    public VentaView()
    {
        InitializeComponent();

        Estilos.EstilizarCard(cardDatos);
        Estilos.EstilizarCard(cardProductos);
        Estilos.EstilizarBotonPrimario(btnAgregar);
        Estilos.EstilizarBotonVerde(btnConfirmar);
        Estilos.EstilizarBotonGris(btnCancelar);
        Estilos.EstilizarGrilla(gridItems);
        Estilos.EstilizarCombo(cboCliente);
        Estilos.EstilizarCombo(cboFormaPago);
        Estilos.EstilizarCombo(cboProducto);
        colPrecioUnitario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colSubtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colBtnQuitar.DefaultCellStyle.ForeColor = Paleta.Rojo;
        colBtnQuitar.DefaultCellStyle.SelectionForeColor = Paleta.Rojo;

        txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
        cboFormaPago.SelectedIndex = 0;

        CargarCombos();
    }

    private void CargarCombos()
    {
        cboCliente.DataSource = _controladora.ListarClientesActivos();
        cboCliente.DisplayMember = "Descripcion";
        cboCliente.ValueMember = "Id";
        cboCliente.SelectedIndex = -1;

        cboProducto.DataSource = _controladora.ListarProductosActivos()
            .Select(p => new ProductoOpcion { Producto = p }).ToList();
        cboProducto.SelectedIndex = -1;
        lblStockInfo.Text = "";
    }

    // ---- Reacomodo de controles al cambiar el tamaño ----
    private void PanelSelector_Resize(object? sender, EventArgs e)
    {
        cboProducto.Width = Math.Max(panelSelector.Width - 250, 160);
        lblCantidad.Left = cboProducto.Right + 16;
        numCantidad.Left = lblCantidad.Left;
        btnAgregar.Left = numCantidad.Right + 14;
    }

    private void CardDatos_Resize(object? sender, EventArgs e)
    {
        cboCliente.Width = Math.Max(cardDatos.Width - 420, 180);
        lblFormaPago.Left = cboCliente.Right + 20;
        cboFormaPago.Left = lblFormaPago.Left;
        cboFormaPago.Width = cardDatos.Width - lblFormaPago.Left - 22;
    }

    private void PanelTotal_Resize(object? sender, EventArgs e) => UbicarTotal();
    private void LblTotal_TextChanged(object? sender, EventArgs e) => UbicarTotal();

    private void UbicarTotal()
    {
        lblTotal.Location = new Point(panelTotal.Width - lblTotal.Width - 4, 10);
        lblTotalTexto.Location = new Point(lblTotal.Left - lblTotalTexto.Width - 8, 16);
    }

    // ---- Eventos ----
    private void CboProducto_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cboProducto.SelectedItem is ProductoOpcion op)
            lblStockInfo.Text = $"Stock disponible: {op.Producto.StockActual} unidades" +
                                (op.Producto.BajoStock ? "   ⚠ stock en nivel mínimo" : "");
        else
            lblStockInfo.Text = "";
    }

    private void BtnAgregar_Click(object? sender, EventArgs e)
    {
        if (cboProducto.SelectedItem is not ProductoOpcion op)
        {
            MessageBox.Show("Seleccioná un producto.", "Registrar Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var p = op.Producto;
        var cantidad = (int)numCantidad.Value;
        var existente = _items.FirstOrDefault(i => i.ProductoId == p.Id);
        var cantidadTotal = cantidad + (existente?.Cantidad ?? 0);

        // RF21 / RN01: la controladora valida disponibilidad
        var error = _controladora.ValidarStock(p, cantidadTotal);
        if (error is not null)
        {
            MessageBox.Show(error, "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (existente is not null)
            existente.Cantidad = cantidadTotal;
        else
            _items.Add(new ItemVenta
            {
                ProductoId = p.Id,
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                Cantidad = cantidad,
                PrecioUnitario = p.Precio
            });

        numCantidad.Value = 1;
        cboProducto.SelectedIndex = -1;
        RefrescarItems();
    }

    private void GridItems_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && gridItems.Columns[e.ColumnIndex].Name == "quitar")
        {
            _items.RemoveAt(e.RowIndex);
            RefrescarItems();
        }
    }

    private void RefrescarItems()
    {
        gridItems.DataSource = _items.Select(i => new FilaItem
        {
            Codigo = i.Codigo,
            Producto = i.Nombre,
            Cantidad = i.Cantidad,
            PrecioUnitario = $"$ {i.PrecioUnitario:N0}",
            Subtotal = $"$ {i.Subtotal:N0}"
        }).ToList();
        lblTotal.Text = $"$ {_items.Sum(i => i.Subtotal):N0}";
    }

    private void BtnCancelar_Click(object? sender, EventArgs e) => Limpiar();

    private void Limpiar()
    {
        _items.Clear();
        cboFormaPago.SelectedIndex = 0;
        numCantidad.Value = 1;
        RefrescarItems();
        CargarCombos();
    }

    private void BtnConfirmar_Click(object? sender, EventArgs e)
    {
        if (cboCliente.SelectedValue is not int clienteId)
        {
            MessageBox.Show("Seleccioná un cliente.", "Registrar Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (_items.Count == 0)
        {
            MessageBox.Show("Agregá al menos un producto a la venta.", "Registrar Venta",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var formaPago = cboFormaPago.SelectedItem?.ToString() ?? "Contado";
        var total = _items.Sum(i => i.Subtotal);

        var r = MessageBox.Show($"Confirmar venta por $ {total:N0} ({formaPago}).\n¿Continuar?",
                                "Confirmar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (r != DialogResult.Yes) return;

        // RC01: la controladora ejecuta todo el flujo dentro de una transacción
        var resultado = _controladora.Registrar(clienteId, formaPago, _items);

        MessageBox.Show(resultado.Mensaje,
            resultado.Exito ? "Venta registrada" : "No se pudo registrar la venta",
            MessageBoxButtons.OK,
            resultado.Exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

        if (resultado.Exito) Limpiar();
    }
}
