﻿using BibliotecaBritanico.Modelo;
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
        private ControladorAPI cApi = new ControladorAPI();
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
                return cApi.GetProfesoresTotal();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #region MetodosParaAPI


        #region Materia


        public List<Materia> GetMaterias()
        {
            try
            {
                return cApi.GetListaMaterias();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Materia> CrearMateria(int sucursalID, string nombre, decimal precio)
        {
            try
            {
                Materia materia = new Materia
                {
                    ID = 0,
                    SucursalID = sucursalID,
                    Nombre = nombre,
                    Precio = precio
                };
                materia = await cApi.CrearMateria(materia);
                return materia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Materia> GetMateriasTotal()
        {
            return cApi.GetMateriasTotal();
        }

        public async Task<bool> ModificarMateria(int id, int sucursalID, string nombre, decimal precio)
        {
            try
            {
                Materia materia = new Materia
                {
                    ID = id,
                    SucursalID = sucursalID,
                    Nombre = nombre,
                    Precio = precio
                };
                bool res = await cApi.ModificarMateria(materia);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarMateria(int id)
        {
            try
            {
                Materia materia = new Materia
                {
                    ID = id
                };
                bool res = await cApi.EliminarMateria(materia);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Convenio


        public async Task<Convenio> GetConvenio(int id)
        {
            try
            {
                Convenio convenio = new Convenio
                {
                    ID = id
                };
                convenio = await cApi.GetConvenio(convenio);
                return convenio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Convenio>> GetConvenios()
        {
            try
            {
                return await cApi.GetListaConvenios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Convenio> CrearMateria(string nombre, int anio, string asociadoNombre, string asociadoTel, string asociadoMail, string asociadoDireccion, decimal descuento)
        {
            try
            {
                Convenio convenio = new Convenio
                {
                    ID = 0,
                    Nombre = nombre,
                    FechaHora = DateTime.Now,
                    Anio = anio,
                    AsociadoNombre = asociadoNombre,
                    AsociadoMail = asociadoMail,
                    AsociadoDireccion = asociadoDireccion,
                    AsociadoTel = asociadoTel,
                    Descuento = descuento
                };
                convenio = await cApi.CrearConvenio(convenio);
                return convenio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarMateria(int id, string nombre, int anio, string asociadoNombre, string asociadoTel, string asociadoMail, string asociadoDireccion, decimal descuento)
        {
            try
            {
                Convenio convenio = new Convenio
                {
                    ID = id,
                    Nombre = nombre,
                    FechaHora = DateTime.Now,
                    Anio = anio,
                    AsociadoNombre = asociadoNombre,
                    AsociadoMail = asociadoMail,
                    AsociadoDireccion = asociadoDireccion,
                    AsociadoTel = asociadoTel,
                    Descuento = descuento
                };
                bool res = await cApi.ModificarConvenio(convenio);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarConvenio(int id)
        {
            try
            {
                Convenio convenio = new Convenio
                {
                    ID = id
                };
                bool res = await cApi.EliminarConvenio(convenio);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion








        #endregion







        public List<Estudiante> GetEstudiantesTotal()
        {
            return cApi.GetEstudiantesTotal();
        }

        public List<Libro> GetLibrosTotal()
        {
            return cApi.GetLibrosTotal();
        }

        internal void SetResolucion(Size tamano)
        {
            this.Tamano = tamano;
        }

        internal List<Convenio> GetConveniosTotal()
        {
            return cApi.GetConveniosTotal();
        }

        internal List<Matricula> GetMatriculas()
        {
            return cApi.GetMatriculas();
        }

        public List<Pago> GetPagosTotal()
        {
            return cApi.GetPagosTotal();
        }

        public List<Sucursal> GetSucursalesTotal()
        {
            return cApi.GetSucursalesTotal();
        }


        internal List<Examen> GetExamenesTotal()
        {
            return cApi.GetExamenesTotal();
        }

        internal List<Grupo> GetGruposTotalb()
        {
            return cApi.GetGruposTotalb();
        }

        internal List<Funcionario> GetFuncionariosTotal()
        {
            return cApi.GetFuncionariosTotal();
        }

        public List<Estudiante> GetEstudiantesPorGrupo(Grupo g)
        {
            return cApi.GetEstudiantesPorGrupo(g);
        }

        internal List<Estudiante> GetEstudiantesPorNombre(string texto)
        {
            return cApi.GetEstudiantesPorNombre(texto);
        }

        internal List<Estudiante> GetEstudiantesPorCedula(string cedula)
        {
            return cApi.GetEstudiantesPorCedula(cedula);
        }

        internal List<Funcionario> GetFuncionariosActivos()
        {
            return cApi.GetFuncionariosActivos();
        }

        internal List<Funcionario> GetFuncionariosNoActivos()
        {
            return cApi.GetFuncionariosNoActivos();
        }



        internal List<Pago> GetPagosPorFiltro(string concepto, Sucursal suc, decimal minimo, decimal maximo, DateTime fechaInicial, DateTime fechaFinal)
        {
            return cApi.GetPagosPorFiltros(concepto, suc, minimo, maximo, fechaInicial, fechaFinal, null);
        }

        internal List<Grupo> GetGruposPorNombre(string text)
        {
            try
            {
                return cApi.GetGruposPorNombre(text);
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
                return cApi.AltaEstudiante(nombre, CI, telefono, esAlergico, alergias, contactoUno, contactoUnoTel, contactoDos, contactoDosTel, direccion, correo, fechaNac, convenio, sino);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal Libro AltaLibro(string titulo, Materia materia, decimal precio, string autor, string editorial)
        {
            try
            {
                return cApi.AltaLibro(titulo, materia, precio, autor, editorial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool ModificarEstudiante(int ID, string nombre, string CI, string telefono, bool esAlergico, string alergias, string contactoUno, string contactoUnoTel, string contactoDos, string contactoDosTel, string direccion, string correo, DateTime fechaNac, Convenio convenio, bool sino)
        {
            try
            {
                return cApi.ModificarEstudiante(ID, nombre, CI, telefono, esAlergico, alergias, contactoUno, contactoUnoTel, contactoDos, contactoDosTel, direccion, correo, fechaNac, convenio, sino);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        internal Libro ModificarLibro(int ID, string titulo, Materia materia, decimal precio, string autor, string editorial)
        {
            try
            {
                return cApi.ModificarLibro(ID, titulo, materia, precio, autor, editorial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool EliminarEstudiante(int iD)
        {
            try
            {
                return cApi.EliminarEstudiante(iD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal Grupo AltaGrupo(List<string> listaDias, Sucursal sucursal, Funcionario funcionario, string horaInicio, string horaFin, Materia materia, bool activo, decimal precio)
        {
            try
            {
                return cApi.AltaGrupo(listaDias, sucursal, funcionario, horaInicio, horaFin, materia, activo, precio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool ModificarGrupo(int ID, List<string> listaDias, Sucursal sucursal, Funcionario funcionario, string horaInicio, string horaFin, Materia materia, bool activo, decimal precio)
        {
            try
            {
                return cApi.ModificarGrupo(ID, listaDias, sucursal, funcionario, horaInicio, horaFin, materia, activo, precio);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal bool EliminarGrupo(int ID)
        {
            try
            {
                return cApi.EliminarGrupo(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool EliminarLibro(int ID)
        {
            try
            {
                return cApi.EliminarLibro(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
