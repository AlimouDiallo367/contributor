using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_Donateurs.Models;

namespace TP1_Donateurs.ViewModels
{
    public class ContributionViewModel : BaseViewModel
    {
        private string _type, _nom, _prenom, _municipalite, _codePostal, _parti, _candidat;
        private decimal _montant;
        private int _nbVersements, anneeFinanciere;
        private DateTime _dateEvenement;

        public ObservableCollection<Contribution> LesContributions { get; set; } 

        public ContributionViewModel()
        {
            LesContributions = new ObservableCollection<Contribution>();

            string csv = TP1_Donateurs.Properties.OthersResources.contributions;
        }

    }
}
