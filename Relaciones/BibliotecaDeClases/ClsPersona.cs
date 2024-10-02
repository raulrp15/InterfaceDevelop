namespace BibliotecaDeClases
{
    public class ClsPersona
    {
        #region Atributo
        private string nombre;
        private int edad;
        private DateOnly fecha;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public DateOnly Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        #endregion

        #region Constructores
        public ClsPersona(string nombre)
        {
            Nombre = nombre;
        }

        public ClsPersona()
        {

        }
        #endregion
    }
}
