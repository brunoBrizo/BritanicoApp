using BibliotecaBritanico.Modelo;
using BibliotecaBritanico.Utilidad;
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
        Funcionario func;
        TipoTransferencia tt;
        public VentanaFuncionario(Window v, Funcionario f, TipoTransferencia tt)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            ventana = v;
            func = f;
            this.tt = tt;
            CargarComboBox();
            if (func != null)
            {
                CargarDatosFuncionario();
            }
        }

        private void CargarDatosFuncionario()
        {
            if (func != null)
            {
                txtNombre.Text = func.Nombre;
                txtTelefonoUno.Text = func.Telefono;
                txtTelefonoDos.Text = func.TelefonoAux;
                txtDireccion.Text = func.Direccion;
                txtCorreo.Text = func.Email;
                txtDocumento.Text = func.CI;
                txtClave.Text = func.Clave;
                dpFechaNac.Text = func.FechaNac.ToShortDateString();
                int i = 0;
                bool encontrado = false;
                while (i < cbTipoFunc.Items.Count && !encontrado)
                {
                    FuncionarioTipo ft;
                    Enum.TryParse<FuncionarioTipo>(cbTipoFunc.Items[i].ToString(), out ft);
                    if (ft == func.TipoFuncionario)
                    {
                        encontrado = true;
                        cbTipoFunc.SelectedIndex = i;
                    }
                    i++;
                }
                encontrado = false;
                i = 0;
                if (func.Sucursal != null)
                {
                    while (i < cbSucursal.Items.Count && !encontrado)
                    {
                        if (((Sucursal)cbSucursal.Items[i]).ID == func.Sucursal.ID)
                        {
                            encontrado = true;
                            cbSucursal.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                if (func.Activo) chkActivo.IsChecked = true;
                else chkActivo.IsChecked = false;
            }
        }

        private void CargarComboBox()
        {
            List<Sucursal> listaSucursales = fachada.GetSucursalesTotal();
            cbSucursal.ItemsSource = listaSucursales;
            List<string> listaTipoFuncionarios= Enum.GetNames(typeof(FuncionarioTipo)).ToList();
            cbTipoFunc.ItemsSource = listaTipoFuncionarios;
            cbTipoFunc.SelectedIndex = 0;
            cbSucursal.SelectedIndex = 1;
        }

        private  async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string telefono=txtTelefonoUno.Text;
            string telefono2=txtTelefonoDos.Text;
            string direccion=txtDireccion.Text;
            string correo=txtCorreo.Text;
            string cedula=txtDocumento.Text;
            DateTime fechaNac = DateTime.MinValue;
            DateTime.TryParse(dpFechaNac.Text, out fechaNac);
            string clave = txtClave.Text;
            FuncionarioTipo ft =(FuncionarioTipo)Enum.Parse(typeof(FuncionarioTipo), (cbTipoFunc.SelectedItem).ToString());


            Sucursal suc = (Sucursal)cbSucursal.SelectedItem;
            bool activo = (bool)chkActivo.IsChecked;
            try
            {
                Funcionario f= await fachada.CrearFuncionario(suc.ID, nombre, cedula, correo, telefono, telefono2, direccion, fechaNac, clave, activo, ft);
                LevantarPopUp(TipoMensaje.Info, "Se creo el funcionario correctamente");
            }catch(ValidacionException ex)
            {
                LevantarPopUp(TipoMensaje.Error, "se produjo un error\n\n "+ex.Message);
            }

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


        private void LevantarPopUp(TipoMensaje tm, string mensaje)
        {
            PopUpVentana pv = new PopUpVentana(mensaje, tm, 2000, 40, (((int)fachada.Tamano.Width) + 160), (int)fachada.Tamano.Height);
            pv.Show();
        }

        private void AsignarMayusculas(object sender, RoutedEventArgs e)
        {
            TextBox elTextBoxQueEnvia = (TextBox)sender;
            string texto = elTextBoxQueEnvia.Text;
            elTextBoxQueEnvia.Text = Herramientas.ColocarMayusculas(texto);
        }
    }
}
