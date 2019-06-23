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
    /// Lógica de interacción para VentanaLibro.xaml
    /// </summary>
    public partial class VentanaLibro : Window
    {
        //libros solo contado 


        Libro libro;
        Fachada fachada;
        TipoTransferencia tt;
        Window ventana;
        TransferenciaObjeto to;
        bool cambioDatos;

        public VentanaLibro(Window v, Libro l, TipoTransferencia tt, TransferenciaObjeto to)
        {
            InitializeComponent();
            this.libro = l;
            this.ventana = v;
            this.tt = tt;
            this.to = to;
            fachada = Fachada.getInstancia();
            CargarCombobox();
            if (tt == TipoTransferencia.Nuevo)
            {
                HabilitarCampos();
            }
            else
            {
                CargarDatos(tt);
            }
            cambioDatos = false;
        }

        private void CargarCombobox()
        {
            List<Materia> lista = fachada.GetMateriasTotal();
            cbMaterias.ItemsSource = lista;
            cbMaterias.SelectedIndex = 1;
            
        }

        private void HabilitarCampos()
        {
            txtAutor.IsEnabled = true;
            txtEditorial.IsEnabled = true;
            txtPrecio.IsEnabled = true;
            txtTitulo.IsEnabled = true;
            cbMaterias.IsEnabled = true;
            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            btnGuardar.Visibility = Visibility.Visible;
            btnEditar.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Visible;
            btnEliminar.Visibility = Visibility.Hidden;
        }

        private void DeshabilitarCampos()
        {
            txtAutor.IsEnabled = false ;
            txtEditorial.IsEnabled = false;
            txtPrecio.IsEnabled = false;
            txtTitulo.IsEnabled = false;
            cbMaterias.IsEnabled = false;
            btnGuardar.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Hidden;
            btnEliminar.Visibility = Visibility.Visible;
        }

        private void CargarDatos(TipoTransferencia tt)
        {
            if (libro != null)
            {
                txtAutor.Text = libro.Autor;
                txtPrecio.Text = libro.Precio + "";
                txtEditorial.Text = libro.Editorial;
                txtTitulo.Text = libro.Nombre;
                int i = 0;
                bool encontrado = false;
                while (i < cbMaterias.Items.Count && !encontrado)
                {
                    if (((Materia)cbMaterias.Items[i]).ID == libro.Materia.ID)
                    {
                        encontrado = true;
                        cbMaterias.SelectedIndex = i;
                    }
                    i++;
                }
            }

            if (tt == TipoTransferencia.Mostrar)
            {
                DeshabilitarCampos();
            }
            if (tt == TipoTransferencia.Edicion)
            {
                HabilitarCampos();
            }
            cambioDatos = false;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string titulo = txtTitulo.Text;
            decimal precio = 0;
            decimal.TryParse(txtPrecio.Text, out precio);
            Materia materia = (Materia)cbMaterias.SelectedItem;
            string autor = txtAutor.Text;
            string editorial = txtEditorial.Text;
            try
            {
                if (tt == TipoTransferencia.Nuevo)
                {
                    Libro lib = fachada.AltaLibro(titulo, materia, precio, autor, editorial);
                    if (lib != null)
                    {
                        LevantarPopUp(TipoMensaje.Info, "El libro se guardo correctamente");
                        VaciarCampos();
                    }
                    else
                    {
                        LevantarPopUp(TipoMensaje.Alerta, "Error al almacenar libro");
                    }
                }
            }
            catch (Exception ex)
            {
                LevantarPopUp(TipoMensaje.Error, ex.Message);
            }
            try
            {
                if (tt == TipoTransferencia.Edicion || tt == TipoTransferencia.Mostrar)
                {
                    Libro modificado = fachada.ModificarLibro(libro.ID, titulo, materia, precio, autor, editorial);
                    if (modificado != null)
                    {
                        LevantarPopUp(TipoMensaje.Info, "Los datos del libro se han modificado correctamente");
                        this.Close();
                    }
                    else
                    {
                        LevantarPopUp(TipoMensaje.Alerta, "Error al intentar modificar los datos del libro");
                    }
                }
            }
            catch (Exception ex)
            {
                LevantarPopUp(TipoMensaje.Error, ex.Message);
            }



        }

        private void VaciarCampos()
        {
            txtAutor.Text = "";
            txtEditorial.Text = "";
            txtPrecio.Text = "";
            txtTitulo.Text = "";
            cbMaterias.SelectedIndex = -1;
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCampos();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (cambioDatos)
            {
                if (MessageBox.Show("Desea cancelar edicion?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (tt == TipoTransferencia.Nuevo) VaciarCampos();
                    if(tt==TipoTransferencia.Mostrar || tt == TipoTransferencia.Edicion)
                    {
                        CargarDatos(tt);
                    }
                }
            }
            else
            {
                if (tt == TipoTransferencia.Mostrar || tt == TipoTransferencia.Edicion)
                {
                    CargarDatos(tt);
                }
            }
           

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) EvaluarCierre();
                
           
        }
        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            EvaluarCierre();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool eliminado = fachada.EliminarLibro(libro.ID);
                if (eliminado)
                {
                    LevantarPopUp(TipoMensaje.Info, "El libro se ha eliminado de la base de datos");
                    this.Close();
                }
                else LevantarPopUp(TipoMensaje.Alerta, "No se pudo eliminar el libro");

            }
            catch (Exception ex)
            {
                LevantarPopUp(TipoMensaje.Error, ex.Message);
            }
        }

        private void EvaluarCierre()
        {
            if (cambioDatos)
            {
                if (MessageBox.Show("Desea cancelar edicion?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            else  this.Close();
        }

        private void CambioDatos(object sender, TextChangedEventArgs e)
        {
            cambioDatos = true;
        }

        private void CbMaterias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cambioDatos = true;
        }

        private void TeclaEnVentana(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void LevantarPopUp(TipoMensaje tm, string mensaje)
        {
            PopUpVentana pv = new PopUpVentana(mensaje, tm, 2000, 40, (((int)fachada.Tamano.Width) + 160), (int)fachada.Tamano.Height);
            pv.Show();
        }
    }
}
