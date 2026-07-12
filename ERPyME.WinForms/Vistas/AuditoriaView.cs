using System;
using System.Windows.Forms;
using ERPyME.WinForms.Controladoras;
using ERPyME.WinForms.Ui;

namespace ERPyME.WinForms.Vistas;

/// <summary>Vista de auditoría (RF28 / RNF07). Los datos vienen de ControladoraAuditoria.</summary>
public partial class AuditoriaView : UserControl
{
    private readonly ControladoraAuditoria _controladora = new();

    public AuditoriaView()
    {
        InitializeComponent();

        Estilos.EstilizarBotonGris(btnActualizar);
        Estilos.EstilizarCard(cardGrilla);
        Estilos.EstilizarGrilla(gridAuditoria);

        Cargar();
    }

    private void Cargar() => gridAuditoria.DataSource = _controladora.Listar();

    private void BtnActualizar_Click(object? sender, EventArgs e) => Cargar();
}
