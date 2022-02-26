using HVKDesktopUI.Stores;
using HVKDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKDesktopUI.Commands
{
    public class NavigateCommand <TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        private readonly NavigationStore _navigationStore;

        private readonly Func<TViewModel> _createViewModel;

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(new NavigationBarViewModel(_navigationStore), _createViewModel);
        }
    }
}
