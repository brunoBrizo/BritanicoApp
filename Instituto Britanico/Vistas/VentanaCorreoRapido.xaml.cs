using BibliotecaBritanico.Modelo;
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
        public VentanaCorreoRapido(Window v, Estudiante est)
        {
            InitializeComponent();
            this.est = est;
            ventana = v;
            this.txtCorreo.Text = est.Email;
            this.txtNombre.Text = est.Nombre;
        }
        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TeclaEnVentana(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
