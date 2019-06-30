using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaBritanico.Utilidad;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace BibliotecaBritanico.Modelo
{
    public class Funcionario
    {
        public int ID { get; set; }
        [JsonIgnore]
        public Sucursal Sucursal { get; set; } = new Sucursal();
        public int SucursalID { get; set; }
        public string CI { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string TelefonoAux { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNac { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public FuncionarioTipo TipoFuncionario { get; set; }


        public Funcionario() { }

        public Funcionario(Sucursal Sucursal, string CI, string Nombre, string Email, string Clave, string Telefono, string Direccion, string TelefonoAux, DateTime FechaNac, bool Activo)
        {
            this.Sucursal = Sucursal;
            this.CI = CI;
            this.Nombre = Nombre;
            this.Email = Email;
            this.Clave = Clave;
            this.Telefono = Telefono;
            this.Direccion = Direccion;
            this.TelefonoAux = TelefonoAux;
            this.FechaNac = FechaNac;
            this.Activo = Activo;
        }

        public static bool ValidarFuncionarioInsert(Funcionario funcionario)
        {
            string errorMsg = String.Empty;
            if (funcionario.CI.Equals(String.Empty) || funcionario.Nombre.Equals(String.Empty) || funcionario.Clave.Equals(String.Empty) || funcionario.Telefono.Equals(String.Empty))
            {
                errorMsg = "Nombre, cedula, clave y telefono son obligatorios \n";
            }
            if (funcionario.FechaNac >= DateTime.Today || funcionario.FechaNac <= DateTime.MinValue)
            {
                errorMsg += "Fecha de nacimiento invalida \n";
            }
            if (!funcionario.CI.Equals(String.Empty) && !Herramientas.ValidarCedula(funcionario.CI))
            {
                errorMsg += "Cedula invalida \n";
            }
            if (!funcionario.Email.Equals(String.Empty) && !Herramientas.ValidarMail(funcionario.Email))
            {
                errorMsg += "Email inválido \n";
            }
            if (!Herramientas.ValidarPassword(funcionario.Clave))
            {
                errorMsg += "La contraseña debe tener más de 5 caracteres  \n";
            }
            if (!errorMsg.Equals(String.Empty))
            {
                throw new ValidacionException(errorMsg, "Funcionario");
            }
            return true;
        }

        public static bool ValidarFuncionarioModificar(Funcionario funcionario)
        {
            string errorMsg = String.Empty;
            if (funcionario.ID < 1)
            {
                errorMsg = "Debe asignar un ID al funcionario \n";
            }
            if (funcionario.CI.Equals(String.Empty) || funcionario.Nombre.Equals(String.Empty) || funcionario.Clave.Equals(String.Empty) || funcionario.Telefono.Equals(String.Empty))
            {
                errorMsg += "Nombre, cedula, clave y telefono son obligatorios \n";
            }
            if (funcionario.FechaNac >= DateTime.Today || funcionario.FechaNac <= DateTime.MinValue)
            {
                errorMsg += "Fecha de nacimiento invalida \n";
            }
            if (!funcionario.Email.Equals(String.Empty) && !Herramientas.ValidarMail(funcionario.Email))
            {
                errorMsg += "Email inválido \n";
            }
            if (!Herramientas.ValidarPassword(funcionario.Clave))
            {
                errorMsg += "La contraseña debe tener más de 5 caracteres  \n";
            }
            if (!errorMsg.Equals(String.Empty))
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
