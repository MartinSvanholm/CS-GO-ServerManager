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
        private ServerViewModel ServerViewModel;

        public StartServerCommand(ServerViewModel serverViewModel)
        {
            ServerViewModel = serverViewModel;
        }

        public async override void Execute(object parameter)
        {
            if (ServerViewModel._server.On)
            {
                Trace.WriteLine("Server on");
                try
                {
                    await ServerProcessor.ServerSpecificAction(ServerViewModel._server.Id, "stop");
                    MessageBox.Show("Server stoppet");
                    ServerViewModel.IsOnline = false;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Error: {e.Message}");
                }
            }
            else
            {
                Trace.WriteLine("Server off");
                try
                {
                    await ServerProcessor.ServerSpecificAction(ServerViewModel._server.Id, "start");
                    MessageBox.Show("Server starter, der kan gå op til 60 sekunder før du kan joine serveren");
                    ServerViewModel.IsOnline = true;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Error: {e.Message}");
                }
            }
        }
    }
}
