using BibliotecaBritanico.Modelo;
using Instituto_Britanico.Controlador;
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
    /// Lógica de interacción para BorrarBoton.xaml
    /// </summary>
    public partial class BorrarBoton : Window
    {
        Fachada fachada;
        public BorrarBoton()
        {
            InitializeComponent();
            fachada = Fachada.getInstancia();
         }

        private async void BotonQueHaceCosas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Materia materia = new Materia
                {
                    ID = 0,
                    SucursalID = 1,
                    Nombre = "Materia prueba1234",
                    Precio = 6500
                };
                materia = await MateriaController.Crear(materia);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            txtResultado.Text = " aqui iria el contenido si son varias lineas, separalas por \n  linea 1\n linea2";
        }
    }
}
