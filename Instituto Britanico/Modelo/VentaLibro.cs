using BibliotecaBritanico.Utilidad;
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


        public static bool ValidarVentaLibroInsert(VentaLibro venta)
        {
            try
            {
                string errorMsg = String.Empty;
                if (venta.Libro.ID < 1 || venta.Libro.Materia.ID < 1)
                {
                    errorMsg = "La venta debe estar asociada a un libro \n";
                }
                if (venta.Estudiante.ID < 1)
                {
                    errorMsg += "La venta debe estar asociada a un estudiante \n";
                }
                if (venta.Precio < 1)
                {
                    errorMsg += "La venta debe tener un valor \n";
                }
                if (!errorMsg.Equals(String.Empty))
                {
                    throw new ValidacionException(errorMsg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidarVentaLibroModificar(VentaLibro venta)
        {
            try
            {
                string errorMsg = String.Empty;
                if (venta.ID < 1)
                {
                    errorMsg = "Debe asociar ID a la venta \n";
                }
                if (venta.Libro.ID < 1 || venta.Libro.Materia.ID < 1)
                {
                    errorMsg += "La venta debe estar asociada a un libro \n";
                }
                if (venta.Estudiante.ID < 1)
                {
                    errorMsg += "La venta debe estar asociada a un estudiante \n";
                }
                if (venta.Precio < 1)
                {
                    errorMsg += "La venta debe tener un valor \n";
                }
                if (!errorMsg.Equals(String.Empty))
                {
                    throw new ValidacionException(errorMsg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
