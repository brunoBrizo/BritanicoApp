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
    /// Lógica de interacción para VentanaConvenio.xaml
    /// </summary>
    public partial class VentanaConvenio : Window
    {
        Fachada fachada;
        Convenio convenio;
        Window ventana;
        public VentanaConvenio(Window v, Convenio c, TipoTransferencia tt)
        {
            InitializeComponent();
            ventana = v;
            convenio = c;
            if (c != null)
            {
                CargarDatos(tt);
            }
            

        }

        private void CargarDatos(TipoTransferencia tt)
        {
            
        }
        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
