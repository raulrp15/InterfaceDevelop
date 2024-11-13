using Ejercicio01Unidad10.ViewModels.Utilidades;
using Ejercicio5bBL;
using Ejercicio5bDAL;
using Ejercicio5bENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01Unidad10.ViewModels
{
    public class ListadoPersonaVM : INotifyPropertyChanged
    {
        #region Atributo
        private ObservableCollection<ClsPersona> listado;
        private ClsPersona persona_select;
        private DelegateCommand eliminarCommand;
        #endregion

        #region Propiedades
        public ObservableCollection<ClsPersona> Listado { get { return listado; } }
        public ClsPersona PersonaSelect { get { return persona_select; } set { persona_select = value; NotifyPropertyChanged("PersonaSelect"); } }
        public DelegateCommand EliminarCommand { get { return eliminarCommand; } }
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

