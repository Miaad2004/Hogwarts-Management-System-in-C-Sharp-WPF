using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts_Management_System.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel = new LoginViewModel();
        public BaseViewModel CurrentViewModel
        { 
            get { return _currentViewModel; }
            set { _currentViewModel = value; }  
        }

        public MainViewModel()
        {
            CurrentViewModel = new LoginViewModel();
        }
    }
}
