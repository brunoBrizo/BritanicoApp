using BibliotecaBritanico.Modelo;
using BibliotecaBritanico.Utilidad;
using Instituto_Britanico.Controlador;
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
    /// Lógica de interacción para BorrarBoton.xaml
    /// </summary>
    public partial class BorrarBoton : Window
    {
        Fachada fachada;
        public BorrarBoton()
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
         }

        private async void BotonQueHaceCosas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool res = await fachada.EliminarConvenio(3);
                txtResultado.Text = "Se elimino el conv: " + res.ToString();
            }
            catch (Exception ex)
            {
                txtResultado.Text = Herramientas.QuitarComillasDobles(ex.Message);
            }
            
        }
    }
}
