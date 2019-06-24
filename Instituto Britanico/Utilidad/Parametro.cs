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


    }
}
