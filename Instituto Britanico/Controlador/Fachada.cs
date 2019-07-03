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

        public Size Tamano { get; set; }

        public static ControladorAPI CApi = null;

        public static Fachada getInstancia()
        {
            if (instancia == null)
            {
                instancia = new Fachada();
            }
            return instancia;
        }

        public static async Task<Fachada> getInstanciaAsync()
        {
            if (instancia == null)
            {
                instancia = new Fachada();
                CApi = await GetControladorAPI();
            }
            return instancia;
        }

        private static async Task<ControladorAPI> GetControladorAPI()
        {
            return await ControladorAPI.getInstancia();
        }

        public List<Funcionario> GetProfesoresTotal()
        {
            try
            {
                return CApi.GetProfesoresTotal();
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
            return CApi.GetMateriaByID(id);
        }

        public List<Materia> GetMaterias()
        {
            try
            {
                return CApi.GetListaMaterias();
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
                Materia.ValidarMateriaInsert(materia);
                materia = await CApi.CrearMateria(materia);
                return materia;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                Materia.ValidarMateriaModificar(materia);
                bool res = await CApi.ModificarMateria(materia);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                if (id < 1)
                    throw new ValidacionException("Debe asignar un ID a la materia");
                Materia materia = new Materia
                {
                    ID = id
                };
                bool res = await CApi.EliminarMateria(materia);
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
                if (id < 1)
                    throw new ValidacionException("Debe asignar un ID al convenio");
                Convenio convenio = new Convenio
                {
                    ID = id
                };
                convenio = await CApi.GetConvenio(convenio);
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
                return await CApi.GetListaConvenios();
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
                Convenio.ValidarConvenioInsert(convenio);
                convenio = await CApi.CrearConvenio(convenio);
                return convenio;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                Convenio.ValidarConvenioModificar(convenio);
                bool res = await CApi.ModificarConvenio(convenio);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                if (id < 1)
                    throw new ValidacionException("Debe asignar un ID al convenio");
                Convenio convenio = new Convenio
                {
                    ID = id
                };
                bool res = await CApi.EliminarConvenio(convenio);
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
                if (id < 1)
                    throw new ValidacionException("Debe asignar ID al email");
                Email email = new Email
                {
                    ID = id
                };
                email = await CApi.GetEmail(email);
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
                return await CApi.GetListaEmails();
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
                return await CApi.GetListaEmailsEntreFechas(desde, hasta);
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
                Email.ValidarEmailInsert(email);
                email = await CApi.CrearEmail(email);
                return email;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                Email.ValidarEmailModificar(email);
                bool res = await CApi.ModificarEmail(email);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                if (id < 1)
                    throw new ValidacionException("Debe asignar ID al email");
                Email email = new Email
                {
                    ID = id
                };
                bool res = await CApi.EliminarEmail(email);
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
                if (id < 1)
                    throw new ValidacionException("Debe asignar un ID al parametro");
                Parametro parametro = new Parametro
                {
                    ID = id
                };
                parametro = await CApi.GetParametro(parametro);
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
                return await CApi.GetListaParametros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Parametro> CrearParametro(string nombre, string valor)
        {
            try
            {
                Parametro parametro = new Parametro
                {
                    ID = 0,
                    Nombre = nombre,
                    Valor = valor
                };
                Parametro.ValidarParametroInsert(parametro);
                parametro = await CApi.CrearParametro(parametro);
                return parametro;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                Parametro.ValidarParametroModificar(parametro);
                bool res = await CApi.ModificarParametro(parametro);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                if (id < 1)
                    throw new ValidacionException("Debe asignar un ID al parametro");
                Parametro parametro = new Parametro
                {
                    ID = id
                };
                bool res = await CApi.EliminarParametro(parametro);
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
                if (id < 1 || materia == null || materia.ID < 1)
                {
                    throw new ValidacionException("Debe asignar un ID y una materia al libro");
                }
                Libro libro = new Libro
                {
                    ID = id,
                    Materia = materia
                };
                libro = await CApi.GetLibro(libro);
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
                return await CApi.GetListaLibros();
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
                Libro.ValidarInsertLibro(libro);
                libro = await CApi.CrearLibro(libro);
                return libro;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                Libro.ValidarModificarLibro(libro);
                bool res = await CApi.ModificarLibro(libro);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                if (id < 1 || materia == null || materia.ID < 1)
                {
                    throw new ValidacionException("Debe asignar un ID y una materia al libro");
                }
                Libro libro = new Libro
                {
                    ID = id,
                    Materia = materia
                };
                bool res = await CApi.EliminarLibro(libro);
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
                if (ci.Equals(String.Empty) || password.Equals(String.Empty))
                {
                    throw new ValidacionException("CI y clave no pueden ser vacios");
                }
                Funcionario funcionario = new Funcionario
                {
                    CI = ci,
                    Clave = password
                };
                funcionario = await CApi.LoginFuncionario(funcionario);
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
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar un ID al funcionario");
                }
                Funcionario funcionario = new Funcionario
                {
                    ID = id
                };
                funcionario = await CApi.GetFuncionario(funcionario);
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
                return await CApi.GetListaFuncionarios();
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
                Funcionario.ValidarFuncionarioInsert(funcionario);
                funcionario = await CApi.CrearFuncionario(funcionario);
                return funcionario;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                Funcionario.ValidarFuncionarioModificar(funcionario);
                bool res = await CApi.ModificarFuncionario(funcionario);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar un ID al funcionario");
                }
                Funcionario funcionario = new Funcionario
                {
                    ID = id
                };
                bool res = await CApi.EliminarFuncionario(funcionario);
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
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar un a la matricula");
                }
                Matricula matricula = new Matricula
                {
                    ID = id
                };
                matricula = await CApi.GetMatricula(matricula);
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
                return await CApi.GetListaMatriculas();
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
                Matricula.ValidarMatriculaInsert(matricula);
                matricula = await CApi.CrearMatricula(matricula);
                return matricula;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                Matricula.ValidarMatriculaModificar(matricula);
                bool res = await CApi.ModificarMatricula(matricula);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar un a la matricula");
                }
                Matricula matricula = new Matricula
                {
                    ID = id
                };
                bool res = await CApi.EliminarMatricula(matricula);
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
                else if (!rut.Equals(String.Empty))
                    empresa.Rut = rut;
                else
                    throw new ValidacionException("Debe asignar ID o RUT a la empresa");
                empresa = await CApi.GetEmpresa(empresa);
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
                return await CApi.GetListaEmpresas();
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
                Empresa.ValidarEmpresaInsert(empresa);
                empresa = await CApi.CrearEmpresa(empresa);
                return empresa;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                Empresa.ValidarEmpresaModificar(empresa);
                bool res = await CApi.ModificarEmpresa(empresa);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar ID a la empresa");
                }
                Empresa empresa = new Empresa
                {
                    ID = id
                };
                bool res = await CApi.EliminarEmpresa(empresa);
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
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar un ID al pago");
                }
                Pago pago = new Pago
                {
                    ID = id
                };
                pago = await CApi.GetPago(pago);
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
                return await CApi.GetListaPagos();
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
                Pago.ValidarPagoInsert(pago);
                pago = await CApi.CrearPago(pago);
                return pago;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                Pago.ValidarPagoModificar(pago);
                bool res = await CApi.ModificarPago(pago);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar un ID al pago");
                }
                Pago pago = new Pago
                {
                    ID = id
                };
                bool res = await CApi.EliminarPago(pago);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Sucursal


        public async Task<Sucursal> GetSucursal(int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar un ID al pago");
                }
                Sucursal sucursal = new Sucursal
                {
                    ID = id
                };
                sucursal = await CApi.GetSucursal(sucursal);
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
                return await CApi.GetListaSucursales();
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
                Sucursal.ValidarSucursalInsert(sucursal);
                sucursal = await CApi.CrearSucursal(sucursal);
                return sucursal;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                Sucursal.ValidarSucursalModificar(sucursal);
                bool res = await CApi.ModificarSucursal(sucursal);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
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
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar un ID al pago");
                }
                Sucursal sucursal = new Sucursal
                {
                    ID = id
                };
                bool res = await CApi.EliminarSucursal(sucursal);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Estudiante


        public async Task<Estudiante> GetEstudiante(int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar un ID al estudiante");
                }
                Estudiante estudiante = new Estudiante
                {
                    ID = id
                };
                estudiante = await CApi.GetEstudiante(estudiante);
                return estudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Estudiante>> GetEstudiantes()
        {
            try
            {
                return await CApi.GetListaEstudiantes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Estudiante> CrearEstudiante(string nombre, TipoDocumento tipoDocumento, string ci, string tel, string email, string direccion, DateTime fechaNac,
            bool alergico, string alergias, string contactoAlternativoUno, string contactoAlternativoUnoTel, string contactoAlternativoDos, string contactoAlternativoDosTel,
            Convenio convenio, int grupoID, int materiaID)
        {
            try
            {
                Estudiante estudiante = new Estudiante
                {
                    ID = 0,
                    Nombre = nombre,
                    TipoDocumento = tipoDocumento,
                    CI = ci,
                    Tel = tel,
                    Email = email,
                    Direccion = direccion,
                    FechaNac = fechaNac,
                    Alergico = alergico,
                    Alergias = alergias,
                    ContactoAlternativoUno = contactoAlternativoUno,
                    ContactoAlternativoUnoTel = contactoAlternativoUnoTel,
                    ContactoAlternativoDos = contactoAlternativoDos,
                    ContactoAlternativoDosTel = contactoAlternativoDosTel,
                    Convenio = convenio,
                    GrupoID = grupoID,
                    MateriaID = materiaID
                };
                Estudiante.ValidarEstudianteInsert(estudiante);
                estudiante = await CApi.CrearEstudiante(estudiante);
                return estudiante;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarEstudiante(int id, string nombre, TipoDocumento tipoDocumento, string ci, string tel, string email, string direccion, DateTime fechaNac,
            bool alergico, string alergias, string contactoAlternativoUno, string contactoAlternativoUnoTel, string contactoAlternativoDos, string contactoAlternativoDosTel,
            Convenio convenio, int grupoID, int materiaID)
        {
            try
            {
                Estudiante estudiante = new Estudiante
                {
                    ID = id,
                    Nombre = nombre,
                    TipoDocumento = tipoDocumento,
                    CI = ci,
                    Tel = tel,
                    Email = email,
                    Direccion = direccion,
                    FechaNac = fechaNac,
                    Alergico = alergico,
                    Alergias = alergias,
                    ContactoAlternativoUno = contactoAlternativoUno,
                    ContactoAlternativoUnoTel = contactoAlternativoUnoTel,
                    ContactoAlternativoDos = contactoAlternativoDos,
                    ContactoAlternativoDosTel = contactoAlternativoDosTel,
                    Convenio = convenio,
                    GrupoID = grupoID,
                    MateriaID = materiaID
                };
                Estudiante.ValidarEstudianteModificar(estudiante);
                bool res = await CApi.ModificarEstudiante(estudiante);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarEstudiante(int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar un ID al estudiante");
                }
                Estudiante estudiante = new Estudiante
                {
                    ID = id
                };
                bool res = await CApi.EliminarEstudiante(estudiante);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Examen


        public async Task<Examen> GetExamen(int id, int grupoID)
        {
            try
            {
                if (id < 1 || grupoID < 1)
                {
                    throw new ValidacionException("Debe asignar ID y grupo al examen");
                }
                Examen examen = new Examen
                {
                    ID = id,
                    GrupoID = grupoID
                };
                examen = await CApi.GetExamen(examen);
                return examen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Examen>> GetExamenes()
        {
            try
            {
                return await CApi.GetListaExamenes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Examen> CrearExamen(int grupoID, int materiaID, int anioAsociado, int notaMinima, decimal precio)
        {
            try
            {
                Examen examen = new Examen
                {
                    ID = 0,
                    GrupoID = grupoID,
                    MateriaID = materiaID,
                    AnioAsociado = anioAsociado,
                    NotaMinima = notaMinima,
                    Precio = precio,
                    FechaHora = DateTime.Now
                };
                Examen.ValidarExamenInsert(examen);
                examen = await CApi.CrearExamen(examen);
                return examen;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarExamen(int id, int grupoID, int materiaID, int anioAsociado, int notaMinima, decimal precio, DateTime fechaHora)
        {
            try
            {
                Examen examen = new Examen
                {
                    ID = id,
                    GrupoID = grupoID,
                    MateriaID = materiaID,
                    AnioAsociado = anioAsociado,
                    NotaMinima = notaMinima,
                    Precio = precio,
                    FechaHora = fechaHora
                };
                Examen.ValidarExamenModificar(examen);
                bool res = await CApi.ModificarExamen(examen);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarExamen(int id, int grupoID)
        {
            try
            {
                if (id < 1 || grupoID < 1)
                {
                    throw new ValidacionException("Debe asignar ID y grupo al examen");
                }
                Examen examen = new Examen
                {
                    ID = id,
                    GrupoID = grupoID
                };
                bool res = await CApi.EliminarExamen(examen);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Grupo


        public async Task<Grupo> GetGrupo(int id, int materiaID)
        {
            try
            {
                if (id < 1 || materiaID < 1)
                {
                    throw new ValidacionException("Debe asignar ID y una materia al grupo");
                }
                Grupo grupo = new Grupo
                {
                    ID = id,
                    MateriaID = materiaID
                };
                grupo = await CApi.GetGrupo(grupo);
                return grupo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grupo> GetGrupos()
        {
            try
            {
                return CApi.GetListaGrupos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Grupo> CrearGrupo(int materiaID, int sucursalID, int funcionarioID, string horaInicio, string horaFin, decimal precio, bool activo, List<GrupoDia> dias)
        {
            try
            {
                Grupo grupo = new Grupo
                {
                    ID = 0,
                    MateriaID = materiaID,
                    SucursalID = sucursalID,
                    FuncionarioID = funcionarioID,
                    HoraInicio = horaInicio,
                    HoraFin = horaFin,
                    Precio = precio,
                    Activo = activo,
                    LstDias = dias
                };
                Grupo.ValidarGrupoInsert(grupo);
                grupo = await CApi.CrearGrupo(grupo);
                return grupo;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarGrupo(int id, int materiaID, int sucursalID, int funcionarioID, string horaInicio, string horaFin, decimal precio, bool activo, List<GrupoDia> dias)
        {
            try
            {
                Grupo grupo = new Grupo
                {
                    ID = id,
                    MateriaID = materiaID,
                    SucursalID = sucursalID,
                    FuncionarioID = funcionarioID,
                    HoraInicio = horaInicio,
                    HoraFin = horaFin,
                    Precio = precio,
                    Activo = activo,
                    LstDias = dias
                };
                Grupo.ValidarGrupoModificar(grupo);
                bool res = await CApi.ModificarGrupo(grupo);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarGrupo(int id, int materiaID)
        {
            try
            {
                if (id < 1 || materiaID < 1)
                {
                    throw new ValidacionException("Debe asignar ID y una materia al grupo");
                }
                Grupo grupo = new Grupo
                {
                    ID = id,
                    MateriaID = materiaID
                };
                bool res = await CApi.EliminarGrupo(grupo);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region MatriculaEstudiante


        public async Task<MatriculaEstudiante> GetMatriculaEstudiante(int id, int matriculaID, int estudianteID, int grupoID)
        {
            try
            {
                if (id < 1 || matriculaID < 1)
                {
                    throw new ValidacionException("Debe asignar ID y una matricula");
                }
                if (estudianteID < 1 || grupoID < 1)
                {
                    throw new ValidacionException("Debe asignar un estudiante y un grupo");
                }
                MatriculaEstudiante matriculaEstudiante = new MatriculaEstudiante
                {
                    ID = id,
                    GrupoID = grupoID
                };
                Matricula matricula = new Matricula
                {
                    ID = matriculaID
                };
                matriculaEstudiante.Matricula = matricula;
                Estudiante estudiante = new Estudiante
                {
                    ID = estudianteID
                };
                matriculaEstudiante.Estudiante = estudiante;
                matriculaEstudiante = await CApi.GetMatriculaEstudiante(matriculaEstudiante);
                return matriculaEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MatriculaEstudiante>> GetListaMatriculaEstudiante()
        {
            try
            {
                return await CApi.GetListaMatriculaEstudiante();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MatriculaEstudiante> CrearMatriculaEstudiante(int matriculaID, int estudianteID, int grupoID, int materiaID, int sucursalID, int funcionarioID, decimal descuento, decimal precio)
        {
            try
            {
                MatriculaEstudiante matriculaEstudiante = new MatriculaEstudiante
                {
                    ID = 0,
                    GrupoID = grupoID,
                    MateriaID = materiaID,
                    SucursalID = sucursalID,
                    FuncionarioID = funcionarioID,
                    Descuento = descuento,
                    Precio = precio
                };
                Matricula matricula = new Matricula
                {
                    ID = matriculaID
                };
                matriculaEstudiante.Matricula = matricula;
                Estudiante estudiante = new Estudiante
                {
                    ID = estudianteID
                };
                matriculaEstudiante.Estudiante = estudiante;
                MatriculaEstudiante.ValidarMatriculaEstudianteInsert(matriculaEstudiante);
                matriculaEstudiante = await CApi.CrearMatriculaEstudiante(matriculaEstudiante);
                return matriculaEstudiante;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarMatriculaEstudiante(int id, int matriculaID, int estudianteID, int grupoID, int materiaID, int sucursalID, int funcionarioID, decimal descuento, decimal precio)
        {
            try
            {
                MatriculaEstudiante matriculaEstudiante = new MatriculaEstudiante
                {
                    ID = id,
                    GrupoID = grupoID,
                    MateriaID = materiaID,
                    SucursalID = sucursalID,
                    FuncionarioID = funcionarioID,
                    Descuento = descuento,
                    Precio = precio
                };
                Matricula matricula = new Matricula
                {
                    ID = matriculaID
                };
                matriculaEstudiante.Matricula = matricula;
                Estudiante estudiante = new Estudiante
                {
                    ID = estudianteID
                };
                matriculaEstudiante.Estudiante = estudiante;
                MatriculaEstudiante.ValidarMatriculaEstudianteModificar(matriculaEstudiante);
                bool res = await CApi.ModificarMatriculaEstudiante(matriculaEstudiante);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarMatriculaEstudiante(int id, int matriculaID, int estudianteID, int grupoID)
        {
            try
            {
                if (id < 1 || matriculaID < 1)
                {
                    throw new ValidacionException("Debe asignar ID y una matricula");
                }
                if (estudianteID < 1 || grupoID < 1)
                {
                    throw new ValidacionException("Debe asignar un estudiante y un grupo");
                }
                MatriculaEstudiante matriculaEstudiante = new MatriculaEstudiante
                {
                    ID = id,
                    GrupoID = grupoID
                };
                Matricula matricula = new Matricula
                {
                    ID = matriculaID
                };
                matriculaEstudiante.Matricula = matricula;
                Estudiante estudiante = new Estudiante
                {
                    ID = estudianteID
                };
                matriculaEstudiante.Estudiante = estudiante;
                bool res = await CApi.EliminarMatriculaEstudiante(matriculaEstudiante);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Mensualidad


        public async Task<Mensualidad> GetMensualidad(int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar ID a la mensualidad");
                }
                Mensualidad mensualidad = new Mensualidad
                {
                    ID = id
                };
                mensualidad = await CApi.GetMensualidad(mensualidad);
                return mensualidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Mensualidad>> GetMensualidades()
        {
            try
            {
                return await CApi.GetListaMensualidades();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Mensualidad> CrearMensualidad(int sucursalID, int estudianteID, int grupoID, int materiaID, int mes, int anio, int funcionarioID, decimal precio)
        {
            try
            {
                Mensualidad mensualidad = new Mensualidad
                {
                    ID = 0,
                    SucursalID = sucursalID,
                    GrupoID = grupoID,
                    MateriaID = materiaID,
                    FuncionarioID = funcionarioID,
                    MesAsociado = mes,
                    AnioAsociado = anio,
                    Precio = precio,
                    FechaHora = DateTime.Now
                };
                Estudiante estudiante = new Estudiante
                {
                    ID = estudianteID
                };
                mensualidad.Estudiante = estudiante;
                Mensualidad.ValidarMensualidadInsert(mensualidad);
                mensualidad = await CApi.CrearMensualidad(mensualidad);
                return mensualidad;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarMensualidad(int id, int sucursalID, int estudianteID, int grupoID, int materiaID, int mes, int anio, int funcionarioID, decimal precio, DateTime fechaHora)
        {
            try
            {
                Mensualidad mensualidad = new Mensualidad
                {
                    ID = id,
                    SucursalID = sucursalID,
                    GrupoID = grupoID,
                    MateriaID = materiaID,
                    FuncionarioID = funcionarioID,
                    MesAsociado = mes,
                    AnioAsociado = anio,
                    Precio = precio,
                    FechaHora = fechaHora
                };
                Estudiante estudiante = new Estudiante
                {
                    ID = estudianteID
                };
                mensualidad.Estudiante = estudiante;
                Mensualidad.ValidarMensualidadModificar(mensualidad);
                bool res = await CApi.ModificarMensualidad(mensualidad);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarMensualidad(int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new ValidacionException("Debe asignar ID a la mensualidad");
                }
                Mensualidad mensualidad = new Mensualidad
                {
                    ID = id
                };
                bool res = await CApi.EliminarMensualidad(mensualidad);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region VentaLibro


        public async Task<VentaLibro> GetVentaLibro(int id, int libroId, int materiaId, int estudianteId)
        {
            try
            {
                if (id < 1 || libroId < 1 || materiaId < 1)
                {
                    throw new ValidacionException("Debe asignar ID y un libro");
                }
                if (estudianteId < 1)
                {
                    throw new ValidacionException("Debe asignar un estudiante");
                }
                VentaLibro venta = new VentaLibro
                {
                    ID = id
                };
                Materia materia = new Materia
                {
                    ID = materiaId
                };
                Libro libro = new Libro
                {
                    ID = libroId,
                    Materia = materia
                };
                Estudiante estudiante = new Estudiante
                {
                    ID = estudianteId
                };
                venta.Libro = libro;
                venta.Estudiante = estudiante;
                venta = await CApi.GetVentaLibro(venta);
                return venta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<VentaLibro>> GetListaVentaLibro()
        {
            try
            {
                return await CApi.GetListaVentaLibro();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<VentaLibro> CrearVentaLibro(int libroId, int materiaId, int estudianteId, decimal precio, VentaLibroEstado estado)
        {
            try
            {
                VentaLibro venta = new VentaLibro
                {
                    ID = 0,
                    FechaHora = DateTime.Now,
                    Precio = precio,
                    Estado = estado
                };
                Materia materia = new Materia
                {
                    ID = materiaId
                };
                Libro libro = new Libro
                {
                    ID = libroId,
                    Materia = materia
                };
                Estudiante estudiante = new Estudiante
                {
                    ID = estudianteId
                };
                venta.Libro = libro;
                venta.Estudiante = estudiante;
                VentaLibro.ValidarVentaLibroInsert(venta);
                venta = await CApi.CrearVentaLibro(venta);
                return venta;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarVentaLibro(int id, int libroId, int materiaId, int estudianteId, decimal precio, VentaLibroEstado estado, DateTime fechaHora)
        {
            try
            {
                VentaLibro venta = new VentaLibro
                {
                    ID = id,
                    FechaHora = fechaHora,
                    Precio = precio,
                    Estado = estado
                };
                Materia materia = new Materia
                {
                    ID = materiaId
                };
                Libro libro = new Libro
                {
                    ID = libroId,
                    Materia = materia
                };
                Estudiante estudiante = new Estudiante
                {
                    ID = estudianteId
                };
                venta.Libro = libro;
                venta.Estudiante = estudiante;
                VentaLibro.ValidarVentaLibroModificar(venta);
                bool res = await CApi.ModificarVentaLibro(venta);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarVentaLibro(int id, int libroId, int materiaId, int estudianteId)
        {
            try
            {
                if (id < 1 || libroId < 1 || materiaId < 1)
                {
                    throw new ValidacionException("Debe asignar ID y un libro");
                }
                if (estudianteId < 1)
                {
                    throw new ValidacionException("Debe asignar un estudiante");
                }
                VentaLibro venta = new VentaLibro
                {
                    ID = id
                };
                Materia materia = new Materia
                {
                    ID = materiaId
                };
                Libro libro = new Libro
                {
                    ID = libroId,
                    Materia = materia
                };
                Estudiante estudiante = new Estudiante
                {
                    ID = estudianteId
                };
                venta.Libro = libro;
                venta.Estudiante = estudiante;
                bool res = await CApi.EliminarVentaLibro(venta);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region ExamenEstudiante


        public async Task<ExamenEstudiante> GetExamenEstudiante(int id, int examenID, int grupoID, int estudianteID)
        {
            try
            {
                if (id < 1 || examenID < 1 || grupoID < 1)
                {
                    throw new ValidacionException("Debe asignar ID y un examen");
                }
                if (estudianteID < 1)
                {
                    throw new ValidacionException("Debe asignar un estudiante");
                }
                ExamenEstudiante examenEstudiante = new ExamenEstudiante
                {
                    ID = id
                };
                examenEstudiante.Examen = new Examen
                {
                    ID = examenID,
                    GrupoID = grupoID
                };
                examenEstudiante.Estudiante = new Estudiante
                {
                    ID = estudianteID
                };
                examenEstudiante = await CApi.GetExamenEstudiante(examenEstudiante);
                return examenEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ExamenEstudiante>> GetListaExamenEstudiante()
        {
            try
            {
                return await CApi.GetListaExamenEstudiante();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ExamenEstudiante> CrearExamenEstudiante(int examenID, int grupoID, int estudianteID, int notaFinal, string notaFinalLetra, bool aprobado,
            int cantCuotas, FormaPago formaPago, bool pago, decimal precio, int funcionarioID, List<ExamenEstudianteCuota> lstCuotas)
        {
            try
            {
                ExamenEstudiante examenEstudiante = new ExamenEstudiante
                {
                    ID = 0,
                    FechaInscripcion = DateTime.Now,
                    NotaFinal = notaFinal,
                    NotaFinalLetra = notaFinalLetra,
                    Aprobado = aprobado,
                    CantCuotas = cantCuotas,
                    FormaPago = formaPago,
                    Pago = pago,
                    Precio = precio,
                    FuncionarioID = funcionarioID,
                    LstCuotas = lstCuotas
                };
                examenEstudiante.Examen = new Examen
                {
                    ID = examenID,
                    GrupoID = grupoID
                };
                examenEstudiante.Estudiante = new Estudiante
                {
                    ID = estudianteID
                };
                ExamenEstudiante.ValidarExamenEstudianteInsert(examenEstudiante);
                examenEstudiante = await CApi.CrearExamenEstudiante(examenEstudiante);
                return examenEstudiante;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarExamenEstudiante(int id, int examenID, int grupoID, int estudianteID, int notaFinal, string notaFinalLetra, bool aprobado,
            int cantCuotas, FormaPago formaPago, bool pago, decimal precio, int funcionarioID, DateTime fechaInsripcion, List<ExamenEstudianteCuota> lstCuotas)
        {
            try
            {
                ExamenEstudiante examenEstudiante = new ExamenEstudiante
                {
                    ID = 0,
                    FechaInscripcion = fechaInsripcion,
                    NotaFinal = notaFinal,
                    NotaFinalLetra = notaFinalLetra,
                    Aprobado = aprobado,
                    CantCuotas = cantCuotas,
                    FormaPago = formaPago,
                    Pago = pago,
                    Precio = precio,
                    FuncionarioID = funcionarioID,
                    LstCuotas = lstCuotas
                };
                examenEstudiante.Examen = new Examen
                {
                    ID = examenID,
                    GrupoID = grupoID
                };
                examenEstudiante.Estudiante = new Estudiante
                {
                    ID = estudianteID
                };
                ExamenEstudiante.ValidarExamenEstudianteModificar(examenEstudiante);
                bool res = await CApi.ModificarExamenEstudiante(examenEstudiante);
                return res;
            }
            catch (ValidacionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarExamenEstudiante(int id, int examenID, int grupoID, int estudianteID)
        {
            try
            {
                if (id < 1 || examenID < 1 || grupoID < 1)
                {
                    throw new ValidacionException("Debe asignar ID y un examen");
                }
                if (estudianteID < 1)
                {
                    throw new ValidacionException("Debe asignar un estudiante");
                }
                ExamenEstudiante examenEstudiante = new ExamenEstudiante
                {
                    ID = id
                };
                examenEstudiante.Examen = new Examen
                {
                    ID = examenID,
                    GrupoID = grupoID
                };
                examenEstudiante.Estudiante = new Estudiante
                {
                    ID = estudianteID
                };
                bool res = await CApi.EliminarExamenEstudiante(examenEstudiante);
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
            return CApi.GetEstudiantesTotal();
        }

        public List<Libro> GetLibrosTotal()
        {
            return CApi.GetLibrosTotal();
        }

        internal void SetResolucion(Size tamano)
        {
            this.Tamano = tamano;
        }

        internal List<Convenio> GetConveniosTotal()
        {
            return CApi.GetConveniosTotal();
        }


        public List<Pago> GetPagosTotal()
        {
            return CApi.GetPagosTotal();
        }

        public List<Sucursal> GetSucursalesTotal()
        {
            return CApi.GetSucursalesTotal();
        }


        internal List<Examen> GetExamenesTotal()
        {
            return CApi.GetExamenesTotal();
        }

        internal List<Grupo> GetGruposTotalb()
        {
            return CApi.GetGruposTotalb();
        }

        internal List<Funcionario> GetFuncionariosTotal()
        {
            return CApi.GetFuncionariosTotal();
        }

        public List<Estudiante> GetEstudiantesPorGrupo(Grupo g)
        {
            return CApi.GetEstudiantesPorGrupo(g);
        }

        internal List<Estudiante> GetEstudiantesPorNombre(string texto)
        {
            return CApi.GetEstudiantesPorNombre(texto);
        }

        internal List<Estudiante> GetEstudiantesPorCedula(string cedula)
        {
            return CApi.GetEstudiantesPorCedula(cedula);
        }

        internal List<Funcionario> GetFuncionariosActivos()
        {
            return CApi.GetFuncionariosActivos();
        }

        internal List<Funcionario> GetFuncionariosNoActivos()
        {
            return CApi.GetFuncionariosNoActivos();
        }



        internal List<Pago> GetPagosPorFiltro(string concepto, Sucursal suc, decimal minimo, decimal maximo, DateTime fechaInicial, DateTime fechaFinal)
        {
            return CApi.GetPagosPorFiltros(concepto, suc, minimo, maximo, fechaInicial, fechaFinal, null);
        }

        internal List<Grupo> GetGruposPorNombre(string text)
        {
            try
            {
                return CApi.GetGruposPorNombre(text);
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
                return CApi.AltaEstudiante(nombre, CI, telefono, esAlergico, alergias, contactoUno, contactoUnoTel, contactoDos, contactoDosTel, direccion, correo, fechaNac, convenio, sino);
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
                return CApi.AltaLibro(titulo, materia, precio, autor, editorial);
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
                return CApi.ModificarEstudiante(ID, nombre, CI, telefono, esAlergico, alergias, contactoUno, contactoUnoTel, contactoDos, contactoDosTel, direccion, correo, fechaNac, convenio, sino);
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
                return CApi.ModificarLibro(ID, titulo, materia, precio, autor, editorial);
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
                return CApi.AltaGrupo(listaDias, sucursal, funcionario, horaInicio, horaFin, materia, activo, precio);
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
                return CApi.ModificarGrupo(ID, listaDias, sucursal, funcionario, horaInicio, horaFin, materia, activo, precio);
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
                return CApi.EliminarGrupo(ID);
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
                return CApi.EliminarLibro(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
