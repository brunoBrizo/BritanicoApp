using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
