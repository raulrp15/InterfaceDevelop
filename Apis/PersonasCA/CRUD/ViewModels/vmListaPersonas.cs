using DAL;
using ENT;
using CRUD.Models;
using CRUD.ViewModels.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Net;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace CRUD.ViewModels
{
    public class vmListaPersonas : INotifyPropertyChanged
    {
        private ObservableCollection<clsPersona> listadoPersonas;
        private ObservableCollection<mdlPersonaEdad> listadoPersonasEdad;
        private bool isLoading;
        private DelegateCommand insertCommand;
        private DelegateCommand deleteCommand;
        private DelegateCommand updateCommand;
        private mdlPersonaEdad personaSelect;
        private clsPersona persona;
        private HttpStatusCode statusCode;
        
        public ObservableCollection<mdlPersonaEdad> ListadoPersonasEdad { get { return listadoPersonasEdad; } }
        public bool IsLoading { get { return isLoading; } }
        public DelegateCommand InsertCommand { get { return insertCommand; } }
        public DelegateCommand UpdateCommand { get { return updateCommand; } }
        public mdlPersonaEdad PersonaSelect { get { return personaSelect; } set { personaSelect = value; updateCommand.RaiseCanExecuteChanged(); deleteCommand.RaiseCanExecuteChanged(); } }
        public DelegateCommand DeleteCommand { get { return deleteCommand; } }

        public vmListaPersonas()
        {
            listadoPersonasEdad = new ObservableCollection<mdlPersonaEdad>();
            insertCommand = new DelegateCommand(insertarExecute);
            updateCommand = new DelegateCommand(updateExecute, bothCanExecute);
            deleteCommand = new DelegateCommand(eliminarExecute, bothCanExecute);
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

        private bool bothCanExecute()
        {
            bool del = false;
            if (personaSelect != null)
            {
                del = true;
            }
            return del;
        }

        private async void updateExecute()
        {
            Dictionary<string, object> dic = new();
            persona = personaSelect.Persona;
            dic.Add("Persona", persona);
            await Shell.Current.GoToAsync("///Update", dic);
        }

        private async void eliminarExecute()
        {
            persona.Id = personaSelect.Persona.Id;
            statusCode = await Services.EliminarPersona(persona.Id);
            if(statusCode == HttpStatusCode.OK)
            {
                await Toast.Make("Se ha eliminado correctamente", ToastDuration.Long, 20).Show();
            }
            else
            {
                await Toast.Make($"Error {statusCode.GetTypeCode}", ToastDuration.Long, 20).Show();
            }
            cargarExecute();
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
