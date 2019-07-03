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
    /// Lógica de interacción para VentanaCorreoEstudiante.xaml
    /// </summary>
    public partial class VentanaCorreoRapido : Window
    {
        Estudiante est;
        Window ventana;
        Fachada fachada;

        public VentanaCorreoRapido(Window v, Estudiante est)
        {
            InitializeComponent();
            this.est = est;
            ventana = v;
            Loaded += VentanaCorreoRapido_Loaded;
            this.txtCorreo.Text = est.Email;
            this.txtNombre.Text = est.Nombre;
            this.txtNombre.IsEnabled = false;
        }

        private async void VentanaCorreoRapido_Loaded(object sender, RoutedEventArgs e)
        {
            fachada = await Fachada.getInstanciaAsync();
        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TeclaEnVentana(object sender, KeyEventArgs e)
        {
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SpinnerCargando spinner = new SpinnerCargando();
            try
            {
                string errorMsg = String.Empty;
                if (txtCorreo.Text.Equals(String.Empty) || txtAsunto.Text.Equals(String.Empty))
                {
                    errorMsg = "Debe ingresar correo y asunto \n";
                }
                if (txtCuerpoEmail.Text.Equals(String.Empty))
                {
                    errorMsg += "Debe ingresar un mensaje para el email";
                }

                if (!errorMsg.Equals(String.Empty))
                {
                    this.LevantarPopUp(TipoMensaje.Error, errorMsg);
                }
                else
                {
                    spinner.Owner = this;
                    spinner.Show();
                    Email email = await fachada.CrearEmail(txtCorreo.Text, txtNombre.Text, txtAsunto.Text, txtCuerpoEmail.Text);
                    spinner.Close();
                    this.LevantarPopUp(TipoMensaje.Info, "Se envió el email!");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                spinner.Close();
                this.LevantarPopUp(TipoMensaje.Error, ex.Message);
            }
        }

        private void LevantarPopUp(TipoMensaje tm, string mensaje)
        {
            PopUpVentana pv = new PopUpVentana(mensaje, tm, 2000, 40, (((int)fachada.Tamano.Width) + 50), (int)fachada.Tamano.Height - 100);
            pv.Show();
        }
    }
}
