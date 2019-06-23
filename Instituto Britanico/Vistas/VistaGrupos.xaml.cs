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
    /// Lógica de interacción para VistaGrupos.xaml
    /// </summary>
    public partial class VistaGrupos : UserControl, IBrillo, TransferenciaObjeto
    {
        Window ventana;
        Fachada fachada;
        int Alto, Ancho, pagina, cantidadPorPagina;
        IBrillo brillo;
        List<Grupo> lista;

        public VistaGrupos(Window v)
        {
            InitializeComponent();
            this.ventana = v;
            brillo = (IBrillo)v;
            fachada = Fachada.getInstancia();
            Loaded += VistaGruposLoaded;
        }

        private void VistaGruposLoaded(object sender, RoutedEventArgs e)
        {
            Ancho = (int)fachada.Tamano.Width;
            Alto = (int)fachada.Tamano.Height;
            borde.Height = Alto - 20;
            borde.Width = Ancho - 20;
            cantidadPorPagina = 20;
            pagina = 0;
            lista = fachada.GetGruposTotalb();
            EnviarListaAPantalla(0);
        }

        


        private void teclaApretada(object sender, KeyEventArgs e)
        {

        }


     



        private void dobleClick(object sender, MouseButtonEventArgs e)
        {
            Grupo gru = (Grupo)dgGrupos.SelectedCells[0].Item;
            VentanaGrupo v = new VentanaGrupo(ventana, gru, TipoTransferencia.Mostrar, this);
            v.Owner = ventana;
            brillo.Oscurecer();
            v.Closed += AclararBrillo;
            v.ShowDialog();
        }

        private void ClickEnEditar(object sender, RoutedEventArgs e)
        {

            Grupo gru = (Grupo)dgGrupos.SelectedCells[0].Item;
            VentanaGrupo v = new VentanaGrupo(ventana, gru, TipoTransferencia.Edicion, this);
            v.Owner = ventana;
            brillo.Oscurecer();
            v.Closed += AclararBrillo;
            v.ShowDialog();

        }

        private void AclararBrillo(Object sender, EventArgs e)
        {
            brillo.Aclarar();
        }


        private void BtnIngreso(object sender, RoutedEventArgs e)
        {
            VentanaGrupo v = new VentanaGrupo(ventana, null, TipoTransferencia.Nuevo, this);
            brillo.Oscurecer();
            v.Closed += AclararBrillo;
            v.Owner = ventana;
            v.Show();
        }
        private void TeclaEnNombre(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                lista = fachada.GetGruposPorNombre(txtNombre.Text);
                pagina = 0;
                EnviarListaAPantalla(0);
            }
        }

        private void ClickEnVerLupa(object sender, RoutedEventArgs e)
        {
            Grupo gru = (Grupo)dgGrupos.SelectedCells[0].Item;
            VentanaGrupo v = new VentanaGrupo(ventana, gru, TipoTransferencia.Mostrar, this);
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
            if (((pagina + 1) * cantidadPorPagina) >= lista.Count) btnSiguiente.IsEnabled = false;
            else btnSiguiente.IsEnabled = true;
            List<Grupo> listaAuxiliar = lista.Skip(saltear).Take(cantidadPorPagina).ToList();
            int totalPaginas = lista.Count / cantidadPorPagina;
            if (lista.Count > (totalPaginas * cantidadPorPagina)) totalPaginas++;
            txtInfo.Content = "Total de elementos en el listado : " + lista.Count + ", mostrando pagina : " + (pagina + 1) + " de " + totalPaginas;
            dgGrupos.ItemsSource = listaAuxiliar;

        }

        public void Oscurecer()
        {
            brillo.Oscurecer();
        }

        public void Aclarar()
        {
            brillo.Aclarar();
        }

        public void RecibirObjeto(object o, TipoTransferencia tt)
        {
            if(o is Grupo)
            {
                if (tt == TipoTransferencia.Borrar)
                {
                    Grupo g = (Grupo)o;
                    if (lista.Contains(g))
                    {
                        lista.Remove(g);
                        EnviarListaAPantalla(0);
                    }
                }
            }
        }
    }
}
