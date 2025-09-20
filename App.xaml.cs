using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace TP1_Donateurs
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string langue = TP1_Donateurs.Properties.Settings.Default.langue;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langue);
        }
    }
}
