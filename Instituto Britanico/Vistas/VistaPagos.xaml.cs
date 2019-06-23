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
    /// Lógica de interacción para VistaPagos.xaml
    /// </summary>
    public partial class VistaPagos : UserControl
    {

        Fachada fachada;
        Window ventana;
        int Alto, Ancho;

        public VistaPagos( Window v)
        {
            InitializeComponent();
            ventana = v;
            fachada = Fachada.getInstancia();

            CargarDatos();
            Loaded += VistaPagos_Loaded;
            


        }

        private void VistaPagos_Loaded(object sender, RoutedEventArgs e)
        {
            Ancho = (int)fachada.Tamano.Width;
            Alto = (int)fachada.Tamano.Height - 20;
            borde.Height = Alto - 20;
            
        }

        private void CargarDatos()
        {
            List<Sucursal> listaSucursales = fachada.GetSucursalesTotal();
            cbSucursal.ItemsSource = listaSucursales;
            List<Pago> listaPagos = fachada.GetPagosTotal();
            dgPagos.ItemsSource = listaPagos;
        }

        private void BtnIngresarPago_Click(object sender, RoutedEventArgs e)
        {
            VentanaPagos vp = new VentanaPagos(null);
            vp.Owner = ventana;
            vp.ShowDialog();
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

        private void ClickEnVerLupa(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string concepto = txtConcepto.Text;
            decimal minimo = 0;
            decimal maximo = 0;
            decimal.TryParse(txtMontoInicial.Text, out minimo);
            decimal.TryParse(txtMontoFinal.Text, out maximo);
            DateTime fechaInicial = DateTime.MinValue;
            DateTime fechaFinal = DateTime.MinValue;
            DateTime.TryParse(dpInicio.Text, out fechaInicial);
            DateTime.TryParse(dpFinal.Text, out fechaFinal);
            Sucursal suc =(Sucursal)cbSucursal.SelectedItem;
            List<Pago> lista = fachada.GetPagosPorFiltro(concepto, suc, minimo, maximo, fechaInicial, fechaFinal);
            dgPagos.ItemsSource = lista;
        }

        private void BtnLimpiarFiltros_Click(object sender, RoutedEventArgs e)
        {
            cbSucursal.SelectedIndex = 0;
            txtConcepto.Text = "";
            dpFinal.Text = "";
            dpInicio.Text = "";
            txtMontoFinal.Text = "";
            txtMontoInicial.Text = "";

        }

        private void TeclaEnConcepto(object sender, KeyEventArgs e)
        {

        }
    }
}
