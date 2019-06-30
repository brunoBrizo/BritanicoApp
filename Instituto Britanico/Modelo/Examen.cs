using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaBritanico.Utilidad;
using Newtonsoft.Json;

namespace BibliotecaBritanico.Modelo
{
    public class Examen
    {

        public int ID { get; set; }
        [JsonIgnore]
        public Grupo Grupo { get; set; } = new Grupo();
        public int GrupoID { get; set; }
        public int MateriaID { get; set; }
        public DateTime FechaHora { get; set; }
        public int AnioAsociado { get; set; }
        public int NotaMinima { get; set; }
        public decimal Precio { get; set; }

        //debe haber un registro por grupo-año de esta clase

        public Examen() { }


        public static bool ValidarExamenInsert(Examen examen)
        {
            try
            {
                string errorMsg = String.Empty;
                if (examen.GrupoID < 1 || examen.MateriaID < 1)
                {
                    errorMsg = "Examen debe estar asociado a un grupo \n";
                }
                if (examen.AnioAsociado < 2000)
                {
                    errorMsg += "Año invalido \n";
                }
                if (examen.NotaMinima < 1)
                {
                    errorMsg += "Nota minima invalida \n";
                }
                if (examen.Precio < 1)
                {
                    errorMsg += "Debe ingresar precio \n";
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

        public static bool ValidarExamenModificar(Examen examen)
        {
            try
            {
                string errorMsg = String.Empty;
                if (examen.ID < 1)
                {
                    errorMsg = "Debe asignar un ID al examen \n";
                }
                if (examen.GrupoID < 1 || examen.MateriaID < 1)
                {
                    errorMsg += "Examen debe estar asociado a un grupo \n";
                }
                if (examen.AnioAsociado < 2000)
                {
                    errorMsg += "Año invalido \n";
                }
                if (examen.NotaMinima < 1)
                {
                    errorMsg += "Nota minima invalida \n";
                }
                if (examen.Precio < 1)
                {
                    errorMsg += "Debe ingresar precio \n";
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

