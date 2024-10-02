using BibliotecaDeClases;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSaludar_Click(object sender, RoutedEventArgs e)
        {
            ClsPersona persona = new ClsPersona();

            if (!txtNombre.Text.Equals(""))
            {
                persona.Nombre = txtNombre.Text;

                MessageBox.Show(
                "Hola, " + persona.Nombre,
                "Saludar",
                MessageBoxButton.OK
                );
            }
            else
            {
                mError.Content = "No puede estar vacio";
            }
            
        }
    }
}