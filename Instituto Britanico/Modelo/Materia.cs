using BibliotecaBritanico.Utilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BibliotecaBritanico.Modelo
{
    public class Materia
    {
        public int ID { get; set; }
        [JsonIgnore]
        public Sucursal Sucursal { get; set; } = new Sucursal();
        public int SucursalID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        [JsonIgnore]
        public List<Libro> LstLibros { get; set; } = new List<Libro>();



        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
