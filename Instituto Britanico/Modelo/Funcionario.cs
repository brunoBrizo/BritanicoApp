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

        public override string ToString()
        {
            return Nombre;
        }

    }
}
