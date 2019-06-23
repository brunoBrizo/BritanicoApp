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
    /// Lógica de interacción para VentanaBorrar.xaml
    /// </summary>
    public partial class VentanaBorrar : Window
    {
        Fachada fachada;
        public VentanaBorrar()
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
            List<Estudiante> lista = fachada.GetEstudiantesTotal();
            lbPruebas.ItemsSource = lista;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Estudiante> lista = new List<Estudiante>();
            for (int i = 0; i < lbPruebas.Items.Count; i++)
            {
                
                var item = lbPruebas.ItemContainerGenerator.ContainerFromItem(lbPruebas.Items[i]) as ListBoxItem;
                if (item != null)
                {
                    var template = item.ContentTemplate as DataTemplate;

                    ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(item);

                    CheckBox myCheckBox = (CheckBox)template.FindName("checkBox", myContentPresenter);

                    if ((bool)myCheckBox.IsChecked) { lista.Add((Estudiante)lbPruebas.Items[i]); }
                }
                //myCheckBox.IsChecked = true;
            }
            string hola = "";
            foreach(Estudiante es in lista)
            {
                hola += "\r\n" + es.Nombre;
            }
            txtInfo.Text = hola;



        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
       where T : DependencyObject
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
    }
}
