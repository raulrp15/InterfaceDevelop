using CapaBL;
using CapaENT;
using Ejercicio02UI.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02UI.ViewModels
{
    public class ListadoPersonaVM : INotifyPropertyChanged
    {
        #region Atributo
        private ObservableCollection<ClsPersona> listadoBase;
        private ClsPersona persona_select;
        private string busqueda = "";
        private ObservableCollection<ClsPersona> listado;
        private DelegateCommand eliminarCommand;
        private DelegateCommand buscarCommand;
        #endregion

        #region Propiedades
        public ClsPersona PersonaSelect 
        { 
            get { return persona_select; } 
            set 
            { 
                persona_select = value; 
                NotifyPropertyChanged("PersonaSelect");
                EliminarCommand.RaiseCanExecuteChanged();
            }
        }
        public ObservableCollection<ClsPersona> Listado { get { return listado; } }
        public string Busqueda 
        { 
            get { return busqueda; } 
            set 
            {
                busqueda = value;
                if (string.IsNullOrEmpty(busqueda))
                {
                    listado = listadoBase;
                }
                NotifyPropertyChanged("Listado");
                BusquedaCommand.RaiseCanExecuteChanged();
            } 
        }
        public DelegateCommand EliminarCommand { get { return eliminarCommand; } }
        public DelegateCommand BusquedaCommand { get { return buscarCommand; } }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que rellena el listado de persona y genera los comandos de la vista
        /// </summary>
        public ListadoPersonaVM()
        {
            try
            {
                listadoBase = new ObservableCollection<ClsPersona>(ClsListadoBL.GetListadoPersonaBL());
                listado = listadoBase;
            }
            catch (Exception ex)
            {
                // TODO Enviar mensaje de error
            }

            eliminarCommand = new DelegateCommand(EliminaPersonaSelect, PuedeEliminarPersonaSelect);
            buscarCommand = new DelegateCommand(BuscaPersona, PuedeBuscarPersona);
        }
        #endregion

        #region Funciones
        /// <summary>
        /// Funcion que desplega una alerta y si es true se borra la persona de la lista
        /// </summary>
        public async void EliminaPersonaSelect()
        {
            bool acepta = await Application.Current.MainPage.DisplayAlert("Borrar persona", "¿Estas seguro de que quieres borrar esta persona?", "Sí", "No");

            if (acepta)
            {
                if (PersonaSelect != null)
                {
                    listadoBase.Remove(PersonaSelect);
                    listado.Remove(PersonaSelect);
                    PersonaSelect = null;
                }
            }
            
        }

        /// <summary>
        /// Funcion que determina si se habilita o no el boton de eliminar al pulsar sobre una persona
        /// </summary>
        /// <returns>Booleano para habilitar o deshabilitar el boton</returns>
        public bool PuedeEliminarPersonaSelect()
        {
            return PersonaSelect != null;
        }

        /// <summary>
        /// Funcion que desplega una lista segun la busqueda que haya realiazado el usuario
        /// </summary>
        public void BuscaPersona()
        {
            listado = new ObservableCollection<ClsPersona>(ClsListadoBL.GetListadoPersonasBusquedaBL(busqueda));

            NotifyPropertyChanged("Listado");
        }

        /// <summary>
        /// Funcion que determina si se habilita o no el boton de busqueda
        /// </summary>
        /// <returns>Booleano que habilita o no el boton de busqueda</returns>
        public bool PuedeBuscarPersona()
        {
            return !string.IsNullOrEmpty(busqueda);
        }

        #endregion

        #region Notify
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
