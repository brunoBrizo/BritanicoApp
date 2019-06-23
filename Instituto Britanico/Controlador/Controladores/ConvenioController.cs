using BibliotecaBritanico.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Instituto_Britanico.Controlador.Controladores
{
    public class ConvenioController
    {
        private static string Url { get; set; } = ConfigurationManager.AppSettings["UrlApi"].ToString() + "convenio";

        public static async Task<Convenio> Get(Convenio pConvenio)
        {
            string url = $"{ ConvenioController.Url }/getbyid/{ pConvenio.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Convenio convenio = await response.Content.ReadAsAsync<Convenio>();
                    return convenio;
                }
                else
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
        }

        public static async Task<List<Convenio>> GetAll()
        {
            string url = $"{ ConvenioController.Url }/getall";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Convenio> lstConvenios = await response.Content.ReadAsAsync<List<Convenio>>();
                    return lstConvenios;
                }
                else
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
        }

        public static async Task<Convenio> Crear(Convenio pConvenio)
        {
            string url = $"{ ConvenioController.Url }/crear";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, pConvenio))
            {
                if (response.IsSuccessStatusCode)
                {
                    Convenio convenio = await response.Content.ReadAsAsync<Convenio>();
                    return convenio;
                }
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
        }

        public static async Task<bool> Modificar(Convenio pConvenio)
        {
            string url = $"{ ConvenioController.Url }/modificar";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, pConvenio))
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

        public static async Task<bool> Eliminar(Convenio pConvenio)
        {
            string url = $"{ ConvenioController.Url }/eliminar/{ pConvenio.ID }";
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
