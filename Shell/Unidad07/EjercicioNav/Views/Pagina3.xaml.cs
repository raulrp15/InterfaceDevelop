namespace EjercicioTagged.Views;
using EjercicioNav;
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
	// No se guarda lo que hay en el entry porque se genera un nuevo MainPage
}