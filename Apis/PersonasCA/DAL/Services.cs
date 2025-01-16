using ENT;
using Newtonsoft.Json;
using System.Net;

namespace DAL
{
    public class Services
    {
        #region Personas
        /// <summary>
        /// Funcion asincrona que un listado de todas las personas de la api de azure
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Devuelve un listado de todas las personas de la base de datos</returns>
        public static async Task<List<clsPersona>> getPersonas()
        {
            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}PersonaApi");

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

            Uri miUri = new Uri($"{miCadenaUrl}PersonaApi/{id}");

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

        /// <summary>
        /// Funcion asincrona que inserta una persona en la base de datos mediante la api
        /// Pre: Todos los campos de la persona deben estar bien formados
        /// Post: Ninguna
        /// </summary>
        /// <param name="persona">Persona para insertar en la BD</param>
        /// <returns>Devuelve una respuesta de codigo de estado</returns>
        public static async Task<HttpStatusCode> insertPersona(clsPersona persona)
        {
            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}PersonaApi");

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

        /// <summary>
        /// Funcion asincrona que inserta una persona en la base de datos mediante la api
        /// Pre: Todos los campos de la persona deben estar bien formados
        /// Post: Ninguna
        /// </summary>
        /// <param name="persona">Persona para insertar en la BD</param>
        /// <returns>Devuelve una respuesta de codigo de estado</returns>
        public static async Task<HttpStatusCode> updatePersona(clsPersona persona)
        {
            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}PersonaApi/{persona.Id}");

            HttpClient mihttpClient;

            HttpContent content;

            HttpResponseMessage miCodigoRespuesta = new HttpResponseMessage();

            string textoJsonRespuesta;

            mihttpClient = new HttpClient();
            try
            {
                var response = JsonConvert.SerializeObject(persona);
                content = new StringContent(response, System.Text.Encoding.UTF8, "application/json");
                miCodigoRespuesta = await mihttpClient.PutAsync(miUri, content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miCodigoRespuesta.StatusCode;
        }

        /// <summary>
        /// Funcion asincrona que elimina a una persona de la API
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <param name="id">Id de la persona</param>
        /// <returns>Devuelve una respuesta de codigo de estado</returns>
        public static async Task<HttpStatusCode> EliminarPersona(int id)
        {
            HttpClient mihttpClient = new HttpClient();

            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}PersonaApi/{id}");

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {
                miRespuesta = await mihttpClient.DeleteAsync(miUri);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miRespuesta.StatusCode;

        }
        #endregion

        #region Departamentos

        /// <summary>
        /// Funcion asincrona que recoge todos los departamentos de la API
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Devuelve una lista de departamentos</returns>
        public static async Task<List<clsDepartamento>> getDepartamentos()
        {
            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}DepartamentoApi");

            List<clsDepartamento> listadoDepts = new();

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
                    var response = JsonConvert.DeserializeObject<List<clsDepartamento>>(textoJsonRespuesta);
                    listadoDepts = response.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listadoDepts;
        }

        /// <summary>
        /// Funcion asincrona que recoge un departamento de la API mediante su ID
        /// Pre: El departamento debe existir en la BD
        /// Post: Ninguna
        /// </summary>
        /// <param name="id">Identificador del departamento</param>
        /// <returns>Devuelve un departamento de la BD</returns>
        public static async Task<clsDepartamento> getDepartamentoID(int id)
        {
            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}DepartamentoApi/{id}");

            clsDepartamento dept = null;

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
                    var response = JsonConvert.DeserializeObject<clsDepartamento>(textoJsonRespuesta);
                    dept = response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dept;
        }
        #endregion
    }
}

