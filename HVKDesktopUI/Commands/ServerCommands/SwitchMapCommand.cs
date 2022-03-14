﻿using HVKClassLibary.Models;
using HVKClassLibary.Shared;
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
    internal class SwitchMapCommand : CommandBase
    {
        private readonly Server _server;
        private readonly string _map;

        public SwitchMapCommand(Server server, string map)
        {
            _server = server;
            _map = map;
        }

        public async override void Execute(object parameter)
        {
            if (_server.IsOn)
            {
                if (_map != null)
                {
                    try
                    {
                        await _server.SendCommand($"map de_{_map.ToLower()}");
                        MessageBox.Show($"Skifter map til {_map.ToLower()}");
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
            else
            {
                MessageBox.Show("Server skal være tændt.");
            }
        }
    }
}
