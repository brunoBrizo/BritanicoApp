using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BibliotecaBritanico.Modelo
{
    public class Grupo
    {
        public int ID { get; set; }
        [JsonIgnore]
        public Sucursal Sucursal { get; set; } = new Sucursal();
        public int SucursalID { get; set; }
        [JsonIgnore]
        public Materia Materia { get; set; } = new Materia();
        public int MateriaID { get; set; }
        [JsonIgnore]
        public Funcionario Funcionario { get; set; } = new Funcionario();
        public int FuncionarioID { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public decimal Precio { get; set; } //deberia ser el precio de la materia, pero puede variar
        public bool Activo { get; set; }
        public List<GrupoDia> LstDias { get; set; } = new List<GrupoDia>();
        public List<Estudiante> LstEstudiantes { get; set; } = new List<Estudiante>();



        public override string ToString()
        {
            string dias = "";
            foreach(GrupoDia s in LstDias)
            {
                dias += s.Dia;
            }
            dias +=" "+ HoraInicio +", " + Materia.Nombre;
            return dias;
        }

        public string DiasDeLaSemana
        {
            get
            {
                string dias = "";
                foreach (GrupoDia s in LstDias)
                {
                    dias += s.Dia;
                }
                
                return dias;
            }
        }

        public string Nombre { get { return this.ToString(); } }
    }
}
