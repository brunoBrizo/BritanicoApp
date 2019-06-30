using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaBritanico.Utilidad;
using Newtonsoft.Json;

namespace BibliotecaBritanico.Modelo
{
    public class Estudiante
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string CI { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNac { get; set; }
        public bool Alergico { get; set; }
        public string Alergias { get; set; }
        public string ContactoAlternativoUno { get; set; }
        public string ContactoAlternativoUnoTel { get; set; }
        public string ContactoAlternativoDos { get; set; }
        public string ContactoAlternativoDosTel { get; set; }
        public Convenio Convenio { get; set; } = new Convenio();
        [JsonIgnore]
        public Grupo Grupo { get; set; } = new Grupo();
        public int GrupoID { get; set; }
        public int MateriaID { get; set; }


        public static bool ValidarEstudianteInsert(Estudiante estudiante)
        {
            try
            {
                string errorMsg = String.Empty;
                if (estudiante.Nombre.Equals(String.Empty) || estudiante.CI.Equals(String.Empty) || estudiante.Tel.Equals(String.Empty))
                {
                    errorMsg = "Debe ingresar Nombre, Cedula y Telefono del estudiante \n";
                }
                if (estudiante.TipoDocumento.Equals(TipoDocumento.CI) && !estudiante.CI.Equals(String.Empty) && !Herramientas.ValidarCedula(estudiante.CI))
                {
                    errorMsg += "Cedula invalida \n";
                }
                if (estudiante.FechaNac >= DateTime.Today || estudiante.FechaNac <= DateTime.MinValue)
                {
                    errorMsg += "Fecha de nacimiento invalida \n";
                }
                int edad = estudiante.CalcularEdad();
                if ((edad < 18) && (estudiante.ContactoAlternativoUno.Equals(String.Empty) || estudiante.ContactoAlternativoUnoTel.Equals(String.Empty)))
                {
                    errorMsg = "Debe ingresar datos del responsable del estudiante \n";
                }
                if (!estudiante.Email.Equals(String.Empty) && !Herramientas.ValidarMail(estudiante.Email))
                {
                    errorMsg += "Email invalido \n";
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

        public static bool ValidarEstudianteModificar(Estudiante estudiante)
        {
            try
            {
                string errorMsg = String.Empty;
                if (estudiante.ID < 1)
                {
                    errorMsg = "Debe asignar un ID al estudiante \n";
                }
                if (estudiante.Nombre.Equals(String.Empty) || estudiante.CI.Equals(String.Empty) || estudiante.Tel.Equals(String.Empty))
                {
                    errorMsg += "Debe ingresar Nombre, Cedula y Telefono del estudiante \n";
                }
                if (estudiante.FechaNac >= DateTime.Today || estudiante.FechaNac <= DateTime.MinValue)
                {
                    errorMsg += "Fecha de nacimiento invalida \n";
                }
                int edad = estudiante.CalcularEdad();
                if ((edad < 18) && (estudiante.ContactoAlternativoUno.Equals(String.Empty) || estudiante.ContactoAlternativoUnoTel.Equals(String.Empty)))
                {
                    errorMsg = "Debe ingresar datos del responsable del estudiante \n";
                }
                if (!estudiante.Email.Equals(String.Empty) && !Herramientas.ValidarMail(estudiante.Email))
                {
                    errorMsg += "Email invalido \n";
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

        private int CalcularEdad()
        {
            int edad = DateTime.Today.AddTicks(-FechaNac.Ticks).Year - 1;
            return edad;
        }


    }
}
