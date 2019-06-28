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
    /// Lógica de interacción para VistaExamenes.xaml
    /// </summary>
    public partial class VistaExamenes : UserControl, IBrillo, TransferenciaObjeto
    {
        Window ventana;
        Fachada fachada;
        int Alto, Ancho;
        IBrillo brillo;

        public VistaExamenes(Window v)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            this.ventana = v;
            brillo = (IBrillo)v;
            CargarLista();
            Loaded += VistaExamenes_Loaded;

        }

        private void CargarLista()
        {

            List<Grupo> listaGrupos = fachada.GetGruposTotalb();
            cbGrupo.Items.Clear();
            cbGrupo.ItemsSource = listaGrupos;
            List<Examen> listaExamenes = fachada.GetExamenesTotal();
            dgExamenes.ItemsSource = listaExamenes;

        }

        private void VistaExamenes_Loaded(object sender, RoutedEventArgs e)
        {
            Ancho = (int)fachada.Tamano.Width;
            Alto = (int)fachada.Tamano.Height - 20;
            borde.Height = Alto - 20;

        }

        private void TeclaEnAnio(object sender, KeyEventArgs e)
        {

        }

        private void teclaApretada(object sender, KeyEventArgs e)
        {

        }

        private void dobleClick(object sender, MouseButtonEventArgs e)
        {
            Examen exa = (Examen)dgExamenes.SelectedItems[0];
            VentanaExamenes ve = new VentanaExamenes(ventana, exa, TipoTransferencia.Mostrar, this);
            ve.Owner = ventana;
            Oscurecer();
            ve.Closed += Ve_Closed;
            ve.Show();
        }

        private void CambioCBGrupo(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClickEnEditar(object sender, RoutedEventArgs e)
        {
            Examen exa = (Examen)dgExamenes.SelectedItems[0];
            VentanaExamenes ve = new VentanaExamenes(ventana, exa, TipoTransferencia.Edicion, this);
            ve.Owner = ventana;
            Oscurecer();
            ve.Closed += Ve_Closed;
            ve.Show();
        }

        private void ClickEnVerLupa(object sender, RoutedEventArgs e)
        {
            Examen exa = (Examen)dgExamenes.SelectedItems[0];
            VentanaExamenes ve = new VentanaExamenes(ventana, exa, TipoTransferencia.Mostrar, this);
            ve.Owner = ventana;
            Oscurecer();
            ve.Closed += Ve_Closed;
            ve.Show();
        }

        private void Ve_Closed(object sender, EventArgs e)
        {
            Aclarar();
        }

        private void BtnIngresoExamen_Click(object sender, RoutedEventArgs e)
        {
            
            VentanaExamenes ve = new VentanaExamenes(ventana, null, TipoTransferencia.Nuevo, this);
            ve.Owner = ventana;
            ve.Show();
        }

        public void Oscurecer()
        {
            brillo.Oscurecer();
        }

        public void Aclarar()
        {
            brillo.Aclarar();        }

        public void RecibirObjeto(object o, TipoTransferencia tt)
        {
       
        }
    }
}
