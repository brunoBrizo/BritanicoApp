using BibliotecaBritanico.Modelo;
using Instituto_Britanico.Interfaces;
using Instituto_Britanico.Modelo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para Estudiantes.xaml
    /// </summary>
    public partial class VistaEstudiantes : UserControl, IEstudiante 
    {
        Window ventana;
        Fachada fachada;
        int Alto { get; set; }
        int Ancho { get; set; }
        int pagina = 1;
        int cantidadPorPagina = 20;
        List<Estudiante> listaEstudiantes;
        IBrillo brillo;

        public VistaEstudiantes(Window w)
        {
            InitializeComponent();
            Loaded += Estudiantes_Loaded;
            ventana = w;
            brillo = (IBrillo)w;
        }

        private async void Estudiantes_Loaded(object sender, RoutedEventArgs e)
        {
            fachada = await Fachada.getInstanciaAsync();
            CargarLista();
            Ancho = (int)fachada.Tamano.Width;
            Alto = (int)fachada.Tamano.Height;
            borde.Height = Alto - 20;
            borde.Width = Ancho - 20;
        }

        private async void CargarLista()
        {
            listaEstudiantes = await fachada.GetEstudiantes();
            List<Grupo> listaGrupos = fachada.GetGrupos();
            cbGrupo.ItemsSource = listaGrupos;
            pagina = 0;
            EnviarListaAPantalla(0);
        }

        private void teclaApretada(object sender, KeyEventArgs e)
        {

        }
               
        private void ClickEnCorreo(object sender, RoutedEventArgs e)
        {
            Estudiante est = (Estudiante)dgEstudiantes.SelectedCells[0].Item;
            VentanaCorreoRapido v = new VentanaCorreoRapido(ventana, est);
            brillo.Oscurecer();
            v.Closed += AclararBrillo;
            v.Owner = ventana;
            v.ShowDialog();
        }

        private void CambioCBGrupo(object sender, SelectionChangedEventArgs e)
        {
            Grupo g = (Grupo)cbGrupo.SelectedItem;
            try
            {
                listaEstudiantes = fachada.GetEstudiantesPorGrupo(g);
            }catch(Exception ex)
            {
                throw ex;
            }
            pagina = 0;
            EnviarListaAPantalla(0);
        }
               
        public void RecibirEstudiante(Estudiante e, TipoTransferencia tt)
        {
            if (tt == TipoTransferencia.Borrar)
            {
                if (listaEstudiantes.Contains(e))
                {
                    listaEstudiantes.Remove(e);
                }
                EnviarListaAPantalla(0);
            }
        }

        private void TeclaEnCedula(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                listaEstudiantes = fachada.GetEstudiantesPorCedula(txtCedula.Text);
                pagina = 0;
                EnviarListaAPantalla(0);
            }
        }




        #region metodos comunes

        
        private void dobleClick(object sender, MouseButtonEventArgs e)
        {
            Estudiante est = (Estudiante)dgEstudiantes.SelectedCells[0].Item;
            VentanaEstudiante v = new VentanaEstudiante(ventana, est, TipoTransferencia.Mostrar, this);
            v.Owner = ventana;
            brillo.Oscurecer();
            v.Closed += AclararBrillo;
            v.ShowDialog();
        }

        private void ClickEnEditar(object sender, RoutedEventArgs e)
        {
            Estudiante est = (Estudiante)dgEstudiantes.SelectedCells[0].Item;
            VentanaEstudiante v = new VentanaEstudiante(ventana, est, TipoTransferencia.Edicion, this);
            v.Owner = ventana;
            brillo.Oscurecer();
            v.Closed += AclararBrillo;
            v.ShowDialog();

        }

        private void AclararBrillo(Object sender, EventArgs e)
        {
            brillo.Aclarar();
        }
        
        private void BtnIngresoEstudiante_Click(object sender, RoutedEventArgs e)
        {
            VentanaEstudiante v = new VentanaEstudiante(ventana, null, TipoTransferencia.Nuevo, this);
            brillo.Oscurecer();
            v.Closed += AclararBrillo;
            v.Owner = ventana;
            v.Show();
        }

        private void TeclaEnNombre(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                listaEstudiantes = fachada.GetEstudiantesPorNombre(txtNombre.Text);
                pagina = 0;
                EnviarListaAPantalla(0);
            }
        }

        private void ClickEnVerLupa(object sender, RoutedEventArgs e)
        {
            Estudiante est = (Estudiante)dgEstudiantes.SelectedCells[0].Item;
            VentanaEstudiante v = new VentanaEstudiante(ventana, est, TipoTransferencia.Mostrar, this);
            v.Owner = ventana;
            brillo.Oscurecer();
            v.Closed += AclararBrillo;
            v.ShowDialog();
        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {
            EnviarListaAPantalla(-1);
        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            EnviarListaAPantalla(1);
        }

        internal void EnviarListaAPantalla(int i)
        {
            int saltear = 0;
            if (i < 1)
            {
                if (pagina > 0) saltear = (pagina + i) * cantidadPorPagina;
            }
            else
            {
                saltear = (pagina + i) * cantidadPorPagina;
            }
            if (pagina >= 0) pagina = pagina + i;
            if (pagina == 0) btnAtras.IsEnabled = false;
            else btnAtras.IsEnabled = true;
            if (((pagina + 1) * cantidadPorPagina) >= listaEstudiantes.Count) btnSiguiente.IsEnabled = false;
            else btnSiguiente.IsEnabled = true;
            List<Estudiante> lista = listaEstudiantes.Skip(saltear).Take(cantidadPorPagina).ToList();
            int totalPaginas = listaEstudiantes.Count / cantidadPorPagina;
            if (listaEstudiantes.Count > (totalPaginas * cantidadPorPagina)) totalPaginas++;
            txtInfo.Content = "Total de elementos en el listado : " + listaEstudiantes.Count + ", mostrando pagina : " + (pagina + 1) + " de " + totalPaginas;
            dgEstudiantes.ItemsSource = lista;

        }


        #endregion

    }
}
