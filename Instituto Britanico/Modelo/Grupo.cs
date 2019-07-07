using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaBritanico.Utilidad;
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
        public int Anio { get; set; }
        public List<GrupoDia> LstDias { get; set; } = new List<GrupoDia>();
        public List<Estudiante> LstEstudiantes { get; set; } = new List<Estudiante>();



        public override string ToString()
        {
            string dias = Sucursal.Nombre+" ";
            foreach (GrupoDia s in LstDias)
            {
                dias += s.Dia.Substring(0,1);
            }
            dias += " " + HoraInicio + ", " + Materia.Nombre;
            return dias;
        }

        public string DiasDeLaSemana
        {
            get
            {
                string dias = "";
                foreach (GrupoDia s in LstDias)
                {
                    dias += s.Dia+" ";
                }

                return dias;
            }
        }

        public string Nombre { get { return this.ToString(); } }

        public static bool ValidarGrupoInsert(Grupo grupo)
        {
            try
            {
                string errorMsg = String.Empty;
                if (grupo.Anio < 2000 || grupo.Anio > 3000)
                {
                    errorMsg += "Año del grupo incorrecto \n";
                }
                if (grupo.MateriaID < 1)
                {
                    errorMsg = "Debe asignar el grupo a una materia \n";
                }
                if (grupo.SucursalID < 1)
                {
                    errorMsg += "Debe asociar una sucursal al grupo \n";
                }
                if (grupo.HoraInicio.Equals(String.Empty) || grupo.HoraFin.Equals(String.Empty))
                {
                    errorMsg += "Debe ingresar hora de inicio y fin \n";
                }
                if (grupo.Precio < 1)
                {
                    errorMsg += "Debe ingresar precio \n";
                }
                if (grupo.LstDias.Count > 0)
                {
                    bool errorEnDias = false;
                    foreach (GrupoDia dia in grupo.LstDias)
                    {
                        if (dia.Dia.Equals(String.Empty))
                        {
                            errorEnDias = true;
                        }
                    }
                    if (errorEnDias)
                    {
                        errorMsg += "Debe ingresar los dias del grupo \n";
                    }
                }
                else
                {
                    errorMsg += "Debe ingresar los dias del grupo \n";
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

        public static bool ValidarGrupoModificar(Grupo grupo)
        {
            try
            {
                string errorMsg = String.Empty;
                if (grupo.Anio < 2000 || grupo.Anio > 3000)
                {
                    errorMsg += "Año del grupo incorrecto \n";
                }
                if (grupo.ID < 1)
                {
                    errorMsg = "Debe asignar un ID al grupo \n";
                }
                if (grupo.MateriaID < 1)
                {
                    errorMsg += "Debe asignar el grupo a una materia \n";
                }
                if (grupo.SucursalID < 1)
                {
                    errorMsg += "Debe asociar una sucursal al grupo \n";
                }
                if (grupo.HoraInicio.Equals(String.Empty) || grupo.HoraFin.Equals(String.Empty))
                {
                    errorMsg += "Debe ingresar hora de inicio y fin \n";
                }
                if (grupo.Precio < 1)
                {
                    errorMsg += "Debe ingresar precio \n";
                }
                if (grupo.LstDias.Count > 0)
                {
                    bool errorEnDias = false;
                    foreach (GrupoDia dia in grupo.LstDias)
                    {
                        if (dia.Dia.Equals(String.Empty))
                        {
                            errorEnDias = true;
                        }
                    }
                    if (errorEnDias)
                    {
                        errorMsg += "Debe ingresar los dias del grupo \n";
                    }
                }
                else
                {
                    errorMsg += "Debe ingresar los dias del grupo \n";
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
