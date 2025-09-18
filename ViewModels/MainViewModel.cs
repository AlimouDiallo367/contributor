using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_Donateurs.ViewModels.Commands;

namespace TP1_Donateurs.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region RelayCommands
        public RelayCommand CmdGotoConfiguration {  get; private set; }
        #endregion

        private BaseViewModel _currentViewModel;
        private ContributionViewModel _contributionViewModel;
        private ConfigurationViewModel _configurationViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            { 
                _currentViewModel = value;
            }
        }

        public MainViewModel()
        {
            _contributionViewModel = new ContributionViewModel();
            _configurationViewModel = new ConfigurationViewModel();
            _currentViewModel = _contributionViewModel;

            CmdGotoConfiguration = new RelayCommand(GotoConfiguration, null);
        }
        
        private void GotoConfiguration(object? obj)
        {
            //CurrentViewModel = _configurationViewModel;
            var configurationWindow = new Views.ConfigurationView();
            configurationWindow.DataContext = _configurationViewModel;
            configurationWindow.Show();
        }
    }
}
