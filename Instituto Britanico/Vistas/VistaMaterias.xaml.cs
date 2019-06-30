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
    /// Lógica de interacción para VistaMaterias.xaml
    /// </summary>
    public partial class VistaMaterias : UserControl, TransferenciaObjeto
    {
        Fachada fachada;
        Window Ventana;
        int Ancho, Alto;
        IBrillo brillo;
        List<Materia> listaMaterias;

        public VistaMaterias(Window v)
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            this.Ventana = v;
            brillo = (IBrillo)v;
            Loaded += VistaMaterias_Loaded;
        }

        private void VistaMaterias_Loaded(object sender, RoutedEventArgs e)
        {

            Ancho = (int)fachada.Tamano.Width;
            Alto = (int)fachada.Tamano.Height ;
            borde.Height = Alto-20 ;
            listaMaterias = fachada.GetMaterias();
            dgMaterias.ItemsSource = null;
            dgMaterias.ItemsSource = listaMaterias;
        }

        private void teclaApretada(object sender, KeyEventArgs e)
        {

        }

        private void dobleClick(object sender, MouseButtonEventArgs e)
        {
            Materia materia = (Materia)dgMaterias.SelectedItems[0];
            VentanaMateria vm = new VentanaMateria(Ventana, materia, TipoTransferencia.Mostrar, this);
            vm.Owner = Ventana;
            brillo.Oscurecer();
            vm.Closed += Vm_Closed;
           

            vm.ShowDialog();
        }

        private void Vm_Closed(object sender, EventArgs e)
        {
            brillo.Aclarar();
        }

        private void ClickEnEditar(object sender, RoutedEventArgs e)
        {
            Materia materia = (Materia)dgMaterias.SelectedItems[0];
            VentanaMateria vm = new VentanaMateria(Ventana, null, TipoTransferencia.Edicion, this);
            vm.Owner = Ventana;
            brillo.Oscurecer();
            vm.Closed += Vm_Closed;


            vm.ShowDialog();
        }

        private void BtnIngresarMateria_Click(object sender, RoutedEventArgs e)
        {
            VentanaMateria vm = new VentanaMateria(Ventana, null, TipoTransferencia.Nuevo, this);
            vm.Owner = Ventana;
            brillo.Oscurecer();
            vm.Closed += Vm_Closed;


            vm.ShowDialog();

        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClickEnBorrar(object sender, RoutedEventArgs e)
        {

        }

        public void RecibirObjeto(object o, TipoTransferencia tt)
        {
           if(o is Materia && tt==TipoTransferencia.Borrar)
            {
                Materia m = (Materia)o;
                if (listaMaterias.Contains(m))
                {
                    listaMaterias.Remove(m);
                    dgMaterias.ItemsSource = null;
                    dgMaterias.ItemsSource = listaMaterias;
                }
            }
        }
    }
}
