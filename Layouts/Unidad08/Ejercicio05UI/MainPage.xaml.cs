using Ejercicio05DAL;
using Ejercicio05ENT;
using System.Collections.ObjectModel;

namespace Ejercicio05UI
{
    public partial class MainPage : ContentPage
    {
        List<ClsPersona> personas;

        /// <summary>
        /// Funcion que inicializa la vista y manda el listado a la listview
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            personas = ClsListadoPersonas.getListadoCompletoPersonas();

            lvPersona.ItemsSource = personas;
        }
        
    }

}
