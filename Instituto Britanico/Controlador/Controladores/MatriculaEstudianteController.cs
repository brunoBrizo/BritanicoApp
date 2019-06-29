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
    public class MatriculaEstudianteController
    {
        private static string Url { get; set; } = ConfigurationManager.AppSettings["UrlApi"].ToString() + "matriculaestudiante";

        public static async Task<MatriculaEstudiante> Get(MatriculaEstudiante pMatriculaEstudiante)
        {
            string url = $"{ MatriculaEstudianteController.Url }/getbyid/{ pMatriculaEstudiante.ID },{ pMatriculaEstudiante.Matricula.ID },{ pMatriculaEstudiante.Estudiante.ID },{ pMatriculaEstudiante.Grupo.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    MatriculaEstudiante matricula = await response.Content.ReadAsAsync<MatriculaEstudiante>();
                    return matricula;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar matricula del estudiante | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<List<MatriculaEstudiante>> GetAll()
        {
            string url = $"{ MatriculaEstudianteController.Url }/getall";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<MatriculaEstudiante> lstMatriculaEstudiante = await response.Content.ReadAsAsync<List<MatriculaEstudiante>>();
                    return lstMatriculaEstudiante;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Buscar matriculas del estudiante | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<MatriculaEstudiante> Crear(MatriculaEstudiante pMatriculaEstudiante)
        {
            string url = $"{ MatriculaEstudianteController.Url }/crear";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, pMatriculaEstudiante))
            {
                if (response.IsSuccessStatusCode)
                {
                    MatriculaEstudiante matricula = await response.Content.ReadAsAsync<MatriculaEstudiante>();
                    return matricula;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Crear matricula del estudiante | No se encuentra la Url: " + url);
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        error = Herramientas.QuitarComillasDobles(error);
                        throw new Exception(error);
                    }
                }
            }
        }

        public static async Task<bool> Modificar(MatriculaEstudiante pMatriculaEstudiante)
        {
            string url = $"{ MatriculaEstudianteController.Url }/modificar";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, pMatriculaEstudiante))
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
                            throw new Exception("Modificar matricula del estudiante | No se encuentra la Url: " + url);
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

        public static async Task<bool> Eliminar(MatriculaEstudiante pMatriculaEstudiante)
        {
            string url = $"{ MatriculaEstudianteController.Url }/eliminar/{ pMatriculaEstudiante.ID },{ pMatriculaEstudiante.Matricula.ID },{ pMatriculaEstudiante.Estudiante.ID },{ pMatriculaEstudiante.Grupo.ID }";
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
                            throw new Exception("Eliminar matricula del estudiante | No se encuentra la Url: " + url);
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
