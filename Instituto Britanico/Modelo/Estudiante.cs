using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
