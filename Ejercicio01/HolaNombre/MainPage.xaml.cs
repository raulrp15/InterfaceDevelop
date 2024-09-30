﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace HolaNombre
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NombreUsu.Header = NombreUsu.Text;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Se obtiene el nombre del usuario
            string nombre = NombreUsu.Text;

            // Se crea el mensaje
            string mensaje = "Hola " + nombre;

            // Se crea el dialogo
            var dialog = new MessageDialog(mensaje);

            // Se muestra el mensaje
            await dialog.ShowAsync();
        }
    }
}
