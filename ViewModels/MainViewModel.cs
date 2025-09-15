using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Donateurs.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ContributionViewModel _contributionViewModel;
        private BaseViewModel _currentViewModel;
        public MainViewModel()
        {
            _contributionViewModel = new ContributionViewModel();
            _currentViewModel = _contributionViewModel;
        }

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set { _currentViewModel = value; }
        }
    }
}
