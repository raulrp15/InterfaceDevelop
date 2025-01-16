using ENT;
using CRUD.ViewModels.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using System.Net;
using CommunityToolkit.Maui.Alerts;

namespace CRUD.ViewModels
{
    [QueryProperty(nameof(Persona), "Persona")]
    public class vmEdInsPersona : INotifyPropertyChanged
    {
        private string nombre;
        private string apellido;
        private string telefono;
        private string foto;
        private string direccion;
        private DateTime fecha;
        private clsPersona persona;
        private ObservableCollection <clsDepartamento> listaDept;
        private clsDepartamento departSelect;
        private DelegateCommand addCommand;
        private DelegateCommand updateCommand;
        private bool isLoading = false;
        private HttpStatusCode statusCode;

        public bool IsLoading { get { return isLoading; } }
        public DelegateCommand AddCommand { get { return addCommand; } }
        public DelegateCommand UpdateCommand { get { return updateCommand; } }
        public ObservableCollection<clsDepartamento> ListaDept { get { return listaDept; } }
        public clsDepartamento DepartSelect { get { return departSelect; } set { departSelect = value; addCommand.RaiseCanExecuteChanged(); } }
        public string Nombre { get { return nombre; } set { nombre = value; addCommand.RaiseCanExecuteChanged(); } }
        public string Apellido { get { return apellido; } set { apellido = value; addCommand.RaiseCanExecuteChanged(); } }
        public string Telefono { get { return telefono; } set { telefono = value; addCommand.RaiseCanExecuteChanged(); } }
        public string Foto { get { return foto; } set { foto = value; addCommand.RaiseCanExecuteChanged();} }
        public DateTime Fecha { get { return fecha; } set { fecha = value; addCommand.RaiseCanExecuteChanged(); } }
        public string Direccion { get { return direccion; } set { direccion = value; addCommand.RaiseCanExecuteChanged(); } }
        public clsPersona Persona { get { return persona; } set { persona = value; NotifyPropertyChanged(nameof(Persona)); } }

        public vmEdInsPersona()
        {
            listaDept = new ObservableCollection<clsDepartamento>();
            persona = new clsPersona();
            addCommand = new DelegateCommand(addExecute, addCanExecute);
            updateCommand = new DelegateCommand(updateExecute);
            listarDepartamentos();
            
        }

        private async void listarDepartamentos()
        {
            isLoading = false;
            NotifyPropertyChanged(nameof(IsLoading));
            listaDept.Clear();
            var depts = await Services.getDepartamentos();
            foreach (var d in depts) 
            {
                listaDept.Add(d);
            }
            isLoading = true;
            NotifyPropertyChanged(nameof(IsLoading));
            NotifyPropertyChanged(nameof(ListaDept));

        }

        private async void addExecute()
        {
            try
            {
                persona.Id = 0;
                persona.Nombre = nombre;
                persona.Apellidos = apellido;
                persona.Foto = foto;
                persona.Telefono = telefono;
                persona.Direccion = direccion;
                persona.FechaNacimiento = fecha;
                persona.IdDepartamento = departSelect.Id;
                await Services.insertPersona(persona);
                if (statusCode == HttpStatusCode.OK)
                {
                    await Toast.Make($"Se ha añadido correctamente", ToastDuration.Long, 20).Show();
                }
                else
                {
                    await Toast.Make($"Error {statusCode.GetTypeCode}", ToastDuration.Long, 20).Show();
                }
                await Shell.Current.GoToAsync("///Listado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool addCanExecute()
        {
            bool add = false;
            if (nombre != null && apellido != null && telefono != null && direccion != null && departSelect != null)
            {
                add = true;
            }
            return add;
        }

        public async void updateExecute()
        {
            try
            {
                persona.IdDepartamento = departSelect.Id;
                statusCode = await Services.updatePersona(persona);
                if (statusCode == HttpStatusCode.OK)
                {
                    await Toast.Make($"Se ha modificado correctamente", ToastDuration.Long, 20).Show();
                }
                else
                {
                    await Toast.Make($"Error {statusCode.GetTypeCode}", ToastDuration.Long, 20).Show();
                }
                await Shell.Current.GoToAsync("///Listado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
