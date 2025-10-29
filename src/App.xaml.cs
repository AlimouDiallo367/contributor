using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace Contributor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string langue = Contributor.Properties.Settings.Default.langue;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langue);
        }
    }
}
