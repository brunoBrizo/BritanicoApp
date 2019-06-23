using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BibliotecaBritanico.Modelo
{
    public class Matricula
    {
        public int ID { get; set; }
        [JsonIgnore]
        public Sucursal Sucursal { get; set; } = new Sucursal();
        public int SucursalID { get; set; }
        public int Anio { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Precio { get; set; }


        //debe haber un registro por anio de esta clase


    }
}
