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
    public class Empresa
    {
        public int ID { get; set; }
        public string Rut { get; set; }
        public string RazonSoc { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Tel { get; set; }
        public string Logo { get; set; }
        public string LogoImagen { get; set; }


        public Empresa() { }

        public Empresa(string Rut, string RazonSoc, string Nombre, string Direccion, string Tel, string Email, string Logo, string LogoImagen)
        {
            this.Rut = Rut;
            this.RazonSoc = RazonSoc;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Tel = Tel;
            this.Email = Email;
            this.Logo = Logo;
            this.LogoImagen = LogoImagen;
        }

        public static bool ValidarEmpresaInsert(Empresa empresa)
        {
            string errorMsg = String.Empty;
            if (empresa.Rut.Equals(String.Empty) || empresa.RazonSoc.Equals(String.Empty) || empresa.Nombre.Equals(String.Empty))
            {
                errorMsg = "Rut, Razon Social y Nombre son obligatorios \n";
            }
            if (!empresa.Rut.Equals(String.Empty) && !Herramientas.ValidarRUT(empresa.Rut))
            {
                errorMsg += "RUT inválido \n";
            }
            if (!empresa.Email.Equals(String.Empty) && !Herramientas.ValidarMail(empresa.Email))
            {
                errorMsg += "Email inválido \n";
            }
            if (errorMsg != String.Empty)
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }

        public static bool ValidarEmpresaModificar(Empresa empresa)
        {
            string ErrorMsg = String.Empty;
            if (empresa.ID < 1)
            {
                ErrorMsg = "Debe asociar un ID a la empresa \n";
            }
            if (empresa.RazonSoc.Equals(String.Empty) || empresa.Nombre.Equals(String.Empty))
            {
                ErrorMsg += "Razon Social y Nombre son obligatorios \n";
            }
            if (!empresa.Email.Equals(String.Empty) && !Herramientas.ValidarMail(empresa.Email))
            {
                ErrorMsg += "Email inválido \n";
            }
            if (ErrorMsg != String.Empty)
            {
                throw new ValidacionException(ErrorMsg);
            }
            return true;
        }


    }
}
