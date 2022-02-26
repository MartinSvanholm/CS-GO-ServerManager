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
    public class StartServerCommand : CommandBase
    {
        private Server _server;

        public StartServerCommand(Server server)
        {
            _server = server;
        }

        public async override void Execute(object parameter)
        {
            if (_server.On)
            {
                try
                {
                    await ServerProcessor.ServerSpecificAction(_server.Id, "stop");
                    MessageBox.Show("Server stoppet");
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Error: {e.Message}");
                }
            }
            else
            {
                try
                {
                    await ServerProcessor.ServerSpecificAction(_server.Id, "start");
                    MessageBox.Show("Server starter, der kan gå op til 60 sekunder før du kan joine serveren");
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Error: {e.Message}");
                }
            }
        }
    }
}
