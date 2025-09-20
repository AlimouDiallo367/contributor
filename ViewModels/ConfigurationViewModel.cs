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

        public List<string> LangueDisponibles { get; } = new List<string> { "Français", "English" };
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
            LangueSelectionnee = TP1_Donateurs.Properties.Settings.Default.langue == "fr-CA" ? "Français" : "English";
            RedemarrerApresChangements = true;

            CmdSauvegarder = new RelayCommand(Sauvegarder, null);
            CmdAnnuler = new RelayCommand(Annuler, null);
        }

        private void Sauvegarder(object? obj)
        {
            try
            {
                TP1_Donateurs.Properties.Settings.Default.langue = (LangueSelectionnee == "Français") ? "fr-CA" : "en-US";
                TP1_Donateurs.Properties.Settings.Default.Save();

                if (RedemarrerApresChangements)
                {
                    MessageBox.Show(
                        TP1_Donateurs.Properties.traduction.msg_confirmation_redemarrage,
                        TP1_Donateurs.Properties.traduction.titre_information,
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    RedemarrerApplication();
                }
                else
                {
                    FermerFenetre(obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    TP1_Donateurs.Properties.traduction.titre_erreur,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
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

        private void RedemarrerApplication()
        {
            // Redémarre l'application -- From Chat
            Process.Start(Environment.ProcessPath!);
            Application.Current.Shutdown();
        }
    }
}
