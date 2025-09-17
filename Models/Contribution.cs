using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Donateurs.Models
{
    public class Contribution : INotifyPropertyChanged
    {
        private string _type;
        private string _nom;
        private string _prenom;
        private decimal _montant;
        private int _nbVersements;
        private string _municipalite;
        private string _codePostal;
        private string _parti;
        private string _candidat;
        private DateTime _dateEvenement;
        private int anneeFinanciere;

        public Contribution(string ligneCSV)
        {
            string[] champsFichier = ligneCSV.Split(',');
           
            Type = champsFichier[0].Trim();
            Nom = champsFichier[1].Trim();
            Prenom = champsFichier[2].Trim();
            Montant = decimal.Parse(champsFichier[3]);
            NbVersements = int.Parse(champsFichier[4]);
            Municipalite = champsFichier[5].Trim();
            CodePostal = champsFichier[6].Trim();
            Parti = champsFichier[7].Trim();
            Candidat = champsFichier[8].Trim();
            DateEvenement = DateTime.Parse(champsFichier[9]);
            AnneeFinanciere = int.Parse((champsFichier[10]));
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Nom
        {
            get => _nom;
            set
            {
                _nom = value;
            }
        }

        public string Prenom
        {
            get => _prenom;
            set
            {
                _prenom = value;
            }
        }

        public decimal Montant
        {
            get => _montant;
            set
            {
                _montant = value;
            }
        }

        public int NbVersements
        {
            get => _nbVersements;
            set
            {
                _nbVersements = value;
            }
        }

        public string Municipalite
        {
            get => _municipalite;
            set
            {
                _municipalite = value;
            }
        }

        public string CodePostal
        {
            get { return _codePostal; }
            set
            {
                _codePostal = value;
            }
        }

        public string Parti
        {
            get => _parti;
            set
            {
                _parti = value;
            }
        }

        public string Candidat
        {
            get => _candidat;
            set
            {
                _candidat = value;
            }
        }

        public DateTime DateEvenement
        {
            get => _dateEvenement;
            set
            {
                _dateEvenement = value;
            }
        }

        public int AnneeFinanciere
        {
            get => anneeFinanciere;
            set
            {
                anneeFinanciere = value;
            }
        }

        // PropertyChanged 
        
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
