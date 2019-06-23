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

    }
}
