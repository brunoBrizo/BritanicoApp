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
    /// Lógica de interacción para VentanaMatricula.xaml
    /// </summary>
    public partial class VentanaMatricula : Window, IEstudiante
    {
        Estudiante estudiante;


        public VentanaMatricula()
        {
            InitializeComponent();
        }

        public void RecibirEstudiante(Estudiante e, TipoTransferencia tt)
        {
            if (e != null)
            {
                estudiante = e;
                txtCedula.Text = estudiante.Nombre;
            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            VentanaEstudiante ve = new VentanaEstudiante(this.Owner, null, Modelo.TipoTransferencia.Nuevo, this)
            {
                Owner = this.Owner
            };

            ve.ShowDialog();
        }
        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
