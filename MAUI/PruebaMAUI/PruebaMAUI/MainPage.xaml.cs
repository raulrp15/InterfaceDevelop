using BibliotecaDeClases;
using Microsoft.Maui.Controls.Platform;

namespace PruebaMAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funcion asociado al click del boton que muestra el mensaje en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
        private async void buttonClicked(object sender, EventArgs e)
        {
            ClsPersona persona = new ClsPersona();
            persona.Nombre = Nombre.Text;
            persona.Apellidos = await DisplayPromptAsync("", "Introduzca tus apellidos");
            

            if(!String.IsNullOrEmpty(persona.Nombre) && !String.IsNullOrEmpty(persona.Apellidos))
            {
                txtSaludo.Text += $"Hola {persona.Nombre} {persona.Apellidos}";
            }
            else
            {
                txtSaludo.Text = "Los campos no pueden estar vacios";
                txtSaludo.TextColor = Colors.Red;
            }
        }
    }

}
