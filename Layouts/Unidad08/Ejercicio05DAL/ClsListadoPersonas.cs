using Ejercicio05ENT;

namespace Ejercicio05DAL
{
    public class ClsListadoPersonas
    {
        /// <summary>
        /// Funcion que devuelve un listado de todas personas de nuestra BBDD
        /// </summary>
        /// <returns>Lista de personas</returns>
        static public List<ClsPersona> getListadoCompletoPersonas()
        {
            List<ClsPersona> lista = new List<ClsPersona> 
            {
                new ClsPersona{Nombre = "Raul", Apellidos = "Romera Pavon", Edad = 19 },
                new ClsPersona{Nombre = "Lorenzo", Apellidos = "Bellido Barrena", Edad = 19 },
                new ClsPersona{Nombre = "Marco", Apellidos = "Holguín Cascajo", Edad = 18 },
                new ClsPersona{Nombre = "Pablo", Apellidos = "Carbonero Almellones", Edad = 21 },
                new ClsPersona{Nombre = "Isaac", Apellidos = "Romera Pavón", Edad = 26 },
                new ClsPersona{Nombre = "Jose Maria", Apellidos = "Romera Dominguez", Edad = 53 },
                new ClsPersona{Nombre = "Hector", Apellidos = "Arias Campanero", Edad = 10 },
                new ClsPersona{Nombre = "Pepelu", Apellidos = "Calvorota Mejorada", Edad = 39 },
                new ClsPersona{Nombre = "Miguel", Apellidos = "De Unamuno", Edad = 100 },
                new ClsPersona{Nombre = "Clara", Apellidos = "Pavon Ortiz", Edad = 53 },
                new ClsPersona{Nombre = "Raul", Apellidos = "Romera Pavon", Edad = 19 },
                new ClsPersona{Nombre = "Lorenzo", Apellidos = "Bellido Barrena", Edad = 19 },
                new ClsPersona{Nombre = "Marco", Apellidos = "Holguín Cascajo", Edad = 18 },
                new ClsPersona{Nombre = "Pablo", Apellidos = "Carbonero Almellones", Edad = 21 },
                new ClsPersona{Nombre = "Isaac", Apellidos = "Romera Pavón", Edad = 26 },
                new ClsPersona{Nombre = "Jose Maria", Apellidos = "Romera Dominguez", Edad = 53 },
                new ClsPersona{Nombre = "Hector", Apellidos = "Arias Campanero", Edad = 10 },
                new ClsPersona{Nombre = "Pepelu", Apellidos = "Calvorota Mejorada", Edad = 39 },
                new ClsPersona{Nombre = "Miguel", Apellidos = "De Unamuno", Edad = 100 },
                new ClsPersona{Nombre = "Clara", Apellidos = "Pavon Ortiz", Edad = 53 },
                new ClsPersona{Nombre = "Raul", Apellidos = "Romera Pavon", Edad = 19 },
                new ClsPersona{Nombre = "Lorenzo", Apellidos = "Bellido Barrena", Edad = 19 },
                new ClsPersona{Nombre = "Marco", Apellidos = "Holguín Cascajo", Edad = 18 },
                new ClsPersona{Nombre = "Pablo", Apellidos = "Carbonero Almellones", Edad = 21 },
                new ClsPersona{Nombre = "Isaac", Apellidos = "Romera Pavón", Edad = 26 },
                new ClsPersona{Nombre = "Jose Maria", Apellidos = "Romera Dominguez", Edad = 53 },
                new ClsPersona{Nombre = "Hector", Apellidos = "Arias Campanero", Edad = 10 },
                new ClsPersona{Nombre = "Pepelu", Apellidos = "Calvorota Mejorada", Edad = 39 },
                new ClsPersona{Nombre = "Miguel", Apellidos = "De Unamuno", Edad = 100 },
                new ClsPersona{Nombre = "Clara", Apellidos = "Pavon Ortiz", Edad = 53 },
            };

            return lista;
        }
    }
}
