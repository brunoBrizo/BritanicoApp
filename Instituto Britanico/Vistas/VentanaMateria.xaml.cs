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
    /// Lógica de interacción para VentanaMateria.xaml
    /// </summary>
    public partial class VentanaMateria : Window
    {
        Fachada fachada;
        Materia materia;
        List<Libro> listaLibros = new List<Libro>();
        Window ventana;
        TransferenciaObjeto to;
        TipoTransferencia tt;
        bool cambioDatos;

        public VentanaMateria(Window v, Materia mat, TipoTransferencia tt, TransferenciaObjeto to)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            this.to = to;
            this.ventana = v;
            this.tt = tt;
            materia = mat;
            Loaded += VentanaMateria_Loaded;
        }

        private void VentanaMateria_Loaded(object sender, RoutedEventArgs e)
        {
            CargarLibros();
            CargarSucursales();
            if (materia != null)
            {
                CargarDatosMateria();
            }
            if (tt == TipoTransferencia.Mostrar) DeshabilitarBotonesYCampos();
            else HabilitarBotonesYCampos();
        }

        private void CargarDatosMateria()
        {
            if (materia != null)
            {
                txtNombre.Text = materia.Nombre;
                txtPrecio.Text = materia.Precio + "";

                int i = 0;
                bool encontrado = false;
                while (i < cbSucursal.Items.Count && !encontrado)
                {
                    if (((Sucursal)cbSucursal.Items[i]).ID == materia.Sucursal.ID)
                    {
                        encontrado = true;
                        cbSucursal.SelectedIndex = i;
                    }
                    i++;
                }
                if (materia.LstLibros != null)
                {
                    if (materia.LstLibros.Count > 0)
                    {
                        listaLibros.AddRange(materia.LstLibros);
                        dgLibrosAsignados.ItemsSource = null;
                        dgLibrosAsignados.ItemsSource = listaLibros;
                    }
                }
                if (tt == TipoTransferencia.Mostrar)
                {
                    DeshabilitarBotonesYCampos();
                }
            }
            cambioDatos = false;

        }

        private void DeshabilitarBotonesYCampos()
        {
            btnGuardar.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Visible;
            btnEliminar.Visibility = Visibility.Visible;
            txtNombre.IsEnabled = false;
            txtPrecio.IsEnabled = false;
            cbSucursal.IsEnabled = false;
            panelGrillaLibros.Visibility = Visibility.Collapsed;
            this.Height = 470;
            grillaPrincipal.Height = 450;
            dgLibrosAsignados.IsEnabled = false;

        }

        void LimpiarCampos()
        {

            txtNombre.Text = "";
            txtPrecio.Text = "";
            cbSucursal.SelectedIndex = -1;
            dgLibrosAsignados.ItemsSource = null;
            listaLibros.Clear();
        }

        private async Task CargarSucursales()
        {
            List<Sucursal> listaSucursales = await fachada.GetSucursales();
            cbSucursal.ItemsSource = listaSucursales;
        }

        private void CargarLibros()
        {
            List<Libro> lista = fachada.GetLibrosTotal();
            dgLibros.ItemsSource = null;
            dgLibros.ItemsSource = lista;
        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TeclaEnVentana(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) this.Close();
        }

        private void AgregarLibro(object sender, MouseButtonEventArgs e)
        {
            if (dgLibros.SelectedIndex > -1)
            {
                Libro l = (Libro)dgLibros.SelectedItems[0];
                if (!listaLibros.Contains(l))
                {
                    cambioDatos = true;
                    listaLibros.Add(l);
                    dgLibrosAsignados.ItemsSource = null;
                    dgLibrosAsignados.ItemsSource = listaLibros;
                }
            }




        }

        private void ClickEnBorrarLibroDeLista(object sender, RoutedEventArgs e)
        {
            if (dgLibrosAsignados.SelectedIndex > -1)
            {
                var n = dgLibrosAsignados.SelectedItems[0];
                if (n is Libro)
                {
                    cambioDatos = true;
                    Libro l = (Libro)dgLibrosAsignados.SelectedItems[0];
                    listaLibros.Remove(l);
                    dgLibrosAsignados.ItemsSource = null;
                    dgLibrosAsignados.ItemsSource = listaLibros;
                }
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            this.tt = TipoTransferencia.Edicion;
            HabilitarBotonesYCampos();
        }

        private void HabilitarBotonesYCampos()
        {
            btnEliminar.Visibility = Visibility.Hidden;
            btnGuardar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;
            btnEditar.Visibility = Visibility.Hidden;
            txtNombre.IsEnabled = true;
            txtPrecio.IsEnabled = true;
            cbSucursal.IsEnabled = true;
            panelGrillaLibros.Visibility = Visibility.Visible;
            this.Height = 650;
            grillaPrincipal.Height = 630;
            dgLibrosAsignados.IsEnabled = true;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (cambioDatos)
            {
                if (MessageBox.Show("Desea cancelar edicion?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (tt == TipoTransferencia.Nuevo) LimpiarCampos();
                    else
                    {
                        DeshabilitarBotonesYCampos();
                        CargarDatosMateria();
                        cambioDatos = false;
                    }
                }
            }
            else
            {
                DeshabilitarBotonesYCampos();
                CargarDatosMateria();

            }
        }

        private void CambioTexto(object sender, TextChangedEventArgs e)
        {
            cambioDatos = true;
        }

        private void CambioComboBox(object sender, SelectionChangedEventArgs e)
        {
            cambioDatos = true;
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea eliminar esta materia?", "Eliminar Materia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    bool eliminado = false;
                    eliminado = await fachada.EliminarMateria(this.materia.ID);
                    if (eliminado)
                    {
                        to.RecibirObjeto(materia, TipoTransferencia.Borrar);
                        LevantarPopUp(TipoMensaje.Info, "La materia " + materia.Nombre + " de la sucursal " + materia.Sucursal.Nombre + " se ha eliminado correctamente");
                        this.Close();
                    }
                    else
                    {
                        LevantarPopUp(TipoMensaje.Error, "No fue posible eliminar esta materia");
                    }
                }
            }
            catch (Exception ex)
            {
                this.LevantarPopUp(TipoMensaje.Error, "No fue posible eliminar esta materia");
            }
        }

        private void LevantarPopUp(TipoMensaje tm, string mensaje)
        {
            PopUpVentana pv = new PopUpVentana(mensaje, tm, 2000, 40, (((int)fachada.Tamano.Width) + 160), (int)fachada.Tamano.Height);
            pv.Show();
        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMsg = String.Empty;
                decimal precio = 0;
                Decimal.TryParse(txtPrecio.Text, out precio);
                if (precio <= 0)
                {
                    errorMsg = "Ingrese el precio \n";
                }
                if (txtNombre.Text.Equals(String.Empty))
                {
                    errorMsg += "Ingrese el nombre \n";
                }
                if ((Sucursal)cbSucursal.SelectedItem == null)
                {
                    errorMsg += "Seleccione una sucursal \n";
                }
                if (!errorMsg.Equals(String.Empty))
                {
                    this.LevantarPopUp(TipoMensaje.Error, errorMsg);
                }
                else
                {
                    if (tt.Equals(TipoTransferencia.Edicion))
                    {
                        await fachada.ModificarMateria(this.materia.ID, ((Sucursal)cbSucursal.SelectedItem).ID, txtNombre.Text, precio);
                    }
                    else if (tt.Equals(TipoTransferencia.Nuevo))
                    {
                        await fachada.CrearMateria(((Sucursal)cbSucursal.SelectedItem).ID, txtNombre.Text, precio);
                        this.LevantarPopUp(TipoMensaje.Info, "Se creó la materia!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                this.LevantarPopUp(TipoMensaje.Error, ex.Message);
            }
        }
    }
}
