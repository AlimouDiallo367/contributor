using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Donateurs.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged 
    {
        public BaseViewModel()
        {
            
        }

        // Ancienne approche que j'utilisais - Méthode Lyne 
        public enum ACTIONMODE { ADD, DISPLAY };
        private ACTIONMODE _currentActionMode = ACTIONMODE.DISPLAY;

        public virtual ACTIONMODE CurrentActionMode
        {
            get => _currentActionMode;
            set
            {
                if (_currentActionMode != value)
                {
                    _currentActionMode = value;
                    OnPropertyChanged("IsEnabled");
                    OnPropertyChanged("IsReadOnly");
                }
            }
        }

        public bool IsEnabled => _currentActionMode != ACTIONMODE.DISPLAY;
        public bool IsReadOnly => _currentActionMode == ACTIONMODE.DISPLAY;

        public virtual bool CanBeginEdit(object obj)
        {
            return CurrentActionMode == ACTIONMODE.DISPLAY;
        }

        public virtual bool CanEndEdit(object obj)
        {
            return CurrentActionMode != ACTIONMODE.DISPLAY;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
