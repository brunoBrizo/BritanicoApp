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
    /// Lógica de interacción para VentanaIngresoEstudiante.xaml
    /// </summary>
    public partial class VentanaEstudiante : Window
    {
        Estudiante estudiante;
        IEstudiante ie;
        Fachada fachada;
        bool cambioDatos;
        TipoTransferencia tt;



        public VentanaEstudiante(Window v, Estudiante est, TipoTransferencia tt, IEstudiante ie)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            CargarConvenios();
            CargarTiposDocumento();
            this.tt = tt;
            if (est != null)
            {
                estudiante = est;
                CargarDatosEstudiante();
            }
            this.ie = ie;
        }

        private void CargarTiposDocumento()
        {

            cbTipoDocumento.ItemsSource = Enum.GetValues(typeof(TipoDocumento));
            cbTipoDocumento.SelectedIndex = 0;
        }

        private void CargarConvenios()
        {
            try
            {
                List<Convenio> convenios = fachada.GetConveniosTotal();
                cbConvenio.ItemsSource = convenios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void HabilitarCampos()
        {
            txtNombre.IsEnabled = true;
            txtCI.IsEnabled = true;
            txtTelefono.IsEnabled = true;
            txtDireccion.IsEnabled = true;
            txtFechaNac.IsEnabled = true;
            txtCorreo.IsEnabled = true;
            txtAlergias.IsEnabled = true;
            txtContacto1.IsEnabled = true;
            txtContacto1Tel.IsEnabled = true;
            txtContacto2.IsEnabled = true;
            txtContacto2Tel.IsEnabled = true;
            chkAlergias.IsEnabled = true;
            cbConvenio.IsEnabled = true;
            chkConvenio.IsEnabled = true;
            btnEditar.Visibility = Visibility.Collapsed;
            btnGuardar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;
        }

        private void DeshabilitarCampos()
        {
            txtNombre.IsEnabled = false;
            txtCI.IsEnabled = false;
            txtTelefono.IsEnabled = false;
            txtDireccion.IsEnabled = false;
            txtFechaNac.IsEnabled = false;
            txtCorreo.IsEnabled = false;
            txtAlergias.IsEnabled = false;
            txtContacto1.IsEnabled = false;
            txtContacto1Tel.IsEnabled = false;
            txtContacto2.IsEnabled = false;
            txtContacto2Tel.IsEnabled = false;
            chkAlergias.IsEnabled = false;
            cbConvenio.IsEnabled = false;
            chkConvenio.IsEnabled = false;
            btnEditar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;
        }


        private void CargarDatosEstudiante()
        {
            if (estudiante != null)
            {

                if (estudiante.Alergico)
                {
                    chkAlergias.IsChecked = true;
                    txtAlergias.IsEnabled = true;
                }
                else
                {
                    chkAlergias.IsChecked = false;
                    txtAlergias.IsEnabled = false;
                }

                if (tt == TipoTransferencia.Mostrar)
                {

                    DeshabilitarCampos();
                    btnEditar.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Hidden;
                    btnCancelar.Visibility = Visibility.Hidden;
                }
                else
                {
                    HabilitarCampos();

                    btnEditar.Visibility = Visibility.Collapsed;
                    btnGuardar.Visibility = Visibility.Visible;
                    btnCancelar.Visibility = Visibility.Visible;
                }
                txtNombre.Text = estudiante.Nombre;
                txtCI.Text = estudiante.CI;
                txtTelefono.Text = estudiante.Tel;
                txtDireccion.Text = estudiante.Direccion;
                txtFechaNac.Text = estudiante.FechaNac.ToShortDateString();
                txtCorreo.Text = estudiante.Email;
                txtAlergias.Text = estudiante.Alergias;
                txtContacto1.Text = estudiante.ContactoAlternativoUno;
                txtContacto1Tel.Text = estudiante.ContactoAlternativoUnoTel;
                txtContacto2.Text = estudiante.ContactoAlternativoDos;
                txtContacto2Tel.Text = estudiante.ContactoAlternativoDosTel;
                if (estudiante.Convenio != null)
                {
                    chkConvenio.IsChecked = true;
                    int a = 0;
                    bool elEncontrado = false;
                    while (a < cbConvenio.Items.Count && !elEncontrado)
                    {
                        if (((Convenio)cbConvenio.Items[a]).Equals(estudiante.Convenio))
                        {
                            cbConvenio.SelectedIndex = a;
                            elEncontrado = true;
                        }
                        a++;
                    }
                    cbConvenio.IsEnabled = true;
                }
                else
                {
                    chkConvenio.IsChecked = false;
                    cbConvenio.IsEnabled = false;
                    cbConvenio.SelectedIndex = -1;
                }
                int i = 0;
                bool encontrado = false;
                while(i<cbTipoDocumento.Items.Count && !encontrado)
                {
                    if (((TipoDocumento)cbTipoDocumento.Items[i]) == estudiante.TipoDocumento)
                    {
                        cbTipoDocumento.SelectedIndex = i;
                        encontrado = true;
                    }
                    i++;
                }
            }
            cambioDatos = false;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string CI = txtCI.Text;
            string telefono = txtTelefono.Text;
            bool esAlergico = (bool)chkAlergias.IsChecked;
            string alergias = txtAlergias.Text;
            string contactoUno = txtContacto1.Text;
            string contactoDos = txtContacto2.Text;
            string contactoUnoTel = txtContacto1Tel.Text;
            string contactoDosTel = txtContacto2Tel.Text;
            TipoDocumento td = (TipoDocumento)cbTipoDocumento.SelectedItem;
            string direccion = txtDireccion.Text;
            string correo = txtCorreo.Text;
            DateTime fechaNac = DateTime.MinValue;
            DateTime.TryParse(txtFechaNac.Text, out fechaNac);
            Convenio convenio = (Convenio)cbConvenio.SelectedItem;
            if (!(bool)chkConvenio.IsChecked) convenio = null;
            if (!esAlergico) alergias = "";
            bool sino = !(bool)chkCorrecto.IsChecked;
            if (estudiante == null)
            {
                try
                {
                    bool guardado = false;//fachada.AltaEstudiante(td, nombre, CI, telefono, esAlergico, alergias, contactoUno, contactoUnoTel, contactoDos, contactoDosTel, direccion, correo, fechaNac, convenio, sino);
                    if (guardado) LevantarPopUp(TipoMensaje.Info, "Los datos del estudiante se guardararon correctamente");
                    else LevantarPopUp(TipoMensaje.Error, "Ocurrio un error al guardar los datos, no se guardaron");

                }
                catch (Exception ex)
                {
                    LevantarPopUp(TipoMensaje.Error, ex.Message);
                }

            }
            else
            {
                try
                {
                    bool modificado = false;//fachada.ModificarEstudiante(estudiante.ID, td,  nombre, CI, telefono, esAlergico, alergias, contactoUno, contactoUnoTel, contactoDos, contactoDosTel, direccion, correo, fechaNac, convenio, sino);
                    if (modificado) LevantarPopUp(TipoMensaje.Info, "Los datos del estudiante se modificaron correctamente");
                    else LevantarPopUp(TipoMensaje.Error, "Ocurrio un error al guardar los datos, no se modificaron");

                }
                catch (Exception ex)
                {
                    LevantarPopUp(TipoMensaje.Error, ex.Message);
                }


            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCampos();
            if ((bool)chkConvenio.IsChecked) cbConvenio.IsEnabled = true;
            else cbConvenio.IsEnabled = false;
            if ((bool)chkAlergias.IsChecked) txtAlergias.IsEnabled = true;
            else txtAlergias.IsEnabled = false;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (cambioDatos)
            {
                if (MessageBox.Show("Desea cancelar edicion?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    DeshabilitarCampos();
                    CargarDatosEstudiante();
                    cambioDatos = false;
                }
            }
            else
            {
                DeshabilitarCampos();
            }
        }

        private void TeclaEnVentana(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (btnGuardar.Visibility == Visibility.Visible)
                {
                    if (MessageBox.Show("Desea cerrar ventana?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }

        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            if (btnGuardar.Visibility == Visibility.Visible)
            {
                if (MessageBox.Show("Desea cerrar ventana?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void LevantarPopUp(TipoMensaje tm, string mensaje)
        {
            PopUpVentana pv = new PopUpVentana(mensaje, tm, 2000, 40, (((int)fachada.Tamano.Width) + 160), (int)fachada.Tamano.Height);
            pv.Show();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (estudiante != null)
            {
                try
                {
                    bool eliminado = false;//fachada.EliminarEstudiante(estudiante.ID);
                    if (eliminado)
                    {
                        ie.RecibirEstudiante(estudiante, TipoTransferencia.Borrar);
                        LevantarPopUp(TipoMensaje.Info, "Los datos del estudiante han sido eliminados");
                        this.Close();
                    }
                    else
                    {
                        LevantarPopUp(TipoMensaje.Alerta, "Error al eliminar los datos del estudiante");
                    }
                }
                catch (Exception ex)
                {
                    LevantarPopUp(TipoMensaje.Error, ex.Message);
                }
            }
        }

        private void ChkAlergias_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)chkAlergias.IsChecked) txtAlergias.IsEnabled = true;
            else txtAlergias.IsEnabled = false;
        }

        private void ChkConvenio_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)chkConvenio.IsChecked) cbConvenio.IsEnabled = true;
            else cbConvenio.IsEnabled = false;
        }


        private void CambioDatos(object sender, TextChangedEventArgs e)
        {
            cambioDatos = true;
        }

        private void TxtFechaNac_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            cambioDatos = true;
        }

        private void CbConvenio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cambioDatos = true;
        }
    }
}
