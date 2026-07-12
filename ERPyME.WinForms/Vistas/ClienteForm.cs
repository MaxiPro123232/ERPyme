using System;
using System.Windows.Forms;
using ERPyME.WinForms.Controladoras;
using ERPyME.WinForms.Ui;

namespace ERPyME.WinForms.Vistas;

/// <summary>Vista de alta / modificación de cliente (RF11). La lógica está en ControladoraClientes.</summary>
public partial class ClienteForm : Form
{
    private readonly ControladoraClientes _controladora = new();
    private readonly int? _clienteId;

    public ClienteForm(int? clienteId)
    {
        InitializeComponent();
        _clienteId = clienteId;

        Estilos.EstilizarBotonPrimario(btnGuardar);
        Estilos.EstilizarBotonGris(btnCancelar);

        Text = clienteId is null ? "Nuevo Cliente" : "Modificar Cliente";
        lblTitulo.Text = Text;

        if (_clienteId is null)
        {
            txtCodigo.Text = _controladora.GenerarCodigo();
        }
        else
        {
            var c = _controladora.Obtener(_clienteId.Value)!;
            txtCodigo.Text = c.Codigo;
            txtNombre.Text = c.Nombre;
            txtCuit.Text = c.Cuit ?? "";
            txtEmail.Text = c.Email ?? "";
            txtTelefono.Text = c.Telefono ?? "";
            txtDireccion.Text = c.Direccion ?? "";
            chkActivo.Checked = c.Estado;
        }
    }

    private void BtnCancelar_Click(object? sender, EventArgs e) => DialogResult = DialogResult.Cancel;

    private void BtnGuardar_Click(object? sender, EventArgs e)
    {
        lblError.Visible = false;
        var error = _controladora.Guardar(_clienteId, txtCodigo.Text, txtNombre.Text,
            txtCuit.Text, txtEmail.Text, txtTelefono.Text, txtDireccion.Text, chkActivo.Checked);

        if (error is not null)
        {
            lblError.Text = error;
            lblError.Visible = true;
            return;
        }
        DialogResult = DialogResult.OK;
    }
}
