using BibliotecaBritanico.Utilidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Instituto_Britanico.Controlador.Controladores
{
    public class ParametroController
    {
        private static string Url { get; set; } = ConfigurationManager.AppSettings["UrlApi"].ToString() + "parametro";

        public static async Task<Parametro> Get(Parametro pParametro)
        {
            string url = $"{ ParametroController.Url }/getbyid/{ pParametro.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Parametro parametro = await response.Content.ReadAsAsync<Parametro>();
                    return parametro;
                }
                else
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
        }

        public static async Task<List<Parametro>> GetAll()
        {
            string url = $"{ ParametroController.Url }/getall";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Parametro> lstParametros = await response.Content.ReadAsAsync<List<Parametro>>();
                    return lstParametros;
                }
                else
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
        }

        public static async Task<Parametro> Crear(Parametro pParametro)
        {
            string url = $"{ ParametroController.Url }/crear";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, pParametro))
            {
                if (response.IsSuccessStatusCode)
                {
                    Parametro materia = await response.Content.ReadAsAsync<Parametro>();
                    return materia;
                }
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
        }

        public static async Task<bool> Modificar(Parametro pParametro)
        {
            string url = $"{ ParametroController.Url }/modificar";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, pParametro))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    if (response.ReasonPhrase.Equals(String.Empty))
                    {
                        return false;
                    }
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<bool> Eliminar(Parametro pParametro)
        {
            string url = $"{ ParametroController.Url }/eliminar/{ pParametro.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    if (response.ReasonPhrase.Equals(String.Empty))
                    {
                        return false;
                    }
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(error);
                    }
                }
            }
        }

    }
}
