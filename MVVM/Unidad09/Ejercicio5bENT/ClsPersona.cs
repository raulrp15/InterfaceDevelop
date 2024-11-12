namespace Ejercicio5bENT
{
    public class ClsPersona
    {
        #region Atributos
        private string nombre = "";
        private string apellidos = "";
        private DateTime fecha_nac;
        private string url_foto = "";
        private string direccion = "";
        private string telefono = "";
        #endregion

        #region Propiedades
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellidos { get { return apellidos; } set { apellidos = value; } }
        public string Telefono { get { return telefono; } set { telefono = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public DateTime Fecha_nac { get { return fecha_nac; } set { fecha_nac = value; } }
        public string Url_foto { get { return url_foto; } set { url_foto = value; } }
        #endregion
    }
}
