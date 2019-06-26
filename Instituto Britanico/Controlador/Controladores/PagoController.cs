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
    public class PagoController
    {
        private static string Url { get; set; } = ConfigurationManager.AppSettings["UrlApi"].ToString() + "pago";

        public static async Task<Pago> Get(Pago pPago)
        {
            string url = $"{ PagoController.Url }/getbyid/{ pPago.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Pago pago = await response.Content.ReadAsAsync<Pago>();
                    return pago;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar pago | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<List<Pago>> GetAll()
        {
            string url = $"{ PagoController.Url }/getall";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Pago> lstPagos = await response.Content.ReadAsAsync<List<Pago>>();
                    return lstPagos;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar pagos | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<Pago> Crear(Pago pPago)
        {
            string url = $"{ PagoController.Url }/crear";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, pPago))
            {
                if (response.IsSuccessStatusCode)
                {
                    Pago pago = await response.Content.ReadAsAsync<Pago>();
                    return pago;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Crear pago | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<bool> Modificar(Pago pPago)
        {
            string url = $"{ PagoController.Url }/modificar";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, pPago))
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
                            throw new Exception("Modificar pago | No se encuentra la Url: " + url);
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

        public static async Task<bool> Eliminar(Pago pPago)
        {
            string url = $"{ PagoController.Url }/eliminar/{ pPago.ID }";
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
                            throw new Exception("Eliminar pago | No se encuentra la Url: " + url);
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
