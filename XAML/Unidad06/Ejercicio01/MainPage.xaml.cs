
namespace Ejercicio01
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void CrearBtn3(object sender, EventArgs e)
        {
            var boton3 = new Button
            {
                Text = "Boton 3",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.Blue,
                MaximumHeightRequest = 70,
                MaximumWidthRequest = 200,
                FontAttributes = FontAttributes.Bold,
                FontFamily = "Verdana",
                FontSize = 16,
                Margin = 30,
                BorderColor = Colors.Yellow,
                BorderWidth = 2,
            };
            boton3.Clicked += CreaBtns;

            vertical.Children.Add(boton3);
        }

        private void CreaBtns(object sender, EventArgs e)
        {
            vertical.Children.Remove(btn1);
            btn2.Text = "Crear controles en tiempo de ejecución mola";
            btn2.Clicked -= CrearBtn3 ;
        }
         
    }
}
