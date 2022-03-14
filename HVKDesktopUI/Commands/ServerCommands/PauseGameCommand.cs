using HVKClassLibary.Models;
using HVKClassLibary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HVKDesktopUI.Commands.ServerCommands
{
    public class PauseGameCommand : CommandBase
    {
        private readonly Server _server;

        public PauseGameCommand(Server server)
        {
            _server = server;
        }

        public async override void Execute(object parameter)
        {
            if (_server.IsMatchPaused == false && _server.IsOn == true)
            {
                try
                {
                    _server.IsMatchPaused = true;
                    await _server.SendCommand("mp_pause_match");
                    MessageBox.Show("Kamp sat på pause.");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e.Message}.");
                }
            }
            else if (_server.IsMatchPaused == true && _server.IsOn == true)
            {
                try
                {
                    _server.IsMatchPaused = false;
                    await _server.SendCommand("mp_unpause_match");
                    MessageBox.Show("Kamp genoptaget.");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e.Message}.");
                }
            }
            else if (_server.IsOn == false)
            {
                MessageBox.Show("Server skal være tændt.");
            }
        }
    }
}
