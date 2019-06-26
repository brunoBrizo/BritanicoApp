using BibliotecaBritanico.Modelo;
using BibliotecaBritanico.Utilidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Instituto_Britanico.Controlador.Controladores
{
    public class EmpresaController
    {
        private static string Url { get; set; } = ConfigurationManager.AppSettings["UrlApi"].ToString() + "empresa";

        public static async Task<Empresa> Get(Empresa pEmpresa)
        {
            string url = $"{ EmpresaController.Url }/getbyid/{ pEmpresa.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Empresa empresa = await response.Content.ReadAsAsync<Empresa>();
                    return empresa;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar empresa | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<Empresa> GetByRut(Empresa pEmpresa)
        {
            string url = $"{ EmpresaController.Url }/getbyrut/{ pEmpresa.Rut }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Empresa empresa = await response.Content.ReadAsAsync<Empresa>();
                    return empresa;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar empresa | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<List<Empresa>> GetAll()
        {
            string url = $"{ EmpresaController.Url }/getall";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Empresa> lstEmpresas = await response.Content.ReadAsAsync<List<Empresa>>();
                    return lstEmpresas;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar empresas | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<Empresa> Crear(Empresa pEmpresa)
        {
            string url = $"{ EmpresaController.Url }/crear";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, pEmpresa))
            {
                if (response.IsSuccessStatusCode)
                {
                    Empresa empresa = await response.Content.ReadAsAsync<Empresa>();
                    return empresa;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Crear empresa | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<bool> Modificar(Empresa pEmpresa)
        {
            string url = $"{ EmpresaController.Url }/modificar";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, pEmpresa))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    if (response.ReasonPhrase.Equals(String.Empty) && response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        return false;
                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            throw new Exception("Modificar empresa | No se encuentra la Url: " + url);
                        else
                        {
                            string error = response.Content.ReadAsStringAsync().Result;
                            error = Herramientas.QuitarComillasDobles(error);
                            throw new Exception(error);
                        }
                    }
                }
            }
        }

        public static async Task<bool> Eliminar(Empresa pEmpresa)
        {
            string url = $"{ EmpresaController.Url }/eliminar/{ pEmpresa.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    if (response.ReasonPhrase.Equals(String.Empty) && response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        return false;
                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            throw new Exception("Eliminar empresa | No se encuentra la Url: " + url);
                        else
                        {
                            string error = response.Content.ReadAsStringAsync().Result;
                            error = Herramientas.QuitarComillasDobles(error);
                            throw new Exception(error);
                        }
                    }
                }
            }
        }

    }
}
