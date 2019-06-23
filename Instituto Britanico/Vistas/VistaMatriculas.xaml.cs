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
    /// Lógica de interacción para VistaMatriculas.xaml
    /// </summary>
    public partial class VistaMatriculas : UserControl
    {

        Fachada fachada;
        Window ventana;

        public VistaMatriculas(Window v)
        {
            InitializeComponent();
            ventana = v;
            fachada = Fachada.getInstancia();
            CargarDatos();
        }

        private void CargarDatos()
        {
            //List<Matricula> lista = fachada.GetVMMatriculas();
            //dgMatriculas.ItemsSource = lista;
        }

        private void BtnIngresarMatricula_Click(object sender, RoutedEventArgs e)
        {
            VentanaMatricula vm = new VentanaMatricula();
            vm.Owner = ventana;
            vm.ShowDialog();

        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TeclaEnAnio(object sender, KeyEventArgs e)
        {

        }

        private void ClickEnEditar(object sender, RoutedEventArgs e)
        {

        }

        private void ClickEnVerLupa(object sender, RoutedEventArgs e)
        {

        }

        private void teclaApretada(object sender, KeyEventArgs e)
        {

        }

        private void dobleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
