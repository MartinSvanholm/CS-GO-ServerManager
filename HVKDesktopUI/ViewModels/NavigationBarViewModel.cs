using HVKDesktopUI.Commands;
using HVKDesktopUI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HVKDesktopUI.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }

        public ICommand NavigateToServerListCommand { get; }

        public NavigationBarViewModel(NavigationStore navigationStore)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));
            NavigateToServerListCommand = new NavigateCommand<ServerListViewModel>(navigationStore, () => new ServerListViewModel(navigationStore));
        }
    }
}
