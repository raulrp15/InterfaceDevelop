using ENT;
using PokeApi.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokeApi.ViewModels
{
    public class vmListaPokemon : INotifyPropertyChanged
    {
        private List<clsPokemon> listaPokemons;
        private DelegateCommand buscarCommand;
        private int firstPok;
        private int lastPok;
        public vmListaPokemon() 
        {
            
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
