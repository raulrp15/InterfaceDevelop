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

namespace Ejercicio5bUI.ViewModels
{
    public class ListadoPersonaVM : INotifyPropertyChanged
    {
        #region Atributo
        private ObservableCollection<ClsPersona> listado = new ObservableCollection<ClsPersona>(ClsListadoBL.GetListadoPersonaBL());
        private ClsPersona persona_select;
        #endregion

        #region Propiedades
        public ObservableCollection<ClsPersona> Listado { get { return listado; } }
        public ClsPersona PersonaSelect { get { return persona_select; } set { persona_select = value; NotifyPropertyChanged("PersonaSelect"); } }
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
