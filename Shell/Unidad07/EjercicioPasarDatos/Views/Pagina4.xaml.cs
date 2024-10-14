using BibliotecaDeClases;

namespace EjercicioPasarDatos.Views;

public partial class Pagina4 : ContentPage
{
	public Pagina4()
	{
		InitializeComponent();
		
	}
    public Pagina4(ClsPersona pers) : this()
    {
        if (pers != null)
        {
            res4.Text = $"{pers.Nombre} {pers.Apellidos}";
        }
    }
}