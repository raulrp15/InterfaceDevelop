using CapaENT;

namespace CapaDAL
{
    public class ClsListadoDAL
    {
        public static List<ClsPersona> Lista = new List<ClsPersona>
            {
                new ClsPersona{Nombre = "Roberto", Apellidos = "Sanchez Borrica", Direccion="Calle Matarile", Fecha_nac=DateTime.Parse("12/02/2001"), Telefono = "625987634", Url_foto="https://thispersondoesnotexist.com"},
                new ClsPersona{Nombre = "Miguel", Apellidos = "Nuñez Fernandez", Direccion="Calle Grosero", Fecha_nac=DateTime.Parse("12/02/2001"), Telefono = "612121212", Url_foto="https://thispersondoesnotexist.com"},
                new ClsPersona{Nombre = "Carlos", Apellidos = "Chueca Feliz", Direccion="Calle Poniente", Fecha_nac=DateTime.Parse("12/02/2001"), Telefono = "654738291", Url_foto="https://thispersondoesnotexist.com"},
                new ClsPersona{Nombre = "Marcos", Apellidos = "Pelon Cascarrilla", Direccion="Calle Ricachón", Fecha_nac=DateTime.Parse("12/02/2001"), Telefono = "642312945", Url_foto="https://thispersondoesnotexist.com"},
                new ClsPersona{Nombre = "Pablo", Apellidos = "Vieira Chile", Direccion="Calle Soychileno", Fecha_nac=DateTime.Parse("12/02/2001"), Telefono = "675231481", Url_foto="https://thispersondoesnotexist.com"},
                new ClsPersona{Nombre = "Diego", Apellidos = "Carrillo Martinez", Direccion="Calle Kim Hong", Fecha_nac=DateTime.Parse("12/02/2001"), Telefono = "615234123", Url_foto="https://thispersondoesnotexist.com"},
                new ClsPersona{Nombre = "Sergio", Apellidos = "Kilombo Arias", Direccion="Calle Barceló", Fecha_nac=DateTime.Parse("12/02/2001"), Telefono = "610293824", Url_foto="https://thispersondoesnotexist.com"},
            };
        /// <summary>
        /// Funcion que devuelve una lista de personas
        /// </summary>
        /// <returns>Lista de personas</returns>
        public static List<ClsPersona> GetListadoPersonasDAL()
        {
            List<ClsPersona> lista = null;
            try
            {
                lista = Lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return lista;
        }

        /// <summary>
        /// Funciones que devuelve una lista filtrada por la busqueda del usuario
        /// </summary>
        /// <param name="busqueda">Cadena con la busqueda realizada</param>
        /// <returns>Lista de personas filtradas por busqueda</returns>
        public static List<ClsPersona> GetListadoPersonasBusquedaDAL(string busqueda) 
        {
            List<ClsPersona> busquedaList = new List<ClsPersona>();
            foreach (ClsPersona persona in Lista)
            {
                if(persona.Nombre.Contains(busqueda) || persona.Apellidos.Contains(busqueda))
                {
                    busquedaList.Add(persona);
                }
            }
            return busquedaList;
        }
    }
}
