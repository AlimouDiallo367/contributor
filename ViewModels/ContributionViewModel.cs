using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP1_Donateurs.Models;
using TP1_Donateurs.ViewModels.Commands;

namespace TP1_Donateurs.ViewModels
{
    public class ContributionViewModel : BaseViewModel
    {
        #region RelayCommands
        public RelayCommand CmdImporterFichier {  get; private set; }
        public RelayCommand CmdEffacer { get; private set; }
        public RelayCommand CmdContributionsIllegales { get; private set; }
        #endregion

        private int Counter
        {
            get => LesContributions?.Count ?? 0;
        }
        private AnalyseurContributions analyseur;
        public ObservableCollection<Contribution> LesContributions { get; set; }

        private bool _afficherContributionsIllegales;
        public bool AfficherContributionsIllegales
        {
            get => _afficherContributionsIllegales;
            set
            {
                _afficherContributionsIllegales = value;
                OnPropertyChanged();
            }
        }

        public ContributionViewModel()
        {
            LesContributions = new ObservableCollection<Contribution>();
            CmdImporterFichier = new RelayCommand(ImporterFichier, null);
            CmdEffacer = new RelayCommand(EffacerContributions, null);
            CmdContributionsIllegales = new RelayCommand(FiltrerContributions, CanExecuteFiltre);
        }

        #region Boutons
        private void ImporterFichier(object? obj)
        {
            var dialog = new OpenFileDialog(); 

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    analyseur = new AnalyseurContributions(dialog.FileName);
                    foreach (var contribution in analyseur.Contributions)
                    {
                        LesContributions.Add(contribution); 
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(TP1_Donateurs.Properties.traduction.msg_fichier_invalide, TP1_Donateurs.Properties.traduction.titre_erreur, MessageBoxButton.OK, MessageBoxImage.Error); 
                }    
            }
           // CurrentActionMode = ACTIONMODE.ADD;
        }

        private void EffacerContributions(object? obj)
        {
            LesContributions.Clear();
            AfficherContributionsIllegales = false;
            OnPropertyChanged(nameof(Counter));
        }
        
        private void FiltrerContributions(object? obj)
        {
            if (obj is bool isChecked)
            {
                AfficherContributionsIllegales = isChecked;
                LesContributions.Clear();

                var data = isChecked ? analyseur.RechercherContributionsPossiblementIllegales() : analyseur.Contributions;

                foreach (var contribution in data)
                {
                    LesContributions.Add(contribution); 
                }
            }
        }

        
        private bool CanExecuteFiltre(object? obj)
        {
            return LesContributions.Count > 0;
        }

        #endregion

    }
}
