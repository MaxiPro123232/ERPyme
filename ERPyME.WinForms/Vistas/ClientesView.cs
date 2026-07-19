using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ERPyME.WinForms.Controladoras;
using ERPyME.WinForms.Ui;

namespace ERPyME.WinForms.Vistas;

/// <summary>Vista de gestión de clientes (RF10/RF11). La lógica está en ControladoraClientes.</summary>
public partial class ClientesView : UserControl
{
    private class Fila
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Cuit { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Saldo { get; set; } = "";
        public string Estado { get; set; } = "";
        public string AccionEditar { get; set; } = "✏ Editar";
        public string AccionEstado { get; set; } = "";
        public bool Activo { get; set; }
        public bool ConDeuda { get; set; }
    }

    private readonly ControladoraClientes _controladora = new();

    public ClientesView()
    {
        InitializeComponent();

        Estilos.EstilizarBotonPrimario(btnNuevo);
        Estilos.EstilizarCard(cardGrilla);
        Estilos.EstilizarGrilla(gridClientes);
        colSaldo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colBtnEditar.DefaultCellStyle.ForeColor = Paleta.Acento;
        colBtnEditar.DefaultCellStyle.SelectionForeColor = Paleta.Acento;
        colBtnEstado.DefaultCellStyle.ForeColor = Paleta.Rojo;
        colBtnEstado.DefaultCellStyle.SelectionForeColor = Paleta.Rojo;

        Cargar();
    }

    private void Cargar()
    {
        gridClientes.DataSource = _controladora.Listar(txtBuscar.Text).Select(c =>
        {
            var saldo = c.CuentaCorriente?.SaldoActual ?? 0;
            return new Fila
            {
                Id = c.Id,
                Codigo = c.Codigo,
                Nombre = c.Nombre,
                Cuit = c.Cuit ?? "",
                Email = c.Email ?? "",
                Telefono = c.Telefono ?? "",
                Saldo = $"$ {saldo:N0}",
                Estado = c.Estado ? "Activo" : "Inactivo",
                AccionEstado = c.Estado ? "🚫 Desactivar" : "✔ Activar",
                Activo = c.Estado,
                ConDeuda = saldo > 0
            };
        }).ToList();
    }

    private void TxtBuscar_TextChanged(object? sender, EventArgs e) => Cargar();

    private void BtnNuevo_Click(object? sender, EventArgs e)
    {
        using var f = new ClienteForm(null);
        if (f.ShowDialog(this) == DialogResult.OK) Cargar();
    }

    private void GridClientes_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var fila = (Fila)gridClientes.Rows[e.RowIndex].DataBoundItem!;
        var prop = gridClientes.Columns[e.ColumnIndex].DataPropertyName;

        if (prop == "Estado")
        {
            e.CellStyle!.ForeColor = fila.Activo ? Paleta.Verde : Paleta.GrisClaro;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            e.CellStyle.Font = new Font("Segoe UI Semibold", 9f);
        }
        if (prop == "Saldo")
        {
            e.CellStyle!.ForeColor = fila.ConDeuda ? Paleta.Naranja : Paleta.Verde;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            e.CellStyle.Font = new Font("Segoe UI Semibold", 9f);
        }
    }

    private void GridClientes_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var fila = (Fila)gridClientes.Rows[e.RowIndex].DataBoundItem!;
        var col = gridClientes.Columns[e.ColumnIndex].Name;

        if (col == "editar")
        {
            using var f = new ClienteForm(fila.Id);
            if (f.ShowDialog(this) == DialogResult.OK) Cargar();
        }
        else if (col == "estado")
        {
            var accion = fila.Activo ? "desactivar" : "activar";
            var r = MessageBox.Show($"¿Seguro que querés {accion} el cliente \"{fila.Nombre}\"?",
                                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            _controladora.CambiarEstado(fila.Id);
            Cargar();
        }
    }
}
