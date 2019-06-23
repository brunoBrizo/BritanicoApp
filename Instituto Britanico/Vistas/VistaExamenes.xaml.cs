using BibliotecaBritanico.Modelo;
using Instituto_Britanico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Instituto_Britanico.Vistas
{
    /// <summary>
    /// Lógica de interacción para VistaExamenes.xaml
    /// </summary>
    public partial class VistaExamenes : UserControl
    {
        Window ventana;
        Fachada fachada;
        int Alto, Ancho;

        public VistaExamenes(Window v)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            this.ventana = v;
            CargarLista();
            Loaded += VistaExamenes_Loaded;

        }

        private void CargarLista()
        {

            List<Grupo> listaGrupos = fachada.GetGruposTotalb();
            cbGrupo.Items.Clear();
            cbGrupo.ItemsSource = listaGrupos;
            List<Examen> listaExamenes = fachada.GetExamenesTotal();
            dgExamenes.ItemsSource = listaExamenes;

        }

        private void VistaExamenes_Loaded(object sender, RoutedEventArgs e)
        {
            Ancho = (int)fachada.Tamano.Width;
            Alto = (int)fachada.Tamano.Height - 20;
            borde.Height = Alto - 20;

        }

        private void TeclaEnAnio(object sender, KeyEventArgs e)
        {

        }

        private void teclaApretada(object sender, KeyEventArgs e)
        {

        }

        private void dobleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void CambioCBGrupo(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClickEnEditar(object sender, RoutedEventArgs e)
        {

        }

        private void ClickEnVerLupa(object sender, RoutedEventArgs e)
        {

        }

        private void BtnIngresoExamen_Click(object sender, RoutedEventArgs e)
        {
            VentanaExamenes ve = new VentanaExamenes(ventana);
            ve.Owner = ventana;
            ve.Show();
        }
    }
}
