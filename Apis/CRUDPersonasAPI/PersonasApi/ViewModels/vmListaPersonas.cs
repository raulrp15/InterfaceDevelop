using DAL;
using ENT;
using PersonasApi.Models;
using PersonasApi.ViewModels.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PersonasApi.ViewModels
{
    public class vmListaPersonas : INotifyPropertyChanged
    {
        private List<clsPersona> listadoPersonas;
        private List<mdlPersonaEdad> listadoPersonasEdad;
        private bool isLoading;
        private DelegateCommand loadCommand;
        private string apellidoPersona;
        
        public List<mdlPersonaEdad> ListadoPersonasEdad { get { return listadoPersonasEdad; } }
        public bool IsLoading { get { return isLoading; } }
        public DelegateCommand LoadCommand { get { return loadCommand; } }
        public string ApellidoPersona { get { return apellidoPersona; } }

        public vmListaPersonas()
        {
            listadoPersonasEdad = new List<mdlPersonaEdad>();
            loadCommand = new DelegateCommand(cargarExecute);
            isLoading = false;
            cargarExecute();
        }

        private async void cargarExecute()
        {
            isLoading = true;
            NotifyPropertyChanged(nameof(IsLoading));
            listadoPersonasEdad.Clear();
            listadoPersonas = await Services.getPersonas();
            foreach (var p in listadoPersonas)
            {
                listadoPersonasEdad.Add(new mdlPersonaEdad(p));
            }
            isLoading = false;
            apellidoPersona = ListadoPersonasEdad[9].Persona.Apellidos;
            NotifyPropertyChanged(nameof(ApellidoPersona));
            NotifyPropertyChanged(nameof(IsLoading));
            NotifyPropertyChanged(nameof(ListadoPersonasEdad));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
