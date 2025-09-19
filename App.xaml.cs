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
            //TP1_Donateurs.Properties.Settings.Default.langue = "en-US";
            //TP1_Donateurs.Properties.Settings.Default.langue = "fr-CA";

            //TP1_Donateurs.Properties.Settings.Default.Save();
            string langue = TP1_Donateurs.Properties.Settings.Default.langue;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langue);
        }
    }
}
