using Ejercicio5bDAL;
using Ejercicio5bENT;

namespace Ejercicio5bBL
{
    public class ClsListadoBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> GetListadoPersonaBL()
        {
            List<ClsPersona> lista = ClsListadoDAL.GetListadoPersonasDAL();

            return lista;
        }
    }
}
