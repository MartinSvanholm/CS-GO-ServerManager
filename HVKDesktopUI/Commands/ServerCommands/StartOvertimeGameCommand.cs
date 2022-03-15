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
    public class StartOvertimeGameCommand : ServerCommandBase
    {
        public StartOvertimeGameCommand(ServerViewModel serverViewModel) : base(serverViewModel)
        {

        }

        public async override void Execute(object parameter)
        {
            try
            {
                await serverViewModel.Server.SendCommand("exec esportliga_start_med_overtime");
                MessageBox.Show("Kamp startet med overtime startet.");
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Error: {e.Message}.");
            }
        }
    }
}
