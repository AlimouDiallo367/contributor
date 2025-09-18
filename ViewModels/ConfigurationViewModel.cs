using System;
using System.Diagnostics;
using System.Windows;
using TP1_Donateurs.ViewModels.Commands;

namespace TP1_Donateurs.ViewModels
{
    public class ConfigurationViewModel : BaseViewModel
    {
        #region RelayCommands
        public RelayCommand CmdSauvegarder { get; private set; }
        public RelayCommand CmdAnnuler { get; private set; }
        #endregion

        private string _langueSelectionnee;
        public string LangueSelectionnee
        {
            get => _langueSelectionnee;
            set
            {
                _langueSelectionnee = value;
                OnPropertyChanged();
            }
        }

        private bool _redemarrerApresChangements;
        public bool RedemarrerApresChangements
        {
            get => _redemarrerApresChangements;
            set
            {
                _redemarrerApresChangements = value;
                OnPropertyChanged();
            }
        }

        public ConfigurationViewModel()
        {
            // Valeurs par défaut
            LangueSelectionnee = "Français";
            RedemarrerApresChangements = false;

            CmdSauvegarder = new RelayCommand(Sauvegarder, null);
            CmdAnnuler = new RelayCommand(Annuler, null);
        }

        private void Sauvegarder(object? obj)
        {
            // Exemple : sauvegarde en mémoire (tu pourrais l’écrire dans un fichier de config plus tard)
            MessageBox.Show(
                $"Langue: {LangueSelectionnee}\nRedémarrage auto: {RedemarrerApresChangements}",
                "Configuration sauvegardée",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );

            if (RedemarrerApresChangements)
            {
                // Redémarre l'application
                Process.Start(Environment.ProcessPath!);
                Application.Current.Shutdown();
            }
            else
            {
                FermerFenetre(obj);
            }
        }

        private void Annuler(object? obj)
        {
            FermerFenetre(obj);
        }

        private void FermerFenetre(object? obj)
        {
            if (obj is Window fenetre)
            {
                fenetre.Close();
            }
        }
    }
}
