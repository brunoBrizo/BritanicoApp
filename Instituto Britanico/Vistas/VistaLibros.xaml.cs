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
    /// Lógica de interacción para VistaLibros.xaml
    /// </summary>
    public partial class VistaLibros : UserControl, IBrillo, TransferenciaObjeto
    {

        Window ventana;
        Fachada fachada;
        int Alto, Ancho, pagina, cantidadPorPagina;
        IBrillo brillo;
        List<Libro> lista;

        public VistaLibros(Window v)
        {
            InitializeComponent();
            this.ventana = v;
            brillo = (IBrillo)v;
            fachada = Fachada.getInstancia();
            Loaded += VistaCargada; ;
        }

        private void VistaCargada(object sender, RoutedEventArgs e)
        {

            Ancho = (int)fachada.Tamano.Width;
            Alto = (int)fachada.Tamano.Height;
            borde.Height = Alto - 20;
            borde.Width = Ancho - 20;
            cantidadPorPagina = 20;
            pagina = 0;
            lista = fachada.GetLibrosTotal();
            EnviarListaAPantalla(0);
        }


        private void BtnIngresoLibro_Click(object sender, RoutedEventArgs e)
        {
            VentanaLibro v = new VentanaLibro(ventana, null, TipoTransferencia.Nuevo, this); ;
            v.Owner = ventana;
            brillo.Oscurecer();
            v.Closed += AclararBrillo; ;
            v.ShowDialog();
        }

        private void ClickEnEditar(object sender, RoutedEventArgs e)
        {
            Libro lib = (Libro)dgLibros.SelectedCells[0].Item;
            VentanaLibro v = new VentanaLibro(ventana, lib, TipoTransferencia.Edicion, this);
            v.Owner = ventana;
            brillo.Oscurecer();
            v.Closed += AclararBrillo; ;
            v.ShowDialog();
        }


        private void dobleClick(object sender, MouseButtonEventArgs e)
        {
            Libro lib = (Libro)dgLibros.SelectedCells[0].Item;
            VentanaLibro v = new VentanaLibro(ventana, lib, TipoTransferencia.Mostrar, this);
            v.Owner = ventana;
            brillo.Oscurecer();
            v.Closed += AclararBrillo; ;
            v.ShowDialog();
        }
        private void ClickEnVerLupa(object sender, RoutedEventArgs e)
        {
            Libro lib = (Libro)dgLibros.SelectedCells[0].Item;
            VentanaLibro v = new VentanaLibro(ventana, lib, TipoTransferencia.Mostrar, this);
            v.Owner = ventana;
            brillo.Oscurecer();
            v.Closed += AclararBrillo; ;
            v.ShowDialog();
        }

        private void AclararBrillo(object sender, EventArgs e)
        {
            brillo.Aclarar();
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
            List<Libro> listaAuxiliar = lista.Skip(saltear).Take(cantidadPorPagina).ToList();
            int totalPaginas = lista.Count / cantidadPorPagina;
            if (lista.Count > (totalPaginas * cantidadPorPagina)) totalPaginas++;
          //  txtInfo.Content = "Total de elementos en el listado : " + lista.Count + ", mostrando pagina : " + (pagina + 1) + " de " + totalPaginas;
            dgLibros.ItemsSource = listaAuxiliar;

        }

        private void BtnVentaLibro_Click(object sender, RoutedEventArgs e)
        {
            VentanaVentaLibro vvl = new VentanaVentaLibro(ventana);
            vvl.Owner = ventana;
            brillo.Oscurecer();
            vvl.Closed += AclararBrillo;
            vvl.ShowDialog();
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
            if (o is Libro)
            {
                if (tt == TipoTransferencia.Borrar)
                {
                    Libro g = (Libro)o;
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
