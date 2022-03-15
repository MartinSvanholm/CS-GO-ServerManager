using HVKClassLibary.Models;
using HVKClassLibary.Shared;
using HVKDesktopUI.Commands.ServerCommands;
using HVKDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HVKDesktopUI.Commands
{
    internal class SwitchMapCommand : ServerCommandBase
    {
        private readonly string _map;

        public SwitchMapCommand(ServerViewModel serverViewModel, string map) : base(serverViewModel)
        {
            _map = map;
        }

        public async override void Execute(object parameter)
        {
            if (_map != null)
            {
                try
                {
                    await serverViewModel.Server.SendCommand($"map de_{_map.ToLower()}");
                    MessageBox.Show($"Skifter map til {_map.ToLower()}");
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Error: {e.Message}");
                }
            }
            else
            {
                MessageBox.Show($"Vælg et map først.");
            }
        }
    }
}
