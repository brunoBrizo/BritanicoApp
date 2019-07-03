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



        public static bool ValidarMateriaInsert(Materia materia)
        {
            string errorMsg = String.Empty;
            if (materia.Nombre.Equals(String.Empty))
            {
                errorMsg = "Debe ingresar el nombre de la materia \n";
            }
            if (materia.Precio < 1)
            {
                errorMsg += "Debe ingresar el precio de la materia \n";
            }
            if (materia.SucursalID < 1)
            {
                errorMsg += "Debe ingresar la sucursal de la materia \n";
            }
            if (!errorMsg.Equals(String.Empty))
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }

        public static bool ValidarMateriaModificar(Materia materia)
        {
            string errorMsg = String.Empty;
            if (materia.ID < 1)
            {
                errorMsg = "Debe asignar un ID a la materia \n";
            }
            if (materia.Nombre.Equals(String.Empty))
            {
                errorMsg += "Debe ingresar el nombre de la materia \n";
            }
            if (materia.Precio < 1)
            {
                errorMsg += "Debe ingresar el precio de la materia \n";
            }
            if (materia.Sucursal.ID < 1)
            {
                errorMsg += "Debe ingresar la sucursal de la materia \n";
            }
            if (!errorMsg.Equals(String.Empty))
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }
       
        public override string ToString()
        {
            return this.Nombre;
        }



    }
}
