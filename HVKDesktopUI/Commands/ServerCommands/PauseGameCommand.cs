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
    public class PauseGameCommand : ServerCommandBase
    {
        public PauseGameCommand(ServerViewModel serverViewModel) : base (serverViewModel)
        {

        }

        public async override void Execute(object parameter)
        {
            if (serverViewModel.IsMatchPaused == false)
            {
                try
                {
                    serverViewModel.IsMatchPaused = true;
                    await serverViewModel.Server.SendCommand("mp_pause_match");
                    MessageBox.Show("Kamp sat på pause.");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e.Message}.");
                }
            }
            else if (serverViewModel.Server.IsMatchPaused == true)
            {
                try
                {
                    serverViewModel.IsMatchPaused = false;
                    await serverViewModel.Server.SendCommand("mp_unpause_match");
                    MessageBox.Show("Kamp genoptaget.");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e.Message}.");
                }
            }
        }
    }
}
