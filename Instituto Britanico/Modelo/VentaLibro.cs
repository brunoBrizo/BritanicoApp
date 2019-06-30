using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBritanico.Modelo
{
    public class VentaLibro
    {
        public int ID { get; set; }
        public Libro Libro { get; set; } = new Libro();
        public Estudiante Estudiante { get; set; } = new Estudiante(); //Estudiante tiene la lista
        public DateTime FechaHora { get; set; }
        public decimal Precio { get; set; }
        public VentaLibroEstado Estado { get; set; }



    }
}
