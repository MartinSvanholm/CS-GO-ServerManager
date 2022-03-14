using HVKClassLibary.Models;
using HVKClassLibary.Shared;
using HVKDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HVKDesktopUI.Commands
{
    public class StartServerCommand : CommandBase
    {
        private readonly Server _server;

        public StartServerCommand(Server server)
        {
            _server = server;
        }
       
        public async override void Execute(object parameter)
        {
            try
            {
                await _server.OnOffToggleServer();
                MessageBox.Show("Server stoppet");
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }
    }
}
