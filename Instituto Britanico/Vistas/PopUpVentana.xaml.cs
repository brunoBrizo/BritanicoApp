using Instituto_Britanico.Modelo;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Instituto_Britanico.Vistas
{
    /// <summary>
    /// Lógica de interacción para PopUpVentana.xaml
    /// </summary>
    public partial class PopUpVentana : Window
    {


        public PopUpVentana(string texto, TipoMensaje tm, int tiempoInicial, int tiempoDesaparece, int elAncho, int elAlto)
        {
            InitializeComponent();
            int posicionHor = elAncho - 260;
            int posicionVer = elAlto - 120;
            ventanaPrincipal.Left = posicionHor;
            ventanaPrincipal.Top = posicionVer;
            switch (tm)
            {
                case TipoMensaje.Info:
                    icono.Kind = MaterialDesignThemes.Wpf.PackIconKind.InfoOutline;
                    bordePopUp.Background = Brushes.LightGreen;
                    break;
                case TipoMensaje.Borrado:
                    icono.Kind = MaterialDesignThemes.Wpf.PackIconKind.Delete;
                    bordePopUp.Background = Brushes.LightYellow;
                    break;
                case TipoMensaje.Error:

                    bordePopUp.Width = 750;
                    bordePopUp.Height = 500;
                    ventanaPrincipal.Width = 760;
                    ventanaPrincipal.Height = 600;
                    posicionHor = 300;
                    posicionVer = 000;
                    ventanaPrincipal.Left = posicionHor;
                    ventanaPrincipal.Top = posicionVer;
                    TransitionEffectKind tipo = TransitionEffectKind.SlideInFromTop;
                    TransitionEffectBase efecto = new TransitionEffect(tipo);
                    Slider.OpeningEffect = efecto;
                    icono.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertDecagram;
                    bordePopUp.Background = Brushes.Red;
                    break;
                case TipoMensaje.Alerta:
                    icono.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertDecagram;
                    bordePopUp.Background = Brushes.Yellow;
                    break;

            }
            txtInfo.Text = texto;

            ControlFadeOut(tiempoInicial, tiempoDesaparece);

        }

        private async void ControlFadeOut(int tiempoInicial, int tiempoDesaparece)
        {
            if (tiempoInicial == 0)
            {
                tiempoInicial = 2000;
                tiempoDesaparece = 50;
            }
            bool elT = false;

            ventanaPrincipal.Opacity = 1;
            if (await Espera(tiempoInicial)) ventanaPrincipal.Opacity = 1;
            int tiempo = tiempoDesaparece;
            double n = 1;
            while (!elT)
            {
                if (await Espera(tiempo)) ventanaPrincipal.Opacity = n;
                n = n - 0.02;
                if (n > 0 && n < 0.02)
                {
                    n = 0;
                    elT = true;
                    ventanaPrincipal.Opacity = 0;
                    this.Close();
                }
            }
            bordePopUp.Visibility = Visibility.Hidden;
        }

        private async Task<bool> Espera(int tiempo)
        {
            bool termino = false;
            await Task.Run(() => {
                termino = true;
                Thread.Sleep(tiempo);
            }
            );
            return termino;
        }

    }
}
