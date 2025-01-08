namespace ENT
{
    public class clsCandidato
    {
        private int id;
        private string nombre;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }

        public clsCandidato(int id, string nombre) 
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
