using BibliotecaBritanico.Utilidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBritanico.Modelo
{
    public class Pago
    {
        public int ID { get; set; }
        [JsonIgnore]
        public Sucursal Sucursal { get; set; }
        public int SucursalID { get; set; }
        public DateTime FechaHora { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        [JsonIgnore]
        public Funcionario Funcionario { get; set; }
        public int FuncionarioID { get; set; }
        public string Observacion { get; set; }


        public Pago()
        {
            this.Sucursal = new Sucursal();
            this.Funcionario = new Funcionario();
        }

        public string FechaPago { get
            {
                return FechaHora.ToShortDateString();
            } }

    }
}
