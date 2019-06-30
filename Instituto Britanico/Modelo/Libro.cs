using BibliotecaBritanico.Utilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBritanico.Modelo
{
    public class Libro
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public Materia Materia { get; set; } = new Materia();
        public decimal Precio { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }


        public static bool ValidarInsertLibro(Libro libro)
        {
            string errorMsg = String.Empty;
            if (libro.Nombre.Equals(String.Empty))
            {
                errorMsg += "Debe ingresar el nombre del libro \n";
            }
            if (libro.Precio <= 0)
            {
                errorMsg += "Debe ingresar el precio del libro \n";
            }
            if (libro.Materia.ID < 1)
            {
                errorMsg += "Debe asociar una materia al libro \n";
            }
            if (!errorMsg.Equals(String.Empty))
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }

        public static bool ValidarModificarLibro(Libro libro)
        {
            string errorMsg = String.Empty;
            if (libro.ID < 1)
            {
                errorMsg = "Debe asignar un ID al libro \n";
            }
            if (libro.Nombre == String.Empty)
            {
                errorMsg += "Debe ingresar el nombre del libro \n";
            }
            if (libro.Precio <= 0)
            {
                errorMsg += "Debe ingresar el precio del libro \n";
            }
            if (libro.Materia.ID < 1)
            {
                errorMsg += "Debe asociar una materia al libro \n";
            }
            if (!errorMsg.Equals(String.Empty))
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }


    }
}
