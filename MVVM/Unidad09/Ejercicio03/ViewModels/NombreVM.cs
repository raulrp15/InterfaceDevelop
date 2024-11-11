using Ejercicio03ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio03.ViewModels
{
    public class NombreVM : INotifyPropertyChanged
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; NotifyPropertyChanged("Nombre"); }
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
