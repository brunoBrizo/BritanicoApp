using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaBritanico.Utilidad;
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

        public static bool ValidarMatriculaEstudianteInsert(MatriculaEstudiante matriculaEstudiante)
        {
            try
            {
                string errorMsg = String.Empty;
                if (matriculaEstudiante.Matricula.ID < 1)
                {
                    errorMsg = "Debe asociar a una matricula \n";
                }
                if (matriculaEstudiante.Estudiante.ID < 1)
                {
                    errorMsg += "Debe asociar la matricula a un estudiante \n";
                }
                if (matriculaEstudiante.GrupoID < 1 || matriculaEstudiante.MateriaID < 1)
                {
                    errorMsg += "Debe asociar la matricula a un grupo \n";
                }
                if (matriculaEstudiante.FuncionarioID < 1)
                {
                    errorMsg += "Debe asociar la matricula a un funcionario \n";
                }
                if (matriculaEstudiante.Precio < 1)
                {
                    errorMsg += "Debe ingresar precio \n";
                }
                if (!errorMsg.Equals(String.Empty))
                {
                    throw new ValidacionException(errorMsg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidarMatriculaEstudianteModificar(MatriculaEstudiante matriculaEstudiante)
        {
            try
            {
                string errorMsg = String.Empty;
                if (matriculaEstudiante.ID < 1)
                {
                    errorMsg = "Debe asignar ID a la matricula del estudiante \n";
                }
                if (matriculaEstudiante.Matricula.ID < 1)
                {
                    errorMsg += "Debe asociar a una matricula \n";
                }
                if (matriculaEstudiante.Estudiante.ID < 1)
                {
                    errorMsg += "Debe asociar la matricula a un estudiante \n";
                }
                if (matriculaEstudiante.GrupoID < 1 || matriculaEstudiante.MateriaID < 1)
                {
                    errorMsg += "Debe asociar la matricula a un grupo \n";
                }
                if (matriculaEstudiante.FuncionarioID < 1)
                {
                    errorMsg += "Debe asociar la matricula a un funcionario \n";
                }
                if (matriculaEstudiante.Precio < 1)
                {
                    errorMsg += "Debe ingresar precio \n";
                }
                if (!errorMsg.Equals(String.Empty))
                {
                    throw new ValidacionException(errorMsg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
