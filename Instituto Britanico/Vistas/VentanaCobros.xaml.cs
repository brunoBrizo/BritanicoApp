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
    /// Lógica de interacción para VentanaCobros.xaml
    /// </summary>
    public partial class VentanaCobros : Window
    {
        Fachada fachada;
        public VentanaCobros()
        {
            fachada = Fachada.getInstancia();
            InitializeComponent();
            List<Grupo> grupos = fachada.GetGruposTotalb();
            lbGrupos.ItemsSource = grupos;
            lbMeses.ItemsSource = Enum.GetValues(typeof(Mes));
        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LbGrupos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtGrupo.Content = ((Grupo)lbGrupos.SelectedItem).Nombre;
        }

        private void LbMeses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtMes.Content = ((Mes)lbMeses.SelectedItem).ToString();
        }

        private void TxtCedulaMensualidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                List<Estudiante> lista = fachada.GetEstudiantesPorCedula(txtCedulaMensualidad.Text);
                if (lista.Count > 1) { AbrirPickerEstudiante(); }
                if (lista.Count == 0) LevantarPopUp(TipoMensaje.Alerta, "No se encontraron estudiantes con el numero de cedula ingresado");
                if (lista.Count == 1) txtNombre.Content = lista[0].Nombre;
                
            }
        }

        private void AbrirPickerEstudiante()
        {
            LevantarPopUp(TipoMensaje.Error, "Tendria que levantar un picker estudiante aqui, no implementado");
        }

        private void LevantarPopUp(TipoMensaje tm, string mensaje)
        {
            PopUpVentana pv = new PopUpVentana(mensaje, tm, 2000, 40, (((int)fachada.Tamano.Width) + 160), (int)fachada.Tamano.Height);
            pv.Show();
        }
    }
}
