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
    /// Lógica de interacción para VentanaExamenes.xaml
    /// </summary>
    public partial class VentanaExamenes : Window
    {

        Fachada fachada;
        Window ventana;

        public VentanaExamenes(Window v)
        {
            InitializeComponent();
            ventana = v;
            fachada = Fachada.getInstancia();
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            List<Grupo> listaGrupos = fachada.GetGruposTotalb();
            cbGrupos.ItemsSource = listaGrupos;

        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
          
        }
    }
}
