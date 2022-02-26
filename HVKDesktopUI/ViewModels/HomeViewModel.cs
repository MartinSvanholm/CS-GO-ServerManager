using HVKClassLibary.Models.Account;
using HVKClassLibary.Shared;
using HVKDesktopUI.Commands;
using HVKDesktopUI.Commands.ServerCommands;
using HVKDesktopUI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HVKDesktopUI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateToServerListCommand { get; }

        public ICommand LoginCommand { get; }

        public Account Account { get; set; } = new();

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateToServerListCommand = new NavigateCommand<ServerListViewModel>(navigationStore, () => new ServerListViewModel(navigationStore));
            LoginCommand = new LoginCommand(Account);
        }
    }
}
