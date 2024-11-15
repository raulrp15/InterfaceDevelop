using CapaDAL;
using CapaENT;

namespace CapaBL
{
    public class ClsListadoBL
    {
        /// <summary>
        /// Funcion que devuelve una lista de personas
        /// </summary>
        /// <returns>Lista de personas</returns>
        public static List<ClsPersona> GetListadoPersonaBL()
        {
            List<ClsPersona> lista = null;
            try
            {
                lista = ClsListadoDAL.GetListadoPersonasDAL();
            }
            catch (Exception ex)
            {
                //TODO Enviar mensaje de error
            }
            return lista;
        }

        /// <summary>
        /// Funcion que devuelve una lista filtrada por la busqueda
        /// </summary>
        /// <param name="busqueda">Cadena con la busqueda realizada</param>
        /// <returns>Lista de personas filtradras</returns>
        public static List<ClsPersona> GetListadoPersonasBusquedaBL(string busqueda)
        {
            return ClsListadoDAL.GetListadoPersonasBusquedaDAL(busqueda);
        }
    }
}
