using BibliotecaBritanico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;

namespace Instituto_Britanico.Controlador
{
    public class MateriaController
    {
        private static string Url { get; set; } = ConfigurationManager.AppSettings["UrlApi"].ToString() + "materia";
        public static async Task<Materia> Get(Materia pMateria)
        {
            string url = $"{ MateriaController.Url }/getbyid/{ pMateria.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Materia materia = await response.Content.ReadAsAsync<Materia>();
                    materia.Sucursal = new Sucursal();
                    materia.Sucursal.ID = materia.SucursalID;
                    return materia;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<Materia>> GetAll()
        {
            string url = $"{ MateriaController.Url }/getall";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Materia> lstMaterias = await response.Content.ReadAsAsync<List<Materia>>();
                    foreach (Materia materia in lstMaterias)
                    {
                        materia.Sucursal = new Sucursal();
                        materia.Sucursal.ID = materia.SucursalID;
                    }
                    return lstMaterias;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<Materia> Crear(Materia pMateria)
        {
            string url = $"{ MateriaController.Url }/crear";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, pMateria))
            {
                if (response.IsSuccessStatusCode)
                {
                    Materia materia = await response.Content.ReadAsAsync<Materia>();
                    materia.Sucursal = new Sucursal();
                    materia.Sucursal.ID = materia.SucursalID;
                    return materia;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<bool> Modificar(Materia pMateria)
        {
            string url = $"{ MateriaController.Url }/modificar";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, pMateria))
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
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
        }

        public static async Task<bool> Eliminar(Materia pMateria)
        {
            string url = $"{ MateriaController.Url }/eliminar/{ pMateria.ID }";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
