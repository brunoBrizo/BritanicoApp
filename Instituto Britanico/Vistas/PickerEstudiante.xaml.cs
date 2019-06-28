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
using System.Windows.Shapes;

namespace Instituto_Britanico.Vistas
{
    /// <summary>
    /// Lógica de interacción para PickerEstudiante.xaml
    /// </summary>
    public partial class PickerEstudiante : Window
    {
        Fachada fachada;
        List<Estudiante> lista;
        Window ventana;
        TransferenciaObjeto to;
        public PickerEstudiante(Window v, List<Estudiante> lista, TransferenciaObjeto to)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            this.lista = lista;
            this.to = to;
            this.ventana =v;
            CargarDataGrid();
            Loaded += PickerEstudiante_Loaded;
        }

        private void PickerEstudiante_Loaded(object sender, RoutedEventArgs e)
        {
            txtBusqueda.Focus();
        }

        private void CargarDataGrid()
        {
            this.dgEstudiante.ItemsSource = null;
            this.dgEstudiante.ItemsSource = lista;
        }

        private void TeclaEnVentana(object sender, KeyEventArgs e)
        {

        }

        private void VolverEnBlanco(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      

        private void CambioTextoFiltro(object sender, TextChangedEventArgs e)
        {
            if (txtBusqueda.Text != string.Empty)
            {
                List<Estudiante> list = new List<Estudiante>();
                foreach(Estudiante es in lista)
                {
                    if (es.Nombre.ToLower().Contains(txtBusqueda.Text))
                    {
                        list.Add(es);
                    }
                }

                dgEstudiante.ItemsSource = null;
                dgEstudiante.ItemsSource = list;
            }
            else
            {
                dgEstudiante.ItemsSource = null;
                dgEstudiante.ItemsSource = lista;
            }
        }

        private void dobleClick(object sender, MouseButtonEventArgs e)
        {
            Estudiante est = (Estudiante)dgEstudiante.SelectedItems[0];
            to.RecibirObjeto(est, TipoTransferencia.Mostrar);
            this.Close();
        }

        private void teclaApretada(object sender, KeyEventArgs e)
        {

        }

        private void SeleccionarEstudiante(object sender, RoutedEventArgs e)
        {
            int i = dgEstudiante.SelectedIndex;
            if (i > -1)
            {

                Estudiante est = (Estudiante)dgEstudiante.SelectedItems[0];
                to.RecibirObjeto(est, TipoTransferencia.Mostrar);
                this.Close();
            }
            else
            {
                LevantarPopUp(TipoMensaje.Alerta, "Debe seleccionar un estudiante de la lista");
            }

        }
        private void LevantarPopUp(TipoMensaje tm, string mensaje)
        {
            PopUpVentana pv = new PopUpVentana(mensaje, tm, 2000, 40, (((int)fachada.Tamano.Width) + 160), (int)fachada.Tamano.Height);
            pv.Show();
        }
    }
}
