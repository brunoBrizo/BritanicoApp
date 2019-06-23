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
    public class Email
    {
        public int ID { get; set; }
        public string DestinatarioEmail { get; set; }
        public string DestinatarioNombre { get; set; }
        public string Asunto { get; set; }
        public string CuerpoHTML { get; set; }
        public DateTime FechaHora { get; set; }
        public bool Enviado { get; set; }


        public Email() { }


    }
}
