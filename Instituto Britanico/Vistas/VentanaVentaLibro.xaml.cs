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
using System.Windows.Shapes;

namespace Instituto_Britanico.Vistas
{
    /// <summary>
    /// Lógica de interacción para VentaLibro.xaml
    /// </summary>
    public partial class VentanaVentaLibro : Window, TransferenciaObjeto, IBrillo
    {

        Estudiante est;
        Fachada fachada;
        Window ventana;
        Libro libro;
        public VentanaVentaLibro(Window v)
        {

            InitializeComponent();
            fachada = Fachada.getInstancia();
            this.ventana = v;
            CargarLibros();
            
        }

        private void CargarLibros()
        {
            List<Libro> listaLibros = fachada.GetLibrosTotal();
            grillaLibros.ItemsSource = null;
            grillaLibros.ItemsSource = listaLibros;
        }

        private void TeclaEnCedula(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                List<Estudiante> lista = fachada.GetEstudiantesPorCedula(txtCedula.Text);
                if (lista != null)
                {
                    if (lista.Count == 0)
                    {
                        LevantarPopUp(TipoMensaje.Alerta, "No se encontraron estudiantes con ese numero de cedula");
                    }
                    else if (lista.Count == 1)
                    {
                        CambiarEstudiante(lista[0]);
                        txtNombre.Text = est.Nombre;
                        txtCedula.Text = est.CI;
                    }
                    else if (lista.Count > 1)
                    {
                        Oscurecer();
                        PickerEstudiante pe = new PickerEstudiante(this, lista, this);
                        pe.Owner = this;
                        pe.Closed += Pe_Closed;
                        pe.ShowDialog();
                    }
                }
            }
                
        }

        private void Pe_Closed(object sender, EventArgs e)
        {
            Aclarar();
        }

        private void TeclaEnNombre(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                List<Estudiante> lista = fachada.GetEstudiantesPorNombre(txtNombre.Text);
                if (lista != null)
                {
                    if (lista.Count == 0)
                    {
                        LevantarPopUp(TipoMensaje.Alerta, "No se encontraron estudiantes con ese nombre");
                    }
                    else if (lista.Count == 1)
                    {
                        CambiarEstudiante(lista[0]);
                        
                        txtCedula.Text = est.CI;
                        txtNombre.Text = est.Nombre;
                    }
                    else if (lista.Count > 1)
                    {
                        Oscurecer();
                        PickerEstudiante pe = new PickerEstudiante(this, lista, this);
                        pe.Owner = this;
                        pe.Closed += Pe_Closed;
                        pe.ShowDialog();
                    }
                }
            }
        }

        void CambiarEstudiante(Estudiante es)
        {
            this.est = es;
            lblEstudiante.Content = "Estudiante : " + est.Nombre;
        }
      

        private void TeclaEnVentana(object sender, KeyEventArgs e)
        {

        }

        private void DobleClickEnLibro(object sender, MouseButtonEventArgs e)
        {
            if (grillaLibros.SelectedIndex > -1)
            {
                libro = (Libro)grillaLibros.SelectedItems[0];
                txtLibro.Text = libro.Nombre;
            }
        }

        public void RecibirObjeto(object o, TipoTransferencia tt)
        {
            if (o != null)
            {
                if (o is Estudiante)
                {
                    CambiarEstudiante((Estudiante)o);
                    txtCedula.Text = est.CI;
                    txtNombre.Text = est.Nombre;
                }

            }
        }
        private void LevantarPopUp(TipoMensaje tm, string mensaje)
        {
            PopUpVentana pv = new PopUpVentana(mensaje, tm, 2000, 40, (((int)fachada.Tamano.Width) + 160), (int)fachada.Tamano.Height);
            pv.Show();
        }
        public void Oscurecer()
        {
            OscurecerPantalla();
        }

        public void Aclarar()
        {
            AclararPantalla();
        }

        private async void OscurecerPantalla()
        {
            int tiempoDesaparece = 20;
            bool minimo = false;
            int tiempo = tiempoDesaparece;
            double n = 1;
            while (!minimo)
            {
                if (await Espera(tiempo)) this.Opacity = n;
                n = n - 0.02;
                if (n > 0.2 && n < 0.22)
                {
                    minimo = true;
                }
            }
        }

        private async void AclararPantalla()
        {
            int tiempoDesaparece = 10;
            bool maximo = false;
            int tiempo = tiempoDesaparece;
            double n = .22;
            while (!maximo)
            {
                if (await Espera(tiempo)) this.Opacity = n;
                n = n + 0.02;
                if (n > .98)
                {
                    maximo = true;
                }
            }
        }

        private async Task<bool> Espera(int tiempo)
        {
            bool termino = false;
            await Task.Run(() => {
                termino = true;
                Thread.Sleep(tiempo);
            }
            );
            return termino;
        }

        private void ClickEnPagar(object sender, RoutedEventArgs e)
        {
            string mensaje = string.Empty;
            if (libro==null)
            {
                mensaje += "Debe seleccionar un libro\n\n";
            }
            if (est == null)
            {
                mensaje += "Datos de estudiante incorrectos";
            }
            if (mensaje == string.Empty)
            {
                GrabarVentaLibro();
            }
            else
            {
                LevantarPopUp(TipoMensaje.Alerta, mensaje);
            }
        }


        private void FocoNombre(object sender, RoutedEventArgs e)
        {
           
        }

        private void FocoCedula(object sender, RoutedEventArgs e)
        {
        
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        void GrabarVentaLibro()
        {
            SpinnerCargando sc = new SpinnerCargando();
            sc.Owner = this;
            sc.Show();

            LevantarPopUp(TipoMensaje.Info, "hacer cosas para grabar venta, datos ok");
        }
    }
}
