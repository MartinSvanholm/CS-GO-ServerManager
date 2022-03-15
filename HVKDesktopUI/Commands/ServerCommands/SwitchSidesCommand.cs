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

namespace HVKDesktopUI.Commands.ServerCommands
{
    public class SwitchSidesCommand : ServerCommandBase
    {
        public SwitchSidesCommand(ServerViewModel serverViewModel) : base(serverViewModel)
        {

        }

        public async override void Execute(object parameter)
        {
            try
            {
                await serverViewModel.Server.SendCommand("mp_swapteams");
                MessageBox.Show("Sider skiftet.");
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Error: {e.Message}.");
            }
        }
    }
}