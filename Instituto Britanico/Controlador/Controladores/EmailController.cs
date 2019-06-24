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
    public class EmailController
    {
        private static string Url { get; set; } = ConfigurationManager.AppSettings["UrlApi"].ToString() + "email";

        public static async Task<Email> Get(Email pEmail)
        {
            string url = $"{ EmailController.Url }/getbyid/{ pEmail.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Email email = await response.Content.ReadAsAsync<Email>();
                    return email;
                }
                else
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
        }

        public static async Task<List<Email>> GetAll()
        {
            string url = $"{ EmailController.Url }/getall";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Email> lstEmails = await response.Content.ReadAsAsync<List<Email>>();
                    return lstEmails;
                }
                else
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
        }

        public static async Task<List<Email>> GetEntreFechas(DateTime desde, DateTime hasta)
        {
            string url = $"{ EmailController.Url }/getentrefechas/{ desde },{ hasta }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Email> lstEmails = await response.Content.ReadAsAsync<List<Email>>();
                    return lstEmails;
                }
                else
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
        }

        public static async Task<Email> Crear(Email pEmail)
        {
            string url = $"{ EmailController.Url }/crear";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, pEmail))
            {
                if (response.IsSuccessStatusCode)
                {
                    Email email = await response.Content.ReadAsAsync<Email>();
                    return email;
                }
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
        }

        public static async Task<bool> EnviarPendientes()
        {
            string url = $"{ EmailController.Url }/enviarpendientes";
            var httpContent = new StringContent("");
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, httpContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
        }

        public static async Task<bool> Modificar(Email pEmail)
        {
            string url = $"{ EmailController.Url }/modificar";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, pEmail))
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

        public static async Task<bool> Eliminar(Email pEmail)
        {
            string url = $"{ EmailController.Url }/eliminar/{ pEmail.ID }";
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
