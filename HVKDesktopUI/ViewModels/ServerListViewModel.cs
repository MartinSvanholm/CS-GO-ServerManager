using HVKClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HVKClassLibary.Shared;
using System.Diagnostics;
using HVKDesktopUI.Commands;
using HVKDesktopUI.Stores;
using System.Windows.Controls;
using System.Windows;
using System.Net.Http;

namespace HVKDesktopUI.ViewModels
{
    public class ServerListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ServerViewModel> _servers;

        public IEnumerable<ServerViewModel> Servers => _servers;
        public ICommand NavigateToServerListCommand { get; }
        public ICommand NavigateToHomepage { get; }

        private readonly NavigationStore _navigationStore;

        private List<Server> ServerList = new();

        public ServerListViewModel(NavigationStore navigationStore)
        {
            _servers = new ObservableCollection<ServerViewModel>();
            var task = GetServersAsync();
            _navigationStore = navigationStore;
            NavigateToServerListCommand = new NavigateCommand<ServerListViewModel>(_navigationStore, () => new ServerListViewModel(_navigationStore));
            NavigateToHomepage = new NavigateCommand<HomeViewModel>(_navigationStore, () => new HomeViewModel(_navigationStore));
        }

        public async Task GetServersAsync()
        {
            try
            {
                ServerList = await ServerProcessor.LoadServers();

                foreach (Server server in ServerList)
                {
                    _servers.Add(new ServerViewModel(server, _navigationStore));
                }
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Error: {e.Message}");
                NavigateToHomepage.Execute(this);
            }
        }
    }
}
