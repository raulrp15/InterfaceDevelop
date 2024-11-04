using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02.Models.ENT
{
    public class ClsPersona : INotifyPropertyChanged
    {
        #region Atributos

        private string nombre = "";

        #endregion

        #region Atributos
        
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; NotifyPropertyChanged("Nombre"); }
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
