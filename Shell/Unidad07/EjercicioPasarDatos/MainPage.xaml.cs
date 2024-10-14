using BibliotecaDeClases;
using EjercicioPasarDatos.Views;

namespace EjercicioPasarDatos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Funcion que al pulsar el boton navega a la pagina PaginaTabbed
        /// y crea un objeto Persona que le añade el nombre y los apellidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_PasaTabbed(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PaginaTabbed());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Pasa4(object sender, EventArgs e)
        {
            var persona = new ClsPersona
            {
                Nombre = enName.Text,
                Apellidos = enSurnames.Text
            };
            await Navigation.PushAsync(new Pagina4(persona));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Pasa5(object sender, EventArgs e)
        {
            var persona = new ClsPersona
            {
                Nombre = enName.Text,
                Apellidos = enSurnames.Text
            };
            await Navigation.PushAsync(new Pagina5()
            {
                BindingContext = persona
            });
        }
    }

}
