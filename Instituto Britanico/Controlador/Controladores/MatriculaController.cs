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
    public class MatriculaController
    {
        private static string Url { get; set; } = ConfigurationManager.AppSettings["UrlApi"].ToString() + "matricula";

        public static async Task<Matricula> Get(Matricula pMatricula)
        {
            string url = $"{ MatriculaController.Url }/getbyid/{ pMatricula.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Matricula matricula = await response.Content.ReadAsAsync<Matricula>();
                    return matricula;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar matricula | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<List<Matricula>> GetAll()
        {
            string url = $"{ MatriculaController.Url }/getall";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Matricula> lstMatriculas = await response.Content.ReadAsAsync<List<Matricula>>();
                    return lstMatriculas;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar matriculas | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<Matricula> Crear(Matricula pMatricula)
        {
            string url = $"{ MatriculaController.Url }/crear";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, pMatricula))
            {
                if (response.IsSuccessStatusCode)
                {
                    Matricula matricula = await response.Content.ReadAsAsync<Matricula>();
                    return matricula;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Crear matricula | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<bool> Modificar(Matricula pMatricula)
        {
            string url = $"{ MatriculaController.Url }/modificar";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, pMatricula))
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
                            throw new Exception("Modificar matricula | No se encuentra la Url: " + url);
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

        public static async Task<bool> Eliminar(Matricula pMatricula)
        {
            string url = $"{ MatriculaController.Url }/eliminar/{ pMatricula.ID }";
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
                            throw new Exception("Eliminar matricula | No se encuentra la Url: " + url);
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
