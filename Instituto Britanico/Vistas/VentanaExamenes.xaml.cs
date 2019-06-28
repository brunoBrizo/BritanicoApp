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
    /// Lógica de interacción para VentanaExamenes.xaml
    /// </summary>
    public partial class VentanaExamenes : Window
    {

        Fachada fachada;
        Window ventana;
        Examen examen;
        TipoTransferencia tt;
        TransferenciaObjeto to;

        public VentanaExamenes(Window v, Examen ex, TipoTransferencia tt, TransferenciaObjeto to)
        {
            InitializeComponent();
            ventana = v;
            examen = ex;
            this.tt = tt;

            fachada = Fachada.getInstancia();
            CargarComboBox();
            if (this.examen != null) CargarDatosExamen();
        }

        private void CargarDatosExamen()
        {
            txtAnio.Text = examen.AnioAsociado + "";
            txtPrecio.Text = examen.Precio + "";
            dpFecha.Text = examen.FechaHora.ToShortDateString();
            int i = 0;
            bool encontrado = false;
            while(i<cbGrupos.Items.Count && !encontrado)
            {
                if (((Grupo)cbGrupos.Items[i]).ID == examen.Grupo.ID)
                {
                    encontrado = true;
                    cbGrupos.SelectedIndex = i;
                }
                i++;
            }

            txtNotaMinima.Text = examen.NotaMinima + "";
            txtHora.Text = examen.FechaHora.Hour + ":" + examen.FechaHora.Minute;
            if (tt == TipoTransferencia.Mostrar) DeshabilitarBotonesYCampos();
            else if (tt == TipoTransferencia.Edicion) HabilitarBotonesYCampos();
        }

        private void DeshabilitarBotonesYCampos()
        {
            txtAnio.IsEnabled = false;
            txtHora.IsEnabled = false;
            txtNotaMinima.IsEnabled = false;
            txtPrecio.IsEnabled = false;
            dpFecha.IsEnabled = false;
            cbGrupos.IsEnabled = false;
            btnCancelar.Visibility = Visibility.Collapsed;
            btnGuardar.Visibility = Visibility.Collapsed;
            btnEditar.Visibility = Visibility.Visible;

        }

        private void HabilitarBotonesYCampos()
        {
            txtAnio.IsEnabled = true;
            txtHora.IsEnabled = true;
            txtNotaMinima.IsEnabled = true;
            txtPrecio.IsEnabled = true;
            dpFecha.IsEnabled = true;
            cbGrupos.IsEnabled = true;
            btnCancelar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Visible;
            btnEditar.Visibility = Visibility.Collapsed;
        }

        private void CargarComboBox()
        {
            List<Grupo> listaGrupos = fachada.GetGruposTotalb();
            cbGrupos.ItemsSource = listaGrupos;

        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
          
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarBotonesYCampos();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //aqui va la logica de si es un ingreso nuevo, una edicion, o sea si es un alta o modificacion
        }
    }
}
