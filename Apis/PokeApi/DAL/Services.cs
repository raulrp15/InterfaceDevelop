using ENT;
using DTO;
using Newtonsoft.Json;

namespace DAL
{
    public class Services
    {
        /// <summary>
        /// Funcion asincrona que recoge una cierta cantidad de pokemons de la PokeApi
        /// Pre: Los valores del que empieza y la cantidad deben tener un valor numerico
        /// Post: Ninguna
        /// </summary>
        /// <param name="pokFirst">El numero del pokemon por el que quiere empezar la lista</param>
        /// <param name="pokLast">El numero de pokemons que quiere mostrar</param>
        /// <returns></returns>
        public static async Task<List<clsPokemon>> getPokemons(int pokFirst, int pokLast)
        {
            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}?limit={pokLast}&offset={pokFirst-1}");

            List<clsPokemon> listadoPokemons = new List<clsPokemon>();

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
                    var response = JsonConvert.DeserializeObject<clsApiResponse>(textoJsonRespuesta);

                    foreach (var item in response.Results)
                    {
                        listadoPokemons.Add(new clsPokemon
                        {
                            Nombre = char.ToUpper(item.Name[0]) + item.Name.Substring(1).ToLower(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listadoPokemons;
        }

    }
}
