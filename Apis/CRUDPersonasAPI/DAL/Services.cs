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

    }
}
