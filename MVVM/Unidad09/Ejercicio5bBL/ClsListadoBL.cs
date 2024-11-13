using Ejercicio5bDAL;
using Ejercicio5bENT;

namespace Ejercicio5bBL
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
    }
}
