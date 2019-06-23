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
using System.Windows.Shapes;

namespace Instituto_Britanico.Vistas
{
    /// <summary>
    /// Lógica de interacción para VentanaPagos.xaml
    /// </summary>
    public partial class VentanaPagos : Window
    {
        Fachada fachada;
        Pago pago;

        public VentanaPagos(Pago p)
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-Uy");
            fachada = Fachada.getInstancia();
            pago = p;
            CargarCombobox();
            Loaded += VentanaPagos_Loaded;

        }

        private void VentanaPagos_Loaded(object sender, RoutedEventArgs e)
        {
      
        }

        private void CargarCombobox()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            if (pago != null) listaFuncionarios = fachada.GetFuncionariosTotal();
            else listaFuncionarios = fachada.GetFuncionariosActivos();
            cbFuncionario.ItemsSource = listaFuncionarios;
            List<Sucursal> listaSucursal = fachada.GetSucursalesTotal();
            cbSucursal.ItemsSource = listaSucursal;
        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PresetTimePicker_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {

        }
      
    }
}
