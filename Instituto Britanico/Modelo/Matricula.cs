using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaBritanico.Utilidad;
using Newtonsoft.Json;

namespace BibliotecaBritanico.Modelo
{
    public class Matricula
    {
        public int ID { get; set; }
        [JsonIgnore]
        public Sucursal Sucursal { get; set; } = new Sucursal();
        public int SucursalID { get; set; }
        public int Anio { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Precio { get; set; }


        //debe haber un registro por anio de esta clase

        public static bool ValidarMatriculaInsert(Matricula matricula)
        {
            try
            {
                string errorMsg = String.Empty;
                if (matricula.Anio < 2000)
                {
                    errorMsg = "Año invalido \n";
                }
                if (matricula.Precio < 1)
                {
                    errorMsg += "Precio invalido \n";
                }
                if (matricula.SucursalID < 1)
                {
                    errorMsg += "Debe asociar la matricula a una Sucursal \n";
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

        public static bool ValidarMatriculaModificar(Matricula matricula)
        {
            try
            {
                string errorMsg = String.Empty;
                if (matricula.ID < 1)
                {
                    errorMsg = "Debe asignar un ID a la matricula";
                }
                if (matricula.Anio < 2000)
                {
                    errorMsg += "Año invalido \n";
                }
                if (matricula.Precio < 1)
                {
                    errorMsg += "Precio invalido \n";
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
