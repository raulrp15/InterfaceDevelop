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
            ClsPersona p1 = new ClsPersona();
            p1.Nombre = "Raul";
            p1.Apellidos = "Romera Pavon";
            p1.Edad = 19;
            ClsPersona p2 = new ClsPersona();
            p2.Nombre = "Lorenzo";
            p2.Apellidos = "Bellido Barrena";
            p2.Edad = 19;
            ClsPersona p3 = new ClsPersona();
            p3.Nombre = "Marco";
            p3.Apellidos = "Holguín Cascajo";
            p3.Edad = 18;
            ClsPersona p4 = new ClsPersona();
            p4.Nombre = "Pablo";
            p4.Apellidos = "Carbonero Almellones";
            p4.Edad = 21;
            ClsPersona p5 = new ClsPersona();
            p5.Nombre = "Isaac";
            p5.Apellidos = "Romera Pavón";
            p5.Edad = 26;
            ClsPersona p6 = new ClsPersona();
            p6.Nombre = "Jose Maria";
            p6.Apellidos = "Romera Dominguez";
            p6.Edad = 53;
            ClsPersona p7 = new ClsPersona();
            p7.Nombre = "Pepelu";
            p7.Apellidos = "Calvorota Mejorada";
            p7.Edad = 42;
            ClsPersona p8 = new ClsPersona();
            p8.Nombre = "Hector";
            p8.Apellidos = "Arias Campanero";
            p8.Edad = 10;
            ClsPersona p9 = new ClsPersona();
            p9.Nombre = "Miguel";
            p9.Apellidos = "De Unamuno";
            p9.Edad = 1000;
            ClsPersona p10 = new ClsPersona();
            p10.Nombre = "Clara";
            p10.Apellidos = "Pavon Ortiz";
            p10.Edad = 53;

            var lista = new List<ClsPersona>();
            lista.Add(p1);
            lista.Add(p2);
            lista.Add(p3);
            lista.Add(p4);
            lista.Add(p5);
            lista.Add(p6);
            lista.Add(p7);
            lista.Add(p8);
            lista.Add(p9);
            lista.Add(p10);

            return lista;
        }
    }
}
