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
        public CustomCommand(ServerViewModel serverViewModel, string command) : base(serverViewModel)
        {
            this.command = command;
        }

        private readonly string command;

        public async override void Execute(object parameter)
        {
            Trace.WriteLine(command);
            if (command != null && command != "")
            {
                try
                {
                    await serverViewModel.Server.SendCommand(command);
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
