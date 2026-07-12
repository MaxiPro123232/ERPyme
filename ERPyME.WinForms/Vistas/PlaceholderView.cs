using System.Drawing;
using System.Windows.Forms;
using ERPyME.WinForms.Ui;

namespace ERPyME.WinForms.Vistas;

/// <summary>Vista para módulos previstos en la especificación pero aún no desarrollados.</summary>
public partial class PlaceholderView : UserControl
{
    public PlaceholderView()
    {
        InitializeComponent();
        Estilos.EstilizarCard(cardCentro);
        Resize += (s, e) => cardCentro.Location = new Point(
            (Width - cardCentro.Width) / 2, (Height - cardCentro.Height) / 2);
    }

    public PlaceholderView(string modulo, string requerimientos) : this()
    {
        lblModulo.Text = modulo;
        lblRequerimiento.Text = "Previsto en la especificación: " + requerimientos;
    }
}
