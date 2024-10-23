namespace Ejercicio05
{
    public partial class MainPage : ContentPage
    {
        List<ClsPersona> personas = new();
        public MainPage()
        {
            InitializeComponent();
            personas = ClsListado.getListadoPersonas();
            lvPersona.ItemsSource = personas;
        }
    }

}
