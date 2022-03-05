﻿using HVKClassLibary.Models;
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
    public class StartOvertimeGameCommand : CommandBase
    {
        private readonly Server _server;

        public StartOvertimeGameCommand(Server server)
        {
            _server = server;
        }

        public async override void Execute(object parameter)
        {
            if (_server.On)
            {
                try
                {
                    await ServerProcessor.SendCommand(_server.Id, "exec esportliga_start");
                    MessageBox.Show("Kamp startet.");
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Error: {e.Message}.");
                }
            }
            else
            {
                MessageBox.Show("Server skal være tændt.");
            }
        }
    }
}