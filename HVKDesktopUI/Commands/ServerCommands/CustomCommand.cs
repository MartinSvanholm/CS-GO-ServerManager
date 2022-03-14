using HVKClassLibary.Models;
using HVKClassLibary.Shared;
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
    public class CustomCommand : CommandBase
    {
        public CustomCommand(Server server, string command)
        {
            _server = server;
            _command = command;
        }

        private readonly Server _server;
        private readonly string _command;

        public async override void Execute(object parameter)
        {
            if (_server.IsOn)
            {
                Trace.WriteLine(_command);
                if (_command != null && _command != "")
                {
                    try
                    {
                        await _server.SendCommand(_command);
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
            else
            {
                MessageBox.Show("Server skal være tændt.");
            }
        }
    }
}
