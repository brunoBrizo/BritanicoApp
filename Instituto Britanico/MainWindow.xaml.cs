
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Forms;
using System;
using Instituto_Britanico.Modelo;
using Instituto_Britanico.Controlador;
using System.Drawing;
using Instituto_Britanico.Vistas;
using Instituto_Britanico.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using BibliotecaBritanico.Modelo;

namespace Instituto_Britanico
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IBrillo
    {
        Fachada fachada;
        int alto, ancho;

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InicializarCliente();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            fachada = await Fachada.getInstanciaAsync();
            ObtenerResolucion();
            System.Windows.Size tamano = new System.Windows.Size(ancho, alto);
            fachada.SetResolucion(tamano);
            PantallaPrincipal.Height = alto;
            PantallaPrincipal.Width = ancho + 190;
            stackMenuPrincipal.Height = alto;
            stackContenido.Height = alto;
            stackContenido.Width = ancho;
            stackContenido.Children.Clear();
        }

        private void BtnEstudiantes_Click(object sender, RoutedEventArgs e)
        {
            BorrarBackgrounds();
            btnEstudiantes.Background = System.Windows.Media.Brushes.Red;
            stackContenido.Children.Clear();
            stackContenido.Children.Add(new VistaEstudiantes(this));
        }



        private void ObtenerResolucion()
        {
            Screen pantalla = Screen.PrimaryScreen;
            int elAncho = pantalla.WorkingArea.Width;
            int elAlto = pantalla.Bounds.Height;
            Window ventana = this;
            PresentationSource MWPS = PresentationSource.FromVisual(ventana);
            Matrix m = MWPS.CompositionTarget.TransformToDevice;
            double w = m.M11;
            double h = m.M22;
            alto = (int)(elAlto / h);
            ancho = ((int)(elAncho / w)) - (int)stackMenuPrincipal.Width;
        }


        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void BtnLibros_Click(object sender, RoutedEventArgs e)
        {
            BorrarBackgrounds();
            btnLibros.Background = System.Windows.Media.Brushes.Red;
            VistaLibros vl = new VistaLibros(this);
            stackContenido.Children.Clear();
            stackContenido.Children.Add(vl);
        }

        private void BtnGrupos_Click(object sender, RoutedEventArgs e)
        {
            BorrarBackgrounds();
            btnGrupos.Background = System.Windows.Media.Brushes.Red;
            VistaGrupos vg = new VistaGrupos(this);
            stackContenido.Children.Clear();
            stackContenido.Children.Add(vg);
        }

        private void BtnMaterias_Click(object sender, RoutedEventArgs e)
        {
            BorrarBackgrounds();
            btnMaterias.Background = System.Windows.Media.Brushes.Red;
            VistaMaterias vm = new VistaMaterias(this);
            stackContenido.Children.Clear();
            stackContenido.Children.Add(vm);
        }

        private void BtnFuncionarios_Click(object sender, RoutedEventArgs e)
        {
            BorrarBackgrounds();
            btnFuncionarios.Background = System.Windows.Media.Brushes.Red;
            VistaFuncionario vf = new VistaFuncionario(this);
            stackContenido.Children.Clear();
            stackContenido.Children.Add(vf);
        }

        private void BtnExamenes_Click(object sender, RoutedEventArgs e)
        {
            BorrarBackgrounds();
            btnExamenes.Background = System.Windows.Media.Brushes.Red;
            VistaExamenes ve = new VistaExamenes(this);
            stackContenido.Children.Clear();
            stackContenido.Children.Add(ve);
        }

        private void BtnCobros_Click(object sender, RoutedEventArgs e)
        {
            BorrarBackgrounds();
            btnCobros.Background = System.Windows.Media.Brushes.Red;
            VentanaBorrar vb = new VentanaBorrar();
            vb.ShowDialog();
        }

        private void BtnPagos_Click(object sender, RoutedEventArgs e)
        {
            BorrarBackgrounds();
            btnPagos.Background = System.Windows.Media.Brushes.Red;
            VistaPagos vp = new VistaPagos(this);
            stackContenido.Children.Clear();
            stackContenido.Children.Add(vp);

        }

        private void BorrarBackgrounds()
        {
            btnCobros.Background = System.Windows.Media.Brushes.Transparent;
            btnEstudiantes.Background = System.Windows.Media.Brushes.Transparent;
            btnExamenes.Background = System.Windows.Media.Brushes.Transparent;
            btnFuncionarios.Background = System.Windows.Media.Brushes.Transparent;
            btnLibros.Background = System.Windows.Media.Brushes.Transparent;
            btnMaterias.Background = System.Windows.Media.Brushes.Transparent;
            btnGrupos.Background = System.Windows.Media.Brushes.Transparent;
            btnMails.Background = System.Windows.Media.Brushes.Transparent;
            btnPagos.Background = System.Windows.Media.Brushes.Transparent;

        }

        private void BtnMatricula_Click(object sender, RoutedEventArgs e)
        {
            VistaMatriculas vm = new VistaMatriculas(this);
            stackContenido.Children.Clear();
            stackContenido.Children.Add(vm);
        }

        private void BtnMatricularEstudiante_Click(object sender, RoutedEventArgs e)
        {
            VentanaMatricula vm = new VentanaMatricula();
            vm.Owner = this;
            vm.ShowDialog();
        }

        private void BtnConvenios_Click(object sender, RoutedEventArgs e)
        {
            VistaConvenios vc = new VistaConvenios(this);
            stackContenido.Children.Clear();
            stackContenido.Children.Add(vc);
        }

        private async void OscurecerPantalla()
        {
            int tiempoDesaparece = 20;
            bool minimo = false;
            int tiempo = tiempoDesaparece;
            double n = 1;
            while (!minimo)
            {
                if (await Espera(tiempo)) Opacity = n;
                n = n - 0.02;
                if (n > 0.2 && n < 0.22)
                {
                    minimo = true;
                }
            }
        }

        private async void AclararPantalla()
        {
            int tiempoDesaparece = 10;
            bool maximo = false;
            int tiempo = tiempoDesaparece;
            double n = .22;
            while (!maximo)
            {
                if (await Espera(tiempo)) Opacity = n;
                n = n + 0.02;
                if (n > .98)
                {
                    maximo = true;
                }
            }
        }

        private async Task<bool> Espera(int tiempo)
        {
            bool termino = false;
            await Task.Run(() =>
            {
                termino = true;
                Thread.Sleep(tiempo);
            }
            );
            return termino;
        }

        public void Oscurecer()
        {
            OscurecerPantalla();
        }

        private void BtnMinimiza_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public void Aclarar()
        {
            AclararPantalla();
        }
    }
}
