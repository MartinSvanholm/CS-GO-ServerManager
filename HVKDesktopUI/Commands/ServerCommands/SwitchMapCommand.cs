using HVKClassLibary.Models;
using HVKClassLibary.Shared;
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
    internal class SwitchMapCommand : CommandBase
    {
        private readonly Server _server;

        public SwitchMapCommand(Server server)
        {
            _server = server;
        }

        public async override void Execute(object parameter)
        {
            try
            {
                await ServerProcessor.SendCommand(_server.Id, $"map de_{_server.SwitchToMap.Name.ToLower()}");
                MessageBox.Show($"Skifter map til {_server.SwitchToMap.Name.ToLower()}");
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }
    }
}
