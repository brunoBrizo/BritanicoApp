using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BibliotecaBritanico.Utilidad;

namespace BibliotecaBritanico.Modelo
{
    public class Sucursal
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Tel { get; set; }
        public string Ciudad { get; set; }
        public string Encargado { get; set; }


        public Sucursal()
        {
        }

        public Sucursal(string Nombre, string Direccion, string Tel, string Email, string Ciudad, string Encargado)
        {
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Tel = Tel;
            this.Email = Email;
            this.Ciudad = Ciudad;
            this.Encargado = Encargado;
        }

        public static bool ValidarSucursalInsert(Sucursal sucursal)
        {
            string errorMsg = "";
            if (sucursal.Nombre.Equals(String.Empty))
            {
                errorMsg = "Debe ingresar nombre de la sucursal \n";
            }
            if (!sucursal.Email.Equals(String.Empty) && !Herramientas.ValidarMail(sucursal.Email))
            {
                errorMsg += "Email inválido";
            }
            if (errorMsg != "")
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }

        public static bool ValidarSucursalModificar(Sucursal sucursal)
        {
            string errorMsg = "";
            if (sucursal.ID < 1)
            {
                errorMsg = "Debe asignar un ID a la sucursal \n";
            }
            if (sucursal.Nombre.Equals(String.Empty))
            {
                errorMsg += "Debe ingresar nombre de la sucursal \n";
            }
            if (!sucursal.Email.Equals(String.Empty) && !Herramientas.ValidarMail(sucursal.Email))
            {
                errorMsg += "Email inválido";
            }
            if (errorMsg != "")
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
