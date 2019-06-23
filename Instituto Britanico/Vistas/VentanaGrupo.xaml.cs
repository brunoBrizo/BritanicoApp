using BibliotecaBritanico.Modelo;
using Instituto_Britanico.Interfaces;
using Instituto_Britanico.Modelo;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Instituto_Britanico.Vistas
{
   
    public partial class VentanaGrupo : Window
    {

        //el precio del grupo se toma de la materia y permite modificar

        Fachada fachada;
        Window ventana;
        TransferenciaObjeto to;
        Grupo grupo;
        bool cambioDatos;
        TipoTransferencia tt;


        public VentanaGrupo(Window v, Grupo g, TipoTransferencia tt, TransferenciaObjeto to)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            ventana = v;
            this.to = to;
            this.tt = tt;
            CargarComboBox();
            if (g != null)
            {
                grupo = g;
                CargarDatosGrupo();
            }
            
        }

        private void CargarComboBox()
        {
            try
            {
                cbMaterias.ItemsSource = fachada.GetMateriasTotal();
                cbProfesor.ItemsSource = fachada.GetProfesoresTotal();
                cbSucursal.ItemsSource = fachada.GetSucursalesTotal();
            }catch(Exception ex)
            {
                LevantarPopUp(TipoMensaje.Error, ex.Message);
            }
           
            HabilitarCamposYBotones();
        }

        private void HabilitarCamposYBotones()
        {
            stackCheck.Visibility = Visibility.Visible;
            txtInfoDias.Visibility = Visibility.Collapsed;
            txtPrecio.IsEnabled = true;
            txtHoraFin.IsEnabled = true;
            txtHoraInicio.IsEnabled = true;
            cbMaterias.IsEnabled = true;
            cbProfesor.IsEnabled = true;
            btnCancelar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Visible;
            btnEditar.Visibility = Visibility.Hidden;
            btnBorrar.Visibility = Visibility.Hidden;
            cbSucursal.IsEnabled = true;
        }

        private void DesHabilitarCamposYBotones()
        {
            cbSucursal.IsEnabled = false;
            stackCheck.Visibility = Visibility.Collapsed;
            txtInfoDias.Visibility = Visibility.Visible;
            txtPrecio.IsEnabled = false;
            txtHoraFin.IsEnabled = false;
            txtHoraInicio.IsEnabled = false;
            cbMaterias.IsEnabled = false;
            cbProfesor.IsEnabled = false;
            btnCancelar.Visibility = Visibility.Hidden;
            btnGuardar.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Visible;
            btnBorrar.Visibility = Visibility.Visible;
        }

        private void CargarDatosGrupo()
        {
            if (grupo != null)
            {
                if (tt == TipoTransferencia.Mostrar) DesHabilitarCamposYBotones();
                if (tt == TipoTransferencia.Edicion) HabilitarCamposYBotones();
                foreach (GrupoDia s in grupo.LstDias)
                {
                    if (s.Dia.ToLower().Equals("lunes")) chkLunes.IsChecked = true;
                    if (s.Dia.ToLower().Equals("martes")) chkMartes.IsChecked = true;
                    if (s.Dia.ToLower().Equals("miercoles")) chkMiercoles.IsChecked = true;
                    if (s.Dia.ToLower().Equals("jueves")) chkJueves.IsChecked = true;
                    if (s.Dia.ToLower().Equals("viernes")) chkViernes.IsChecked = true;
                    if (s.Dia.ToLower().Equals("sabado")) chkSabado.IsChecked = true;
                    if (s.Dia.ToLower().Equals("domingo")) chkDomingo.IsChecked = true;
                }
                txtHoraFin.Text = grupo.HoraFin;
                txtHoraInicio.Text = grupo.HoraInicio;
                txtPrecio.Text = grupo.Precio + "";
                string dias = "";
                foreach (GrupoDia d in grupo.LstDias)
                {
                    dias += d.Dia;
                }
                txtInfoDias.Text = dias;

                int i = 0;
                bool encontrado = false;
                while (i < cbMaterias.Items.Count && !encontrado)
                {
                    if (grupo.Materia.ID == ((Materia)cbMaterias.Items[i]).ID)
                    {
                        cbMaterias.SelectedIndex = i;
                        encontrado = true;
                    }
                    i++;
                }
                i = 0;
                encontrado = false;
                if (grupo.Funcionario != null)
                {
                    while (i < cbProfesor.Items.Count && !encontrado)
                    {

                        if (grupo.Funcionario.ID == ((Grupo)cbProfesor.Items[i]).ID)
                        {
                            cbProfesor.SelectedIndex = i;
                            encontrado = true;
                        }
                        i++;
                    }
                }
                i = 0;
                encontrado = false;
                while (i < cbSucursal.Items.Count && !encontrado)
                {
                    if (((Sucursal)cbSucursal.Items[i]).ID == grupo.Sucursal.ID)
                    {
                        encontrado = true;
                        cbSucursal.SelectedIndex = i;
                    }
                    i++;
                }
                cambioDatos = false;
            }
        }


        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            if (cambioDatos)
            {
                if (MessageBox.Show("Desea cancelar edicion?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string horaInicio = txtHoraInicio.Text;
            string horaFin = txtHoraFin.Text;
            decimal precio = 0;
            decimal.TryParse(txtPrecio.Text, out precio);
            Sucursal sucursal = (Sucursal)cbSucursal.SelectedItem;
            Funcionario funcionario = (Funcionario)cbProfesor.SelectedItem;
            Materia materia = (Materia)cbMaterias.SelectedItem;
            List<string> listaDias = new List<string>();
            bool activo = (bool)chkActivo.IsChecked;
            if ((bool)chkLunes.IsChecked) listaDias.Add("Lunes");
            if ((bool)chkMartes.IsChecked) listaDias.Add("Martes");
            if ((bool)chkMiercoles.IsChecked) listaDias.Add("Miercoles");
            if ((bool)chkJueves.IsChecked) listaDias.Add("Jueves");
            if ((bool)chkViernes.IsChecked) listaDias.Add("Viernes");
            if ((bool)chkSabado.IsChecked) listaDias.Add("Sabado");
            if ((bool)chkDomingo.IsChecked) listaDias.Add("Domingo");
            if (tt == TipoTransferencia.Nuevo)
            {
                Grupo g = fachada.AltaGrupo(listaDias, sucursal, funcionario, horaInicio, horaFin, materia, activo, precio);
                try
                {
                    if (g == null)
                    {
                        LevantarPopUp(TipoMensaje.Alerta, "No fue posible ingresar grupo");
                    }
                    else
                    {
                        LevantarPopUp(TipoMensaje.Info, "Grupo ingresado correctamente");
                    }
                }catch(Exception ex)
                {
                    LevantarPopUp(TipoMensaje.Error, ex.Message);
                }

            }else if(tt==TipoTransferencia.Edicion || tt == TipoTransferencia.Mostrar)
            {
                try
                {
                    bool modificado = fachada.ModificarGrupo(grupo.ID, listaDias, sucursal, funcionario, horaInicio, horaFin, materia, activo, precio);
                    if (modificado)
                    {
                        LevantarPopUp(TipoMensaje.Info, "Los datos del grupo han sido modificados con exito");
                        this.Close();
                    }
                    else LevantarPopUp(TipoMensaje.Alerta, "No fue posible modificar los datos del grupo");

                }
                catch(Exception ex)
                {
                    LevantarPopUp(TipoMensaje.Error, ex.Message);
                }
            }

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCamposYBotones();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (cambioDatos)
            {
                if (MessageBox.Show("Desea cancelar edicion?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    DesHabilitarCamposYBotones();
                    CargarDatosGrupo();
                }
            }
            else
            {
                DesHabilitarCamposYBotones();
            }
        }

        private void BtnBorrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool eliminado = fachada.EliminarGrupo(grupo.ID);
                if (eliminado)
                {
                    LevantarPopUp(TipoMensaje.Info, "El grupo ha sido eliminado de la base de datos");
                    this.Close();
                }
                else
                {
                    LevantarPopUp(TipoMensaje.Alerta, "No se pudo eliminar el grupo");
                }
            }
            catch (Exception ex)
            {
                LevantarPopUp(TipoMensaje.Error, ex.Message);
            }
        }

        private void TeclaEnVentana(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (cambioDatos)
                {
                    if (MessageBox.Show("Desea cancelar edicion?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
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

        private void LevantarPopUp(TipoMensaje tm, string mensaje)
        {
            PopUpVentana pv = new PopUpVentana(mensaje, tm, 2000, 40, (((int)fachada.Tamano.Width) + 160), (int)fachada.Tamano.Height);
            pv.Show();
        }

        private void CambioDatos(object sender, SelectionChangedEventArgs e)
        {
            cambioDatos = true;
        }

        private void CambioDatosTexto(object sender, TextChangedEventArgs e)
        {
            cambioDatos = true;
        }

        private void cambioDatosCheck(object sender, RoutedEventArgs e)
        {
            cambioDatos = true;
        }
    }
  
}
