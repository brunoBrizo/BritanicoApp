using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BibliotecaBritanico.Modelo
{
    public class ExamenEstudiante
    {
        public int ID { get; set; }
        public Examen Examen { get; set; } = new Examen();
        public Estudiante Estudiante { get; set; } = new Estudiante();
        public DateTime FechaInscripcion { get; set; }
        public decimal NotaFinal { get; set; }
        public string NotaFinalLetra { get; set; }
        public bool Aprobado { get; set; }
        public int CantCuotas { get; set; }
        public FormaPago FormaPago { get; set; }
        public bool Pago { get; set; }
        public decimal Precio { get; set; }
        [JsonIgnore]
        public Funcionario Funcionario { get; set; } = new Funcionario();
        public int FuncionarioID { get; set; }
        public List<ExamenEstudianteCuota> LstCuotas { get; set; } = new List<ExamenEstudianteCuota>();


        public void GenerarCuotas()

        {
            for (int i = 0; i < CantCuotas; i++)
            {
                //aca hay que definir un vencimiento de cuota predefinido
                //LstCuotas.Add(new ExamenEstudianteCuota(i + 1, (Precio / CantCuotas)));

            }
            //luego grabarlas a DB
        }



    }
}
