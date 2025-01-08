using ENT;
using Newtonsoft.Json;

namespace DAL
{
    public class Services
    {
        public async Task<List<clsPokemon>> getPokemons()
        {
            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}");

            List<clsPokemon> listadoPersonas = new List<clsPokemon>();

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
                    mihttpClient.Dispose();
                    listadoPersonas = JsonConvert.DeserializeObject<List<clsPokemon>>(textoJsonRespuesta);
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
