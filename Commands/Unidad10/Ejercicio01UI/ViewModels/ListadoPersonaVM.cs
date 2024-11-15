using CapaBL;
using CapaENT;
using Ejercicio01UI.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01UI.ViewModels
{
    public class ListadoPersonaVM
    {
        #region Atributo
        private ObservableCollection<ClsPersona> listado;
        private ClsPersona persona_select;
        private string busqueda = "";
        #endregion

        #region Propiedades
        public ObservableCollection<ClsPersona> Listado 
        { 
            get { return listado; } 
        }
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
        public string Busqueda 
        { 
            get { return busqueda; } 
            set 
            {
                busqueda = value;
                if (string.IsNullOrEmpty(busqueda))
                {
                    listado.Clear();
                    foreach (ClsPersona persona in ClsListadoBL.GetListadoPersonaBL())
                    {
                        listado.Add(persona);
                    }
                }
                NotifyPropertyChanged("Busqueda");
                BusquedaCommand.RaiseCanExecuteChanged();
            } 
        }
        public DelegateCommand EliminarCommand { get; }
        public DelegateCommand BusquedaCommand { get; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que rellena el listado de persona y genera los comandos de la vista
        /// </summary>
        public ListadoPersonaVM()
        {
            try
            {
                listado = new ObservableCollection<ClsPersona>(ClsListadoBL.GetListadoPersonaBL());
            }
            catch (Exception ex)
            {
                // TODO Enviar mensaje de error
            }

            EliminarCommand = new DelegateCommand(EliminaPersonaSelect, PuedeEliminarPersonaSelect);
            BusquedaCommand = new DelegateCommand(BuscaPersona, PuedeBuscarPersona);
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
            listado.Clear();
            //Listado = new ObservableCollection<ClsPersona>(ClsListadoBL.GetListadoPersonasBusquedaBL(Busqueda));

            if(Busqueda != null)
            {
                foreach (ClsPersona persona in ClsListadoBL.GetListadoPersonasBusquedaBL(Busqueda))
                {
                    listado.Add(persona);
                }
            }
        }

        /// <summary>
        /// Funcion que determina si se habilita o no el boton de busqueda
        /// </summary>
        /// <returns>Booleano que habilita o no el boton de busqueda</returns>
        public bool PuedeBuscarPersona()
        {
            return !string.IsNullOrEmpty(Busqueda);
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
