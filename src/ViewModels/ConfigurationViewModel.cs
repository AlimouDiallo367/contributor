using System;
using System.Diagnostics;
using System.Windows;
using Contributor.ViewModels.Commands;

namespace Contributor.ViewModels
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
            LangueSelectionnee = Contributor.Properties.Settings.Default.langue == "fr-CA" ? "Français" : "English";
            RedemarrerApresChangements = true;

            CmdSauvegarder = new RelayCommand(Sauvegarder, null);
            CmdAnnuler = new RelayCommand(Annuler, null);
        }

        private void Sauvegarder(object? obj)
        {
            try
            {
                Contributor.Properties.Settings.Default.langue = (LangueSelectionnee == "Français") ? "fr-CA" : "en-US";
                Contributor.Properties.Settings.Default.Save();

                if (RedemarrerApresChangements)
                {
                    MessageBox.Show(
                        Contributor.Properties.traduction.msg_confirmation_redemarrage,
                        Contributor.Properties.traduction.titre_information,
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
                    Contributor.Properties.traduction.titre_erreur,
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
