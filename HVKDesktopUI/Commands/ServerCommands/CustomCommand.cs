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

namespace HVKDesktopUI.Commands.ServerCommands
{
    public class CustomCommand : ServerCommandBase
    {
        public CustomCommand(ServerViewModel serverViewModel) : base(serverViewModel)
        {

        }

        public async override void Execute(object parameter)
        {
            Trace.WriteLine(serverViewModel.CustomCommandLine);
            if (serverViewModel.CustomCommandLine != null && serverViewModel.CustomCommandLine != "")
            {
                try
                {
                    await serverViewModel.Server.SendCommand(serverViewModel.CustomCommandLine);
                    MessageBox.Show("Command udført.");
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Error: {e.Message}.");
                }
            }
            else
            {
                MessageBox.Show("Skriv en command først");
            }
        }
    }
}
