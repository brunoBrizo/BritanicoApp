using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaBritanico.Utilidad;
using Newtonsoft.Json;

namespace BibliotecaBritanico.Modelo
{
    public class Mensualidad
    {
        public int ID { get; set; }
        [JsonIgnore]
        public Sucursal Sucursal { get; set; } = new Sucursal(); //en que sucursal la pago
        public int SucursalID { get; set; }
        public Estudiante Estudiante { get; set; } = new Estudiante();
        public DateTime FechaHora { get; set; } //hora de pago
        [JsonIgnore]
        public Grupo Grupo { get; set; } = new Grupo();  //grupo al que pertenece el estudiante
        public int GrupoID { get; set; }
        public int MateriaID { get; set; }
        public int MesAsociado { get; set; }  //que mes esta pagando
        public int AnioAsociado { get; set; }  //que año corresponde
        [JsonIgnore]
        public Funcionario Funcionario { get; set; } = new Funcionario();
        public int FuncionarioID { get; set; }
        public decimal Precio { get; set; }
        private static decimal Recargo { get; set; } // se hace privado para hacer un metodo static que si el recargo esta en 0, va a la base y lo carga y devuelve

        //definir cobro de recargos, fechas, cantidad de meses, vencimientos, 


        public static bool ValidarMensualidadInsert(Mensualidad mensualidad)
        {
            try
            {
                string errorMsg = String.Empty;
                if (mensualidad.Estudiante.ID < 1)
                {
                    errorMsg = "Debe ingresar un estudiante \n";
                }
                if (mensualidad.GrupoID < 1 || mensualidad.MateriaID < 1)
                {
                    errorMsg += "Debe asociar la mensualidad a un grupo \n";
                }
                if (mensualidad.AnioAsociado < 2000 || mensualidad.AnioAsociado >= 2050)
                {
                    errorMsg += "Año invalido \n";
                }
                if (mensualidad.MesAsociado < 1 || mensualidad.MesAsociado > 12)
                {
                    errorMsg += "Mes invalido \n";
                }
                if (mensualidad.Precio < 1)
                {
                    errorMsg += "Debe ingresar un precio \n";
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

        public static bool ValidarMensualidadModificar(Mensualidad mensualidad)
        {
            try
            {
                string errorMsg = String.Empty;
                if (mensualidad.ID < 1)
                {
                    errorMsg = "Debe asignar ID a la mensualidad \n";
                }
                if (mensualidad.GrupoID < 1 || mensualidad.MateriaID < 1)
                {
                    errorMsg += "Debe asociar la mensualidad a un grupo \n";
                }
                if (mensualidad.AnioAsociado < 2000)
                {
                    errorMsg += "Año invalido \n";
                }
                if (mensualidad.MesAsociado < 1 || mensualidad.MesAsociado > 12)
                {
                    errorMsg += "Mes invalido \n";
                }
                if (mensualidad.Precio < 1)
                {
                    errorMsg += "Debe ingresar un precio \n";
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


    }
}
