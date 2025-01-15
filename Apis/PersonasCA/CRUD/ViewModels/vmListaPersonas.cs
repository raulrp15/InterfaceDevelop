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
        private DelegateCommand insertCommand;
        private mdlPersonaEdad personaSelect;
        private clsPersona persona;
        
        public ObservableCollection<mdlPersonaEdad> ListadoPersonasEdad { get { return listadoPersonasEdad; } }
        public bool IsLoading { get { return isLoading; } }
        public DelegateCommand InsertCommand { get { return insertCommand; } }
        public mdlPersonaEdad PersonaSelect { get { return personaSelect; } set { personaSelect = value; insertCommand.RaiseCanExecuteChanged(); } }

        public vmListaPersonas()
        {
            listadoPersonasEdad = new ObservableCollection<mdlPersonaEdad>();
            insertCommand = new DelegateCommand(insertarExecute);
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

        private async void insertarExecute()
        {
            await Shell.Current.GoToAsync("///Insertar");
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
