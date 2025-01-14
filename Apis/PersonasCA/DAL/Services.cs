using ENT;
using Newtonsoft.Json;

namespace DAL
{
    public class Services
    {
        /// <summary>
        /// Funcion asincrona que un listado de todas las personas de la api de azure
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Devuelve un listado de todas las personas de la base de datos</returns>
        public static async Task<List<clsPersona>> getPersonas()
        {
            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri(miCadenaUrl);

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            HttpClient mihttpClient;

            HttpResponseMessage miCodigoRespuesta;

            string textoJsonRespuesta;

            mihttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    var response = JsonConvert.DeserializeObject<List<clsPersona>>(textoJsonRespuesta);
                    listadoPersonas = response.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listadoPersonas;
        }

        /// <summary>
        /// Funcion asincrona que devuelve de la api una persona por su ID
        /// </summary>
        /// <param name="id">ID de la persona seleccionada</param>
        /// <returns>Persona con datos</returns>
        public static async Task<clsPersona> getPersonaPorID(int id)
        {
            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}/{id}");

            clsPersona persona = null;

            HttpClient mihttpClient;

            HttpResponseMessage miCodigoRespuesta;

            string textoJsonRespuesta;

            mihttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    var response = JsonConvert.DeserializeObject<clsPersona>(textoJsonRespuesta);
                    persona = response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return persona;
        }

        public static async Task<System.Net.HttpStatusCode> insertPersona(clsPersona persona)
        {
            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}");


            HttpClient mihttpClient;

            HttpContent content;

            HttpResponseMessage miCodigoRespuesta = new HttpResponseMessage();

            string textoJsonRespuesta;

            mihttpClient = new HttpClient();
            try
            {
                var response = JsonConvert.SerializeObject(persona);
                content = new StringContent(response, System.Text.Encoding.UTF8, "application/json");
                miCodigoRespuesta = await mihttpClient.PostAsync(miUri, content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miCodigoRespuesta.StatusCode;
        }
    }
}

