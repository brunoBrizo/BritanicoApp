using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BibliotecaBritanico.Modelo
{
    public class Examen
    {

        public int ID { get; set; }
        [JsonIgnore]
        public Grupo Grupo { get; set; }
        public int GrupoID { get; set; }
        public int MateriaID { get; set; }
        public DateTime FechaHora { get; set; }
        public int AnioAsociado { get; set; }
        public int NotaMinima { get; set; }
        public decimal Precio { get; set; }

        //debe haber un registro por grupo-año de esta clase

        public Examen()
        {
            this.Grupo = new Grupo();
        }

    }
}

