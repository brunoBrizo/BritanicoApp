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
    /// Lógica de interacción para VistaMaterias.xaml
    /// </summary>
    public partial class VistaMaterias : UserControl
    {
        Fachada fachada;
        Window Ventana;
        int Ancho, Alto;
        public VistaMaterias(Window v)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            this.Ventana = v;
            Loaded += VistaMaterias_Loaded;
        }

        private void VistaMaterias_Loaded(object sender, RoutedEventArgs e)
        {

            Ancho = (int)fachada.Tamano.Width;
            Alto = (int)fachada.Tamano.Height - 20;
            borde.Height = Alto - 20;
            List<Materia> lista = fachada.GetMateriasTotal();
            dgMaterias.ItemsSource = null;
            dgMaterias.ItemsSource = lista;
        }

        private void teclaApretada(object sender, KeyEventArgs e)
        {

        }

        private void dobleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void ClickEnEditar(object sender, RoutedEventArgs e)
        {

        }

        private void BtnIngresarMateria_Click(object sender, RoutedEventArgs e)
        {
            VentanaMateria vm = new VentanaMateria();
            vm.ShowDialog();

        }

        private void ClickEnBorrar(object sender, RoutedEventArgs e)
        {

        }
    }
}
