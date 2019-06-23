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
        public Materia Materia { get; set; } //la materia tiene una lista de libros
        public decimal Precio { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }


    }
}
