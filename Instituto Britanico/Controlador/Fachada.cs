using BibliotecaBritanico.Modelo;
using Instituto_Britanico.Controlador;
using Instituto_Britanico.Vistas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instituto_Britanico.Modelo
{
    public class Fachada
    {

        private static Fachada instancia = null;
        ControladorAPI ca = new ControladorAPI();
        public Size Tamano { get; set; }



        public static Fachada getInstancia()
        {
            if (instancia == null)
            {
                instancia = new Fachada();
        
            }
            return instancia;
        }

        public List<Funcionario> GetProfesoresTotal()
        {
            try
            {
                return ca.GetProfesoresTotal();
            }catch(Exception ex)
            {
                throw ex;
            }
        }


        #region Materia







        #endregion


        public List<Estudiante> GetEstudiantesTotal()
        {
            return ca.GetEstudiantesTotal();
        }

        public List<Libro> GetLibrosTotal()
        {
            return ca.GetLibrosTotal();
        }

        internal void SetResolucion(Size tamano)
        {
            this.Tamano = tamano;
        }

        internal List<Convenio> GetConveniosTotal()
        {
            return ca.GetConveniosTotal();
        }

        internal List<Matricula> GetMatriculas()
        {
            return ca.GetMatriculas();  
        }

        public List<Pago> GetPagosTotal()
        {
            return ca.GetPagosTotal();
        }

        public List<Sucursal> GetSucursalesTotal()
        {
            return ca.GetSucursalesTotal();
        }

        public List<Materia> GetMateriasTotal()
        {
            return ca.GetMateriasTotal();
        }

        internal List<Examen> GetExamenesTotal()
        {
            return ca.GetExamenesTotal();
        }

        internal List<Grupo> GetGruposTotalb()
        {
            return ca.GetGruposTotalb();
        }

        internal List<Funcionario> GetFuncionariosTotal()
        {
            return ca.GetFuncionariosTotal();
        }

        public List<Estudiante> GetEstudiantesPorGrupo(Grupo g)
        {
            return ca.GetEstudiantesPorGrupo(g);
        }

        internal List<Estudiante> GetEstudiantesPorNombre(string texto)
        {
            return ca.GetEstudiantesPorNombre(texto);
        }
    
        internal List<Estudiante> GetEstudiantesPorCedula(string cedula)
        {
            return ca.GetEstudiantesPorCedula(cedula);
        }

        internal List<Funcionario> GetFuncionariosActivos()
        {
            return ca.GetFuncionariosActivos();
        }

        internal List<Funcionario> GetFuncionariosNoActivos()
        {
            return ca.GetFuncionariosNoActivos();
        }

      

        internal List<Pago> GetPagosPorFiltro(string concepto, Sucursal suc, decimal minimo, decimal maximo, DateTime fechaInicial, DateTime fechaFinal)
        {
            return ca.GetPagosPorFiltros(concepto, suc, minimo, maximo, fechaInicial, fechaFinal, null);
        }

        internal List<Grupo> GetGruposPorNombre(string text)
        {
            try
            {
                return ca.GetGruposPorNombre(text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AltaEstudiante(string nombre, string CI, string telefono, bool esAlergico, string alergias, string contactoUno, string contactoUnoTel, string contactoDos, string contactoDosTel, string direccion, string correo, DateTime fechaNac, Convenio convenio, bool sino)
        {
            try
            {
                return ca.AltaEstudiante(nombre, CI, telefono, esAlergico, alergias, contactoUno, contactoUnoTel, contactoDos, contactoDosTel, direccion, correo, fechaNac, convenio, sino);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        internal Libro AltaLibro(string titulo, Materia materia, decimal precio, string autor, string editorial)
        {
            try
            {
                return ca.AltaLibro(titulo, materia, precio, autor, editorial);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        internal bool ModificarEstudiante(int ID, string nombre, string CI, string telefono, bool esAlergico, string alergias, string contactoUno, string contactoUnoTel, string contactoDos, string contactoDosTel, string direccion, string correo, DateTime fechaNac, Convenio convenio, bool sino)
        {
            try
            {
                return ca.ModificarEstudiante(ID, nombre, CI, telefono, esAlergico, alergias, contactoUno, contactoUnoTel, contactoDos, contactoDosTel, direccion, correo, fechaNac, convenio, sino);
            }catch(Exception ex)
            {
                throw ex;
            }
            

        }

        internal Libro ModificarLibro(int ID, string titulo, Materia materia, decimal precio, string autor, string editorial)
        {
            try
            {
                return ca.ModificarLibro(ID, titulo, materia, precio, autor, editorial);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        internal bool EliminarEstudiante(int iD)
        {
            try
            {
                return ca.EliminarEstudiante(iD);
            }       
            catch(Exception ex)
            {
                throw ex;
            }
        }

        internal Grupo AltaGrupo(List<string> listaDias, Sucursal sucursal, Funcionario funcionario, string horaInicio, string horaFin, Materia materia, bool activo, decimal precio)
        {
            try
            {
                return ca.AltaGrupo(listaDias, sucursal, funcionario, horaInicio, horaFin, materia, activo, precio);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        internal bool ModificarGrupo(int ID, List<string> listaDias, Sucursal sucursal, Funcionario funcionario, string horaInicio, string horaFin, Materia materia, bool activo, decimal precio)
        {
            try
            {
                return ca.ModificarGrupo(ID, listaDias, sucursal, funcionario, horaInicio, horaFin, materia, activo, precio);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        internal bool EliminarGrupo(int ID)
        {
            try
            {
                return ca.EliminarGrupo(ID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        internal bool EliminarLibro(int ID)
        {
            try
            {
                return ca.EliminarLibro(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
