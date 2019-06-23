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
    /// Lógica de interacción para VistaConvenios.xaml
    /// </summary>
    public partial class VistaConvenios : UserControl
    {


        Fachada fachada;
        Window ventana;
        public VistaConvenios(Window v)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            CargarDatos();

        }

        private void CargarDatos()
        {
            List<Convenio> lista = fachada.GetConveniosTotal();
            dgConvenios.ItemsSource = lista;
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

        private void BtnIngresarConvenio_Click(object sender, RoutedEventArgs e)
        {
            VentanaConvenio vc = new VentanaConvenio(ventana, null, TipoTransferencia.Nuevo);
            vc.Owner = ventana;
            vc.ShowDialog();
        }
    }
}
