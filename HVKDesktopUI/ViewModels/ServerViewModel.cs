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
            this.server = server;
            this.server.ServerStatusChanged += OnServerStatusChanged;

            NavigateToServerCommand = new NavigateCommand<ServerViewModel>(navigationStore, () => new ServerViewModel(server, navigationStore));

            StartServerCommand = new StartServerCommand(server);
            StartGameCommand = new StartGameCommand(server);
            StartOvertimeGameCommand = new StartOvertimeGameCommand(server);
            StartNadePraticeCommand = new StartNadePraticeCommand(server);
            SwitchMapCommand = new SwitchMapCommand(server, SelectedMap);
            PauseGameCommand = new PauseGameCommand(server);
            StartKnifeCommand = new StartKnifeCommand(server);
            SwitchSidesCommands = new SwitchSidesCommand(server);
            CustomCommandSend = new CustomCommand(server, CustomCommanLine);
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

        public Server server { get; set; }

        public string ServerName { get => server.Name; }

        public string ServerStatus { get => server.ServerStatus; }

        public int PlayersOnline { get => server.PlayersOnline; }

        public string ConnectionString { get => server.ConnectionString; }

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
        public string CustomCommanLine { get; set; }

        private async void OnServerStatusChanged(object sender, EventArgs e)
        {
            server = await ServerProcessor.LoadServer(server.Id);
            OnPropertychanged(nameof(server));
        }
    }
}
