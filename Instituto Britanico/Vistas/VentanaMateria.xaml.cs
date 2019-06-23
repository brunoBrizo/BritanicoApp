using BibliotecaBritanico.Modelo;
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

        public VentanaMateria()
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            CargarLibros();
            CargarSucursales();

        }

        private void CargarSucursales()
        {
            List<Sucursal> listaSucursales = fachada.GetSucursalesTotal();
            cbSucursal.ItemsSource = listaSucursales;
        }

        private void CargarLibros()
        {
            List<Libro> lista = fachada.GetLibrosTotal();
            lbLibros.ItemsSource = lista;
        }

        private void AgregarLibro(object sender, RoutedEventArgs e)
        {
            
            List<Libro> lista = new List<Libro>();
            for (int i = 0; i < lbLibros.Items.Count; i++)
            {
                var item = lbLibros.ItemContainerGenerator.ContainerFromItem(lbLibros.Items[i]) as ListBoxItem;
                if (item != null)
                {
                    var template = item.ContentTemplate as DataTemplate;
                    ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(item);
                    CheckBox myCheckBox = (CheckBox)template.FindName("chkLibro", myContentPresenter);
                    if ((bool)myCheckBox.IsChecked) { lista.Add((Libro)lbLibros.Items[i]); }
                }
            }
            string hola = "";
            foreach (Libro es in lista)
            {
                hola += "\r\n" + es.Nombre;
            }
            txtInfo.Text = hola;
            
          
        }


        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }

            return null;
        }
        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
