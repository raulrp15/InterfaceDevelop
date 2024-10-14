namespace EjercicioPasarDatos.Views;

public partial class Pagina3 : ContentPage
{
	public Pagina3()
	{
		InitializeComponent();
	}

    private async void Btn_Volver(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}