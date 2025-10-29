using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Contributor.Models;
using Contributor.ViewModels.Commands;

namespace Contributor.ViewModels
{
    public class ContributionViewModel : BaseViewModel
    {
        #region RelayCommands
        public RelayCommand CmdImporterFichier {  get; private set; }
        public RelayCommand CmdEffacer { get; private set; }
        public RelayCommand CmdContributionsIllegales { get; private set; }
        #endregion

        public int NbContributions 
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
            CmdContributionsIllegales = new RelayCommand(FiltrerContributions, PeutFiltrer);
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
                    OnPropertyChanged(nameof(NbContributions));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Contributor.Properties.traduction.msg_fichier_invalide, Contributor.Properties.traduction.titre_erreur, MessageBoxButton.OK, MessageBoxImage.Error); 
                }    
            }
        }

        private void EffacerContributions(object? obj)
        {
            LesContributions.Clear();
            AfficherContributionsIllegales = false;
            OnPropertyChanged(nameof(NbContributions));
        }
        
        private void FiltrerContributions(object? obj)
        {
            if (obj is bool estCoche)
            {
                AfficherContributionsIllegales = estCoche;
                LesContributions.Clear();

                var data = estCoche ? analyseur.RechercherContributionsPossiblementIllegales() : analyseur.Contributions;

                foreach (var contribution in data)
                {
                    LesContributions.Add(contribution); 
                }
            }
        }

        
        private bool PeutFiltrer(object? obj)
        {
            return LesContributions.Count > 0;
        }

        #endregion

    }
}
