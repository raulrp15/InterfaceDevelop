using DAL;
using ENT;
using CRUD.Models;
using CRUD.ViewModels.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace CRUD.ViewModels
{
    public class vmListaPersonas : INotifyPropertyChanged
    {
        private ObservableCollection<clsPersona> listadoPersonas;
        private ObservableCollection<mdlPersonaEdad> listadoPersonasEdad;
        private bool isLoading;
        private DelegateCommand loadCommand;
        
        public ObservableCollection<mdlPersonaEdad> ListadoPersonasEdad { get { return listadoPersonasEdad; } }
        public bool IsLoading { get { return isLoading; } }
        public DelegateCommand LoadCommand { get { return loadCommand; } }

        public vmListaPersonas()
        {
            listadoPersonasEdad = new ObservableCollection<mdlPersonaEdad>();
            loadCommand = new DelegateCommand(cargarExecute);
            isLoading = false;
            cargarExecute();
        }

        private async void cargarExecute()
        {
            isLoading = true;
            NotifyPropertyChanged(nameof(IsLoading));
            listadoPersonasEdad.Clear();
            listadoPersonas = new ObservableCollection<clsPersona>(await Services.getPersonas());
            foreach (var p in listadoPersonas)
            {
                listadoPersonasEdad.Add(new mdlPersonaEdad(p));
            }
            isLoading = false;
            NotifyPropertyChanged(nameof(IsLoading));
            NotifyPropertyChanged(nameof(ListadoPersonasEdad));
        }

        #region Notify
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
