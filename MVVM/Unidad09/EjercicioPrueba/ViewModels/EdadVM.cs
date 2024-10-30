using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPrueba.ViewModels
{
    public class EdadVM : INotifyPropertyChanged
    {
        #region Atributos
        private DateTime fechaNac;
        private int edad;
        #endregion

        #region Propiedades
        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; NotifyPropertyChanged("Edad");}
        }
        public int Edad
        {
            get {
                edad = CalculaEdad(fechaNac);
                return edad;
            }
        }
        #endregion

        #region Funciones

        /// <summary>
        /// Funcion que calcula la edad del usuario desde la fecha
        /// </summary>
        /// <param name="fechaNac"></param>
        /// <returns>La edad del usuario</returns>
        private int CalculaEdad(DateTime fechaNac)
        {
            DateTime fechaActual = DateTime.Today;
            if (fechaNac > fechaActual)
            {
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNac.Year;
                if (fechaNac.Month > fechaActual.Month ||
                    fechaNac.Month == fechaActual.Month && fechaNac.Day > fechaActual.Day)
                {
                    --edad;
                }
                return edad;
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
