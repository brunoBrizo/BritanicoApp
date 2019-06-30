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

        public string FechaPago
        {
            get
            {
                return FechaHora.ToShortDateString();
            }
        }

        public static bool ValidarPagoInsert(Pago pago)
        {
            string errorMsg = String.Empty;
            if (pago.Concepto.Equals(String.Empty))
            {
                errorMsg = "Debe ingresar el Concepto del pago \n";
            }
            if (pago.Monto < 1)
            {
                errorMsg += "Debe ingresar el Monto del pago \n";
            }
            if (pago.FuncionarioID < 1)
            {
                errorMsg += "Debe asociar el pago a un funcionario";
            }
            if (!errorMsg.Equals(String.Empty))
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }

        public static bool ValidarPagoModificar(Pago pago)
        {
            string errorMsg = String.Empty;
            if (pago.ID < 1)
            {
                errorMsg = "Debe asignar un ID al pago \n";
            }
            if (pago.Concepto.Equals(String.Empty))
            {
                errorMsg += "Debe ingresar el Concepto del pago \n";
            }
            if (pago.Monto < 1)
            {
                errorMsg += "Debe ingresar el Monto del pago \n";
            }
            if (!errorMsg.Equals(String.Empty))
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }


    }
}
