using HVKClassLibary.Models;
using HVKDesktopUI.Commands;
using HVKDesktopUI.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HVKDesktopUI.ViewModels
{
    public class ServerViewModel : ViewModelBase
    {
        public ServerViewModel(Server server, NavigationStore navigationStore)
        {
            _server = server;

            StartServerCommand = new StartServerCommand(_server);
            StartGameCommand = new StartGameCommand(_server);
            StartNadePraticeCommand = new StartNadePraticeCommand(_server);
            NavigateToServerCommand = new NavigateCommand<ServerViewModel>(navigationStore, () => new ServerViewModel(_server, navigationStore));
            SwitchMapCommand = new SwitchMapCommand(_server);
        }

        public ICommand NavigateToServerCommand { get; }

        public ICommand StartServerCommand { get; }

        public ICommand StartGameCommand { get; }

        public ICommand StartNadePraticeCommand { get; }

        public ICommand SwitchMapCommand{ get; }

        private Server _server;

        public string ID => _server.Id;

        public string Name => _server.Name;

        public string PlayersOnline => _server.Players_Online.ToString();

        private string _connectIP { get; set; }
        public string ConnectIP
        {
            get => $"connect {_server.Ip}:{_server.Ports.Game}{GetPassword()}";
            set { _connectIP = value; }
        }

        public Map SwitchToMap
        {
            get => _server.SwitchToMap;
            set
            {
                _server.SwitchToMap = value;
            }
        }

        public List<Map> Maps => _server.Maps;

        public string On => GetStatus();

        public string ControlButtonText => GetButtonText();

        public string GetPassword()
        {
            if (_server.Csgo_Settings.Password != "")
            {
                return $"; password {_server.Csgo_Settings.Password}";
            }
            else
                return string.Empty;
        }

        public string GetStatus()
        {
            if (_server.On == true)
                return "Online";
            else
                return "Offline";
        }

        public string GetButtonText()
        {
            if (_server.On == true)
                return "Sluk server";
            else
                return "Start server";
        }
    }
}
