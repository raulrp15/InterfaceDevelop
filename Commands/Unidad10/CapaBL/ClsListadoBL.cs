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
        /// 
        /// </summary>
        /// <param name="busqueda"></param>
        /// <returns></returns>
        public static List<ClsPersona> GetListadoPersonasBusquedaBL(string busqueda)
        {
            return ClsListadoDAL.GetListadoPersonasBusquedaDAL(busqueda);
        }
    }
}
