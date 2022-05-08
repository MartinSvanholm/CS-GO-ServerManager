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
    public class SwitchMapCommand : ServerCommandBase
    {

        public SwitchMapCommand(ServerViewModel serverViewModel) : base(serverViewModel)
        {

        }

        public async override void Execute(object parameter)
        {
            if (serverViewModel.SelectedMap != null)
            {
                try
                {
                    await serverViewModel.Server.SendCommand($"map de_{serverViewModel.SelectedMap.ToLower().Trim()}");
                    MessageBox.Show($"Skifter map til {serverViewModel.SelectedMap.ToLower()}");
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
