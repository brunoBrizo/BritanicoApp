using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BibliotecaBritanico.Modelo
{
    public class MatriculaEstudiante
    {
        public int ID { get; set; }
        public Matricula Matricula { get; set; }
        [JsonIgnore]
        public Sucursal Sucursal { get; set; } //es la sucursal donde se le tomo la matricula, independiente del curso donde lo va a hacer  
        public int SucursalID { get; set; }
        public Estudiante Estudiante { get; set; } //el estudiante tiene la lista de matriculas, esto se deja para saber cuantos estudiantes se matricularon
        [JsonIgnore]
        public Grupo Grupo { get; set; }
        public int GrupoID { get; set; }
        public int MateriaID { get; set; }
        public DateTime FechaHora { get; set; }
        [JsonIgnore]
        public Funcionario Funcionario { get; set; }
        public int FuncionarioID { get; set; }
        public decimal Descuento { get; set; }
        public decimal Precio { get; set; }

        public MatriculaEstudiante()
        {
            this.Matricula = new Matricula();
            this.Sucursal = new Sucursal();
            this.Estudiante = new Estudiante();
            this.Grupo = new Grupo();
            this.Funcionario = new Funcionario();
        }


    }
}
