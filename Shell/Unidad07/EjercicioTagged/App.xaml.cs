﻿using EjercicioTagged.Views;

namespace EjercicioTagged
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PaginaTabbed());
        }
    }
}
