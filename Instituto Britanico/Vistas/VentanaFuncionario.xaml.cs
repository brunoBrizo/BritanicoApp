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
    /// Lógica de interacción para VentanaFuncionario.xaml
    /// </summary>
    public partial class VentanaFuncionario : Window
    {

        Fachada fachada;
        Window ventana;
        public VentanaFuncionario(Window v)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            ventana = v;
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            List<Sucursal> listaSucursales = fachada.GetSucursalesTotal();
            cbSucursal.ItemsSource = listaSucursales;
            List<string> listaTipoFuncionarios= Enum.GetNames(typeof(FuncionarioTipo)).ToList();
            cbTipoFunc.ItemsSource = listaTipoFuncionarios;

        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                //agregar logica para que evalue si esta haciendo un ingreso o editando
                this.Close();
            }
        }
        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
