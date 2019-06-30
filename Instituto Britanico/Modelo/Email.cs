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

        public static bool ValidarEmailInsert(Email email)
        {
            string errorMsg = String.Empty;
            if (email.DestinatarioEmail.Equals(String.Empty))
            {
                errorMsg = "Destinatario no puede ser vacio \n";
            }
            if (email.Asunto.Equals(String.Empty))
            {
                errorMsg += "Asunto no puede ser vacio \n";
            }
            if (email.CuerpoHTML.Equals(String.Empty))
            {
                errorMsg += "Contenido del email no puede ser vacio \n";
            }
            if (errorMsg != String.Empty)
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }

        public static bool ValidarEmailModificar(Email email)
        {
            string errorMsg = String.Empty;
            if (email.DestinatarioEmail.Equals(String.Empty))
            {
                errorMsg = "Destinatario no puede ser vacio \n";
            }
            if (email.ID < 1)
            {
                errorMsg += "Debe asignar ID al email \n";
            }
            if (email.Asunto.Equals(String.Empty))
            {
                errorMsg += "Asunto no puede ser vacio \n";
            }
            if (email.CuerpoHTML.Equals(String.Empty))
            {
                errorMsg += "Contenido del email no puede ser vacio \n";
            }
            if (errorMsg != String.Empty)
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }



    }
}
