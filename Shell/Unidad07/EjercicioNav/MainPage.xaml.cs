using EjercicioTagged.Views;

namespace EjercicioNav
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Funcion que al pulsar el boton pasa a la pagina PaginaTabbed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_PasaTabbed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaTabbed());
        }
    }

}
