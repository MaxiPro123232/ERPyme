using System;
using System.Windows.Forms;

namespace ERPyME.WinForms.Ui;

/// <summary>
/// Animaciones utilitarias del sistema. Criterio: las acciones frecuentes no se animan
/// o se animan muy corto (ease-out, nunca más de ~650 ms); la presión de botones da
/// feedback instantáneo (eso vive en Estilos).
/// </summary>
public static class Animaciones
{
    /// <summary>Ejecuta una animación con ease-out cúbico llamando a <paramref name="paso"/> con el progreso [0..1].</summary>
    public static void Animar(int duracionMs, Action<double> paso, Action? alTerminar = null)
    {
        var inicio = Environment.TickCount64;
        var timer = new System.Windows.Forms.Timer { Interval = 15 };
        timer.Tick += (s, e) =>
        {
            double p = Math.Min(1.0, (Environment.TickCount64 - inicio) / (double)duracionMs);
            double suavizado = 1 - Math.Pow(1 - p, 3); // ease-out cúbico
            try
            {
                paso(suavizado);
            }
            catch (ObjectDisposedException)
            {
                timer.Stop();
                timer.Dispose();
                return;
            }
            if (p >= 1.0)
            {
                timer.Stop();
                timer.Dispose();
                alTerminar?.Invoke();
            }
        };
        timer.Start();
    }

    /// <summary>Fade-in de una ventana al abrirse (160 ms por defecto).</summary>
    public static void AparecerVentana(Form f, int duracionMs = 160)
    {
        f.Opacity = 0;
        f.Load += (s, e) => Animar(duracionMs, p => { if (!f.IsDisposed) f.Opacity = p; });
    }

    /// <summary>
    /// Entrada de una vista al panel de contenido: aparece 14 px más abajo y se
    /// asienta en su lugar (180 ms, ease-out). Al terminar queda dockeada normal.
    /// </summary>
    public static void EntrarVista(Control vista, Panel contenedor)
    {
        const int desplazamiento = 14;
        vista.Dock = DockStyle.None;
        vista.SetBounds(0, desplazamiento, contenedor.ClientSize.Width, contenedor.ClientSize.Height);
        vista.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        contenedor.Controls.Add(vista);
        Animar(180, p =>
        {
            if (vista.IsDisposed) return;
            vista.Top = (int)Math.Round(desplazamiento * (1 - p));
        }, () =>
        {
            if (!vista.IsDisposed) vista.Dock = DockStyle.Fill;
        });
    }
}
