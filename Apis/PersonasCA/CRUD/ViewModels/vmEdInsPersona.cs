using ENT;
using CRUD.ViewModels.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL;
using CommunityToolkit.Maui.Core;

namespace CRUD.ViewModels
{
    [QueryProperty(nameof(Persona), "Persona")]
    class vmEdInsPersona
    {
        private string nombre;
        private string apellido;
        private string telefono;
        private string foto;
        private string direccion;
        private DateTime fecha;
        private clsPersona persona;
        private DelegateCommand addCommand;
        private DelegateCommand updateCommand;

        public DelegateCommand AddCommand { get { return addCommand; } }
        public DelegateCommand UpdateCommand { get { return updateCommand; } }
        public string Nombre { get { return nombre; } set { nombre = value; addCommand.RaiseCanExecuteChanged(); } }
        public string Apellido { get { return apellido; } set { apellido = value; addCommand.RaiseCanExecuteChanged(); } }
        public string Telefono { get { return telefono; } set { telefono = value; addCommand.RaiseCanExecuteChanged(); } }
        public string Foto { get { return foto; } set { foto = value; addCommand.RaiseCanExecuteChanged(); NotifyPropertyChanged(nameof(Foto)); } }
        public DateTime Fecha { get { return fecha; } set { fecha = value; addCommand.RaiseCanExecuteChanged(); } }
        public string Direccion { get { return direccion; } set { direccion = value; addCommand.RaiseCanExecuteChanged(); } }
        public clsPersona Persona { get { return persona; } set { persona = value; NotifyPropertyChanged(nameof(Persona)); } }

        public vmEdInsPersona()
        {
            persona = new clsPersona();
            addCommand = new DelegateCommand(addExecute, addCanExecute);
            updateCommand = new DelegateCommand(updateExecute);
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
                await Services.insertPersona(persona);
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
            if (nombre != null && apellido != null && telefono != null && direccion != null)
            {
                add = true;
            }
            return add;
        }

        public void updateExecute()
        {
            try
            {
                Shell.Current.GoToAsync("///Listado");
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
