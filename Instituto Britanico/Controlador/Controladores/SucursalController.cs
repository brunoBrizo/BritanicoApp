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
    class SucursalController
    {
        private static string Url { get; set; } = ConfigurationManager.AppSettings["UrlApi"].ToString() + "sucursal";

        public static async Task<Sucursal> Get(Sucursal pSucursal)
        {
            string url = $"{ SucursalController.Url }/getbyid/{ pSucursal.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Sucursal sucursal = await response.Content.ReadAsAsync<Sucursal>();
                    return sucursal;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar sucursal | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<List<Sucursal>> GetAll()
        {
            string url = $"{ SucursalController.Url }/getall";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Sucursal> lstSucursales = await response.Content.ReadAsAsync<List<Sucursal>>();
                    return lstSucursales;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar sucursales | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<Sucursal> Crear(Sucursal pSucursal)
        {
            string url = $"{ SucursalController.Url }/crear";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, pSucursal))
            {
                if (response.IsSuccessStatusCode)
                {
                    Sucursal sucursal = await response.Content.ReadAsAsync<Sucursal>();
                    return sucursal;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Crear sucursal | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<bool> Modificar(Sucursal pSucursal)
        {
            string url = $"{ SucursalController.Url }/modificar";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, pSucursal))
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
                            throw new Exception("Modificar sucursal | No se encuentra la Url: " + url);
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

        public static async Task<bool> Eliminar(Sucursal pSucursal)
        {
            string url = $"{ SucursalController.Url }/eliminar/{ pSucursal.ID }";
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
                            throw new Exception("Eliminar sucursal | No se encuentra la Url: " + url);
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
