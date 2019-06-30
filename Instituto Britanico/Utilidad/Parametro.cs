using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaBritanico.Utilidad
{
    public class Parametro
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }

        public Parametro() { }

        public Parametro(string Nombre, string Valor)
        {
            this.Nombre = Nombre;
            this.Valor = Valor;
        }

        public static bool ValidarParametroInsert(Parametro parametro)
        {
            string errorMsg = String.Empty;
            if (parametro.Nombre.Equals(String.Empty) || parametro.Valor.Equals(String.Empty))
            {
                errorMsg = "Debe ingresar Nombre y Valor del parametro";
            }
            if (!errorMsg.Equals(String.Empty))
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }

        public static bool ValidarParametroModificar(Parametro parametro)
        {
            string errorMsg = String.Empty;
            if (parametro.ID < 1)
                errorMsg = "Debe asignar un ID al parametro \n";
            if (parametro.Nombre.Equals(String.Empty) || parametro.Valor.Equals(String.Empty))
            {
                errorMsg += "Debe ingresar Nombre y Valor del parametro";
            }
            if (!errorMsg.Equals(String.Empty))
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }


    }
}
