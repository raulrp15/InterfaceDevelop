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
            set 
            {
                listado = value;
                NotifyPropertyChanged("Listado");
            } 
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
                        Listado.Add(persona);
                    }
                }
                NotifyPropertyChanged("Busqueda");
                BusquedaCommand.RaiseCanExecuteChanged();
            } 
        }
        public DelegateCommand EliminarCommand { get; }
        public DelegateCommand BusquedaCommand { get; }
        #endregion

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

        #region Funciones
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <returns></returns>
        public bool PuedeEliminarPersonaSelect()
        {
            return PersonaSelect != null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BuscaPersona()
        {
            Listado.Clear();
            //Listado = new ObservableCollection<ClsPersona>(ClsListadoBL.GetListadoPersonasBusquedaBL(Busqueda));

            if(Busqueda != null)
            {
                foreach (ClsPersona persona in ClsListadoBL.GetListadoPersonasBusquedaBL(Busqueda))
                {
                    Listado.Add(persona);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
