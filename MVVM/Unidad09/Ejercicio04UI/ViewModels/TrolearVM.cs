using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio04UI.ViewModels
{
    public class TrolearVM : INotifyPropertyChanged
    {
        #region Atributos
        private string nombre;
        private string apellidos;
        #endregion

        #region Propiedades
        public string Nombre {
            get { 
                return nombre; 
            } 
            set {
                nombre = value;
                if (nombre.Contains("n") || nombre.Contains("N"))
                {
                    apellidos = "";
                }
                    
                NotifyPropertyChanged("Apellidos"); 
            }
        }
        public string Apellidos {
            get { 
                return apellidos; 
            }
            set { 
                apellidos=value;
                if (apellidos.Contains("n") || apellidos.Contains("N"))
                {
                    nombre = "";
                }
                NotifyPropertyChanged("Nombre");
            }
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
