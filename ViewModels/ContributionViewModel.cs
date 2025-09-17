using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_Donateurs.Models;
using TP1_Donateurs.ViewModels.Commands;

namespace TP1_Donateurs.ViewModels
{
    public class ContributionViewModel : BaseViewModel
    {
        #region RelayCommands
        public RelayCommand CmdImporterFichier {  get; private set; }
        #endregion


        private AnalyseurContributions analyseur;
        public ObservableCollection<Contribution> LesContributions { get; set; }

        public ContributionViewModel()
        {
            LesContributions = new ObservableCollection<Contribution>();
            CmdImporterFichier = new RelayCommand(ImporterFichier, null);
           
        }

        #region Boutons
        private void ImporterFichier(object? obj)
        {
            var dialog = new OpenFileDialog(); 

            if (dialog.ShowDialog() == true)
            {
                analyseur = new AnalyseurContributions(dialog.FileName);
                foreach (var contribution in analyseur.Contributions)
                {
                    LesContributions.Add(contribution); 
                }
            }

        }
        #endregion

    }
}
