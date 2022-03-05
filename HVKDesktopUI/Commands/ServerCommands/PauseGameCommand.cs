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
            if (_server.IsPaused == false && _server.On == true)
            {
                try
                {
                    await ServerProcessor.SendCommand(_server.Id, "mp_pause_match");
                    _server.IsPaused = true;
                    MessageBox.Show("Kamp sat på pause.");
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Error: {e.Message}.");
                }
            }
            else if (_server.IsPaused == true && _server.On == true)
            {
                try
                {
                    await ServerProcessor.SendCommand(_server.Id, "mp_unpause_match");
                    _server.IsPaused = false;
                    MessageBox.Show("Kamp genoptaget.");
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Error: {e.Message}.");
                }
            }
            else if (_server.On == false)
            {
                MessageBox.Show("Server skal være tændt.");
            }
        }
    }
}
