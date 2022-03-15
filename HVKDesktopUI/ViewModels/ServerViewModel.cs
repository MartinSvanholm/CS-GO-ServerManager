using HVKClassLibary.Models;
using HVKClassLibary.Shared;
using HVKDesktopUI.Commands;
using HVKDesktopUI.Commands.ServerCommands;
using HVKDesktopUI.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HVKDesktopUI.ViewModels
{
    public class ServerViewModel : ViewModelBase
    {
        public ServerViewModel(Server server, NavigationStore navigationStore)
        {
            this.Server = server;

            NavigateToServerCommand = new NavigateCommand<ServerViewModel>(navigationStore, () => new ServerViewModel(server, navigationStore));

            StartServerCommand = new StartServerCommand(this);
            StartGameCommand = new StartGameCommand(this);
            StartOvertimeGameCommand = new StartOvertimeGameCommand(this);
            StartNadePraticeCommand = new StartNadePraticeCommand(this);
            SwitchMapCommand = new SwitchMapCommand(this, SelectedMap);
            PauseGameCommand = new PauseGameCommand(this);
            StartKnifeCommand = new StartKnifeCommand(this);
            SwitchSidesCommands = new SwitchSidesCommand(this);
            CustomCommandSend = new CustomCommand(this, CustomCommanLine);
        }

        public ICommand NavigateToServerCommand { get; }

        public ICommand StartServerCommand { get; }

        public ICommand StartGameCommand { get; }

        public ICommand StartOvertimeGameCommand { get; }

        public ICommand StartNadePraticeCommand { get; }

        public ICommand SwitchMapCommand{ get; }

        public ICommand PauseGameCommand { get; }

        public ICommand StartKnifeCommand { get; }

        public ICommand SwitchSidesCommands { get; }

        public ICommand CustomCommandSend { get; }

        public Server Server { get; set; }

        public string ServerName { get => Server.Name; }

        public string ServerStatus
        {
            get => Server.ServerStatus;
            set
            {
                Server.ServerStatus = value;
                OnPropertychanged(nameof(ServerStatus));
            }
        }

        public int PlayersOnline { get => Server.PlayersOnline; }

        public string ConnectionString { get => Server.ConnectionString; }

        private string selectedMap;
        public string SelectedMap
        {
            get { return selectedMap; }
            set
            {
                if (value == "Dust 2")
                {
                    selectedMap = "dust2";
                }
                else
                    selectedMap = value;
            }
        }

        public bool IsMatchPaused
        {
            get { return Server.IsMatchPaused; }
            set
            {
                Server.IsMatchPaused = value;
                OnPropertychanged(nameof(IsMatchPaused));
            }
        }


        public string CustomCommanLine { get; set; }
    }
}
