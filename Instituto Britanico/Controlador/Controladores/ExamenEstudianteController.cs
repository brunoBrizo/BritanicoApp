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
    class ExamenEstudianteController
    {
        private static string Url { get; set; } = ConfigurationManager.AppSettings["UrlApi"].ToString() + "examenestudiante";

        public static async Task<ExamenEstudiante> Get(ExamenEstudiante pExamenEstudiante)
        {
            string url = $"{ ExamenEstudianteController.Url }/getbyid/{ pExamenEstudiante.ID },{ pExamenEstudiante.Examen.ID },{ pExamenEstudiante.Examen.Grupo.ID },{ pExamenEstudiante.Estudiante.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ExamenEstudiante examen = await response.Content.ReadAsAsync<ExamenEstudiante>();
                    return examen;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar examen del estudiante | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<List<ExamenEstudiante>> GetAll()
        {
            string url = $"{ ExamenEstudianteController.Url }/getall";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<ExamenEstudiante> lstExamenEstudiante = await response.Content.ReadAsAsync<List<ExamenEstudiante>>();
                    return lstExamenEstudiante;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar examenes de estudiantes | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<ExamenEstudiante> Crear(ExamenEstudiante pExamenEstudiante)
        {
            string url = $"{ ExamenEstudianteController.Url }/crear";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, pExamenEstudiante))
            {
                if (response.IsSuccessStatusCode)
                {
                    ExamenEstudiante examen = await response.Content.ReadAsAsync<ExamenEstudiante>();
                    return examen;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Crear examen del estudiante | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<bool> Modificar(ExamenEstudiante pExamenEstudiante)
        {
            string url = $"{ ExamenEstudianteController.Url }/modificar";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, pExamenEstudiante))
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
                            throw new Exception("Modificar examen del estudiante | No se encuentra la Url: " + url);
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

        public static async Task<bool> Eliminar(ExamenEstudiante pExamenEstudiante)
        {
            string url = $"{ ExamenEstudianteController.Url }/eliminar/{ pExamenEstudiante.ID },{ pExamenEstudiante.Examen.ID },{ pExamenEstudiante.Examen.Grupo.ID },{ pExamenEstudiante.Estudiante.ID }";
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
                            throw new Exception("Eliminar examen del estudiante | No se encuentra la Url: " + url);
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
