using BibliotecaBritanico.Modelo;
using BibliotecaBritanico.Utilidad;
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

        public Materia GetMateria(int id)
        {
            return cApi.GetMateriaByID(id);
        }

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

        public async Task<Convenio> CrearConvenio(string nombre, int anio, string asociadoNombre, string asociadoTel, string asociadoMail, string asociadoDireccion, decimal descuento)
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

        public async Task<bool> ModificarConvenio(int id, string nombre, DateTime fechaHora, int anio, string asociadoNombre, string asociadoTel, string asociadoMail, string asociadoDireccion, decimal descuento)
        {
            try
            {
                Convenio convenio = new Convenio
                {
                    ID = id,
                    Nombre = nombre,
                    FechaHora = fechaHora,
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


        #region Email


        public async Task<Email> GetEmail(int id)
        {
            try
            {
                Email email = new Email
                {
                    ID = id
                };
                email = await cApi.GetEmail(email);
                return email;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Email>> GetEmails()
        {
            try
            {
                return await cApi.GetListaEmails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Email>> GetEmailsEntreFechas(DateTime desde, DateTime hasta)
        {
            try
            {
                return await cApi.GetListaEmailsEntreFechas(desde, hasta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Email> CrearEmail(string destinatarioMail, string destinatarioNombre, string asunto, string cuerpoHTML)
        {
            try
            {
                Email email = new Email
                {
                    ID = 0,
                    DestinatarioNombre = destinatarioNombre,
                    DestinatarioEmail = destinatarioMail,
                    Asunto = asunto,
                    CuerpoHTML = cuerpoHTML,
                    FechaHora = DateTime.Now,
                    Enviado = false
                };
                email = await cApi.CrearEmail(email);
                return email;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarEmail(int id, string destinatarioMail, string destinatarioNombre, string asunto, string cuerpoHTML, bool enviado, DateTime fechaHora)
        {
            try
            {
                Email email = new Email
                {
                    ID = id,
                    DestinatarioNombre = destinatarioNombre,
                    DestinatarioEmail = destinatarioMail,
                    Asunto = asunto,
                    CuerpoHTML = cuerpoHTML,
                    FechaHora = fechaHora,
                    Enviado = enviado
                };
                bool res = await cApi.ModificarEmail(email);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarEmail(int id)
        {
            try
            {
                Email email = new Email
                {
                    ID = id
                };
                bool res = await cApi.EliminarEmail(email);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Parametro


        public async Task<Parametro> GetParametro(int id)
        {
            try
            {
                Parametro parametro = new Parametro
                {
                    ID = id
                };
                parametro = await cApi.GetParametro(parametro);
                return parametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Parametro>> GetParametros()
        {
            try
            {
                return await cApi.GetListaParametros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Parametro> CrearParametro(int id, string nombre, string valor)
        {
            try
            {
                Parametro parametro = new Parametro
                {
                    ID = id,
                    Nombre = nombre,
                    Valor = valor
                };
                parametro = await cApi.CrearParametro(parametro);
                return parametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarParametro(int id, string nombre, string valor)
        {
            try
            {
                Parametro parametro = new Parametro
                {
                    ID = id,
                    Nombre = nombre,
                    Valor = valor
                };
                bool res = await cApi.ModificarParametro(parametro);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarParametro(int id)
        {
            try
            {
                Parametro parametro = new Parametro
                {
                    ID = id
                };
                bool res = await cApi.EliminarParametro(parametro);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Libro


        public async Task<Libro> GetLibro(int id, Materia materia)
        {
            try
            {
                Libro libro = new Libro
                {
                    ID = id,
                    Materia = materia
                };
                libro = await cApi.GetLibro(libro);
                return libro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Libro>> GetLibros()
        {
            try
            {
                return await cApi.GetListaLibros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Libro> CrearLibro(string nombre, Materia materia, decimal precio, string autor, string editorial)
        {
            try
            {
                Libro libro = new Libro
                {
                    ID = 0,
                    Nombre = nombre,
                    Materia = materia,
                    Precio = precio,
                    Autor = autor,
                    Editorial = editorial
                };
                libro = await cApi.CrearLibro(libro);
                return libro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarLibro(int id, string nombre, Materia materia, string autor, string editorial, decimal precio)
        {
            try
            {
                Libro libro = new Libro
                {
                    ID = id,
                    Nombre = nombre,
                    Materia = materia,
                    Precio = precio,
                    Autor = autor,
                    Editorial = editorial
                };
                bool res = await cApi.ModificarLibro(libro);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarLibro(int id, Materia materia)
        {
            try
            {
                Libro libro = new Libro
                {
                    ID = id,
                    Materia = materia
                };
                bool res = await cApi.EliminarLibro(libro);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Funcionario


        public async Task<Funcionario> LoginFuncionario(string ci, string password)
        {
            try
            {
                Funcionario funcionario = new Funcionario
                {
                    CI = ci,
                    Clave = password
                };
                funcionario = await cApi.LoginFuncionario(funcionario);
                return funcionario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Funcionario> GetFuncionario(int id)
        {
            try
            {
                Funcionario funcionario = new Funcionario
                {
                    ID = id
                };
                funcionario = await cApi.GetFuncionario(funcionario);
                return funcionario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Funcionario>> GetFuncionarios()
        {
            try
            {
                return await cApi.GetListaFuncionarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Funcionario> CrearFuncionario(int sucursalID, string nombre, string ci, string email, string telefono, string telefonoAux,
            string direccion, DateTime fechaNac, string clave, bool activo, FuncionarioTipo tipo)
        {
            try
            {
                Funcionario funcionario = new Funcionario
                {
                    ID = 0,
                    SucursalID = sucursalID,
                    CI = ci,
                    Email = email,
                    Nombre = nombre,
                    Telefono = telefono,
                    TelefonoAux = telefonoAux,
                    Direccion = direccion,
                    FechaNac = fechaNac,
                    Clave = clave,
                    Activo = activo,
                    TipoFuncionario = tipo
                };
                funcionario = await cApi.CrearFuncionario(funcionario);
                return funcionario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarFuncionario(int id, int sucursalID, string nombre, string ci, string email, string telefono, string telefonoAux,
            string direccion, DateTime fechaNac, string clave, bool activo, FuncionarioTipo tipo)
        {
            try
            {
                Funcionario funcionario = new Funcionario
                {
                    ID = id,
                    SucursalID = sucursalID,
                    CI = ci,
                    Email = email,
                    Nombre = nombre,
                    Telefono = telefono,
                    TelefonoAux = telefonoAux,
                    Direccion = direccion,
                    FechaNac = fechaNac,
                    Clave = clave,
                    Activo = activo,
                    TipoFuncionario = tipo
                };
                bool res = await cApi.ModificarFuncionario(funcionario);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarFuncionario(int id)
        {
            try
            {
                Funcionario funcionario = new Funcionario
                {
                    ID = id
                };
                bool res = await cApi.EliminarFuncionario(funcionario);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Matricula


        public async Task<Matricula> GetMatricula(int id)
        {
            try
            {
                Matricula matricula = new Matricula
                {
                    ID = id
                };
                matricula = await cApi.GetMatricula(matricula);
                return matricula;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Matricula>> GetMatriculas()
        {
            try
            {
                return await cApi.GetListaMatriculas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Matricula> CrearMatricula(int sucursalID, int anio, decimal precio)
        {
            try
            {
                Matricula matricula = new Matricula
                {
                    ID = 0,
                    SucursalID = sucursalID,
                    Anio = anio,
                    FechaHora = DateTime.Now,
                    Precio = precio
                };
                matricula = await cApi.CrearMatricula(matricula);
                return matricula;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarMatricula(int id, int sucursalID, int anio, decimal precio, DateTime fechaHora)
        {
            try
            {
                Matricula matricula = new Matricula
                {
                    ID = id,
                    SucursalID = sucursalID,
                    Anio = anio,
                    FechaHora = fechaHora,
                    Precio = precio
                };
                bool res = await cApi.ModificarMatricula(matricula);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarMatricula(int id)
        {
            try
            {
                Matricula matricula = new Matricula
                {
                    ID = id
                };
                bool res = await cApi.EliminarMatricula(matricula);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Empresa


        public async Task<Empresa> GetEmpresa(int id, string rut)
        {
            try
            {
                Empresa empresa = new Empresa();
                if (id > 0)
                    empresa.ID = id;
                else
                    empresa.Rut = rut;
                empresa = await cApi.GetEmpresa(empresa);
                return empresa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Empresa>> GetEmpresas()
        {
            try
            {
                return await cApi.GetListaEmpresas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Empresa> CrearEmpresa(string rut, string razonSoc, string nombre, string email, string direccion, string tel, string logo, string logoImagen)
        {
            try
            {
                Empresa empresa = new Empresa
                {
                    ID = 0,
                    Rut = rut,
                    RazonSoc = razonSoc,
                    Nombre = nombre,
                    Email = email,
                    Direccion = direccion,
                    Tel = tel,
                    Logo = logo,
                    LogoImagen = logoImagen
                };
                empresa = await cApi.CrearEmpresa(empresa);
                return empresa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarEmpresa(int id, string rut, string razonSoc, string nombre, string email, string direccion, string tel, string logo, string logoImagen)
        {
            try
            {
                Empresa empresa = new Empresa
                {
                    ID = id,
                    Rut = rut,
                    RazonSoc = razonSoc,
                    Nombre = nombre,
                    Email = email,
                    Direccion = direccion,
                    Tel = tel,
                    Logo = logo,
                    LogoImagen = logoImagen
                };
                bool res = await cApi.ModificarEmpresa(empresa);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarEmpresa(int id)
        {
            try
            {
                Empresa empresa = new Empresa
                {
                    ID = id
                };
                bool res = await cApi.EliminarEmpresa(empresa);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Pago


        public async Task<Pago> GetPago(int id)
        {
            try
            {
                Pago pago = new Pago
                {
                    ID = id
                };
                pago = await cApi.GetPago(pago);
                return pago;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Pago>> GetPagos()
        {
            try
            {
                return await cApi.GetListaPagos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pago> CrearPago(int sucursalID, string concepto, decimal monto, int funcionarioID, string observacion)
        {
            try
            {
                Pago pago = new Pago
                {
                    ID = 0,
                    FechaHora = DateTime.Now,
                    SucursalID = sucursalID,
                    Concepto = concepto,
                    Monto = monto,
                    FuncionarioID = funcionarioID,
                    Observacion = observacion
                };
                pago = await cApi.CrearPago(pago);
                return pago;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarPago(int id, int sucursalID, string concepto, decimal monto, int funcionarioID, string observacion, DateTime fechaHora)
        {
            try
            {
                Pago pago = new Pago
                {
                    ID = id,
                    FechaHora = fechaHora,
                    SucursalID = sucursalID,
                    Concepto = concepto,
                    Monto = monto,
                    FuncionarioID = funcionarioID,
                    Observacion = observacion
                };
                bool res = await cApi.ModificarPago(pago);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarPago(int id)
        {
            try
            {
                Pago pago = new Pago
                {
                    ID = id
                };
                bool res = await cApi.EliminarPago(pago);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Empresa


        public async Task<Sucursal> GetSucursal(int id)
        {
            try
            {
                Sucursal sucursal = new Sucursal
                {
                    ID = id
                };
                sucursal = await cApi.GetSucursal(sucursal);
                return sucursal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Sucursal>> GetSucursales()
        {
            try
            {
                return await cApi.GetListaSucursales();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sucursal> CrearSucursal(string nombre, string email, string direccion, string tel, string ciudad, string encargado)
        {
            try
            {
                Sucursal sucursal = new Sucursal
                {
                    ID = 0,
                    Nombre = nombre,
                    Email = email,
                    Direccion = direccion,
                    Tel = tel,
                    Ciudad = ciudad,
                    Encargado = encargado
                };
                sucursal = await cApi.CrearSucursal(sucursal);
                return sucursal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarSucursal(int id, string nombre, string email, string direccion, string tel, string ciudad, string encargado)
        {
            try
            {
                Sucursal sucursal = new Sucursal
                {
                    ID = id,
                    Nombre = nombre,
                    Email = email,
                    Direccion = direccion,
                    Tel = tel,
                    Ciudad = ciudad,
                    Encargado = encargado
                };
                bool res = await cApi.ModificarSucursal(sucursal);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarSucursal(int id)
        {
            try
            {
                Sucursal sucursal = new Sucursal
                {
                    ID = id
                };
                bool res = await cApi.EliminarSucursal(sucursal);
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
