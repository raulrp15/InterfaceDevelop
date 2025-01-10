namespace ENT
{
    public class clsPokemon
    {
        #region Atributos
        private string name;
        #endregion
        #region Propiedades
        public string Name { get { return name; } set { name = char.ToUpper(value[0]) + value.Substring(1); } }

        #endregion
        #region Constructores
        public clsPokemon() { }
        #endregion
    }
}
