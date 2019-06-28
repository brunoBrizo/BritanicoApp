using BibliotecaBritanico.Modelo;
using Instituto_Britanico.Interfaces;
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
    /// Lógica de interacción para VistaFuncionario.xaml
    /// </summary>
    public partial class VistaFuncionario : UserControl
    {

        Fachada fachada;
        int Alto { get; set; }
        int Ancho { get; set; }
        Window Ventana;
        IBrillo brillo;

        public VistaFuncionario(Window v)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            Loaded += VistaFuncionario_Loaded;
            brillo = (IBrillo)v;
            CargarLista();
            this.Ventana = v;
        }

        private void CargarLista()
        {
            List<Sucursal> lista = fachada.GetSucursalesTotal();
            cbSucursal.ItemsSource = lista;
            List<Funcionario> listaFuncionarios = fachada.GetFuncionariosTotal();
            dgFuncionarios.ItemsSource = listaFuncionarios;

        }

        private void VistaFuncionario_Loaded(object sender, RoutedEventArgs e)
        {
            Ancho = (int)fachada.Tamano.Width;
            Alto = (int)fachada.Tamano.Height;
            borde.Height = Alto-20 ;
        }

        private void CbSucursal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnIngresarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            VentanaFuncionario vf = new VentanaFuncionario(Ventana, null, TipoTransferencia.Nuevo);
            vf.Owner = Ventana;
            brillo.Oscurecer();
            vf.Closed += Vf_Closed;
            vf.ShowDialog();
        }

        private void Vf_Closed(object sender, EventArgs e)
        {
            brillo.Aclarar();
        }

        private void teclaApretada(object sender, KeyEventArgs e)
        {

        }

        private void dobleClick(object sender, MouseButtonEventArgs e)
        {
            Funcionario f = (Funcionario)dgFuncionarios.SelectedItems[0];
            VentanaFuncionario vf = new VentanaFuncionario(Ventana, f, TipoTransferencia.Mostrar);
            vf.Owner = Ventana;
            brillo.Oscurecer();
            vf.Closed += Vf_Closed;
            vf.ShowDialog();

        }

        private void ClickEnEditar(object sender, RoutedEventArgs e)
        {
            Funcionario f = (Funcionario)dgFuncionarios.SelectedItems[0];
            VentanaFuncionario vf = new VentanaFuncionario(Ventana, f, TipoTransferencia.Edicion);
            vf.Owner = Ventana;
            brillo.Oscurecer();
            vf.Closed += Vf_Closed;
            vf.ShowDialog();
        }

        private void ClickEnVerLupa(object sender, RoutedEventArgs e)
        {
            Funcionario f = (Funcionario)dgFuncionarios.SelectedItems[0];
            VentanaFuncionario vf = new VentanaFuncionario(Ventana, f, TipoTransferencia.Mostrar);
            vf.Owner = Ventana;
            brillo.Oscurecer();
            vf.Closed += Vf_Closed;
            vf.ShowDialog();
        }

        private void ClickEnCorreo(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TeclaEnNombre(object sender, KeyEventArgs e)
        {

        }

        private void TeclaEnCedula(object sender, KeyEventArgs e)
        {

        }

        private void ChkActivos_Click(object sender, RoutedEventArgs e)
        {
            /*
            if ((bool)chkActivos.IsChecked)
            {
                List<Funcionario> lista= fachada.GetFuncionariosActivos();
                dgFuncionarios.ItemsSource = null;
                dgFuncionarios.ItemsSource = lista;
            }
            else
            {
                List<Funcionario> lista = fachada.GetFuncionariosNoActivos();
                dgFuncionarios.ItemsSource = null;
                dgFuncionarios.ItemsSource = lista;
            }
            */
        }

        private void GrupoRadioButtonClicked(object sender, RoutedEventArgs e)
        {
            List<Funcionario> lista = new List<Funcionario>();
            if ((bool)rbTodos.IsChecked)
            {
                lista = fachada.GetFuncionariosTotal();
            }else if ((bool)rbActivos.IsChecked)
            {
                lista = fachada.GetFuncionariosActivos();
            }else if ((bool)rbNoActivos.IsChecked)
            {
                lista = fachada.GetFuncionariosNoActivos();
            }
            dgFuncionarios.ItemsSource = null;
            dgFuncionarios.ItemsSource = lista;



        }
    }
}
