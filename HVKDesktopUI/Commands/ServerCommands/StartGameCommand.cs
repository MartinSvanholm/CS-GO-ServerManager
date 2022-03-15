using HVKClassLibary.Models;
using HVKClassLibary.Shared;
using HVKDesktopUI.Commands.ServerCommands;
using HVKDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HVKDesktopUI.Commands
{
    public class StartGameCommand : ServerCommandBase
    {
        public StartGameCommand(ServerViewModel serverViewModel) : base (serverViewModel)
        {

        }

        public async override void Execute(object parameter)
        {
            try
            {
                await serverViewModel.Server.SendCommand("exec esportliga_start");
                MessageBox.Show("Kamp startet.");
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Error: {e.Message}.");
            }
        }
    }
}
