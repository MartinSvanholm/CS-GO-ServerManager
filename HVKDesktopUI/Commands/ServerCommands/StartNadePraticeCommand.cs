using HVKClassLibary.Models;
using HVKClassLibary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HVKDesktopUI.Commands
{
    public class StartNadePraticeCommand : CommandBase
    {
        private readonly Server _server;

        public StartNadePraticeCommand(Server server)
        {
            _server = server;
        }
        public async override void Execute(object parameter)
        {
            if (_server.On)
            {
                try
                {
                    await ServerProcessor.SendCommand(_server.Id, "exec train");
                    MessageBox.Show("Nade practice startet.");
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Error: {e.Message}");
                }
            }
            else
            {
                MessageBox.Show("Server skal være tændt.");
            }
        }
    }
}
