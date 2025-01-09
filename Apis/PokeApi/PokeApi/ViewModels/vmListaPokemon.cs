using DAL;
using ENT;
using PokeApi.ViewModels.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PokeApi.ViewModels
{
    public class vmListaPokemon : INotifyPropertyChanged
    {
        #region Atributos
        private List<clsPokemon> listaPokemons;
        private DelegateCommand buscarCommand;
        private int firstPok;
        private int lastPok;
        #endregion

        #region Propiedades
        public List<clsPokemon> ListaPokemons {  get { return listaPokemons; } }
        public DelegateCommand BuscarCommand { get { return buscarCommand; } }
        public int FirstPok { get { return firstPok; } set { firstPok = value; buscarCommand.RaiseCanExecuteChanged(); } }
        public int LastPok { get { return lastPok; } set{ lastPok = value; buscarCommand.RaiseCanExecuteChanged(); } }
        #endregion

        #region Constructores
        public vmListaPokemon() 
        {
            buscarCommand = new DelegateCommand(buscarExecute, buscarCanExecute);
        }
        #endregion

        #region Funcionalidad de comandos
        private async void buscarExecute()
        {
            listaPokemons = await Services.getPokemons(firstPok, lastPok);
            NotifyPropertyChanged(nameof(ListaPokemons));
        }

        private bool buscarCanExecute()
        {
            return lastPok > 0 && firstPok > 0;
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
