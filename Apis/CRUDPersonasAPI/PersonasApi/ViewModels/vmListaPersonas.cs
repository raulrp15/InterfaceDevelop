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
        
        public List<mdlPersonaEdad> ListadoPersonasEdad { get { return listadoPersonasEdad; } }
        public bool IsLoading { get { return isLoading; } }
        public DelegateCommand LoadCommand { get { return loadCommand; } }

        public vmListaPersonas()
        {
            loadCommand = new DelegateCommand(cargarExecute);
            isLoading = false;
        }

        private async void cargarExecute()
        {
            await cargarListado();
        }

        private async Task cargarListado()
        {
            isLoading = true;
            NotifyPropertyChanged(nameof(IsLoading));
            if (listadoPersonasEdad != null)
            {
                listadoPersonasEdad.Clear();
            }
            else
            {
                listadoPersonasEdad = new List<mdlPersonaEdad>();
            }
            listadoPersonas = await Services.getPersonas();
            foreach (var p in listadoPersonas)
            {
                listadoPersonasEdad.Add(new mdlPersonaEdad(p));
            }
            isLoading = false;
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
