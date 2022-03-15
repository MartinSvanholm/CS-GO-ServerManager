using HVKClassLibary.Models;
using HVKClassLibary.Shared;
using HVKDesktopUI.Commands.ServerCommands;
using HVKDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace HVKDesktopUI.Commands
{
    public class StartServerCommand : ServerCommandBase
    {
        private Timer timer;

        public StartServerCommand(ServerViewModel serverViewModel) : base(serverViewModel)
        {

        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public async override void Execute(object parameter)
        {
            try
            {
                string result = await serverViewModel.Server.OnOffToggleServer();
                serverViewModel.ServerStatus = serverViewModel.Server.ServerStatus;

                if (serverViewModel.ServerStatus == "Booting")
                {
                    SetTimer();
                }
                MessageBox.Show(result);
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }

        private async void OnTimerEnd(object sender, ElapsedEventArgs e)
        {
            try
            {
                serverViewModel.ServerStatus = await ServerProcessor.CheckServerStatus(serverViewModel.Server.Id);
                timer.Enabled = false;
                timer.Dispose();
                MessageBox.Show($"Server {serverViewModel.ServerStatus}");
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error: {exeption.Message}");
            }
        }

        private void SetTimer()
        {
            timer = new Timer();

            timer.Interval = 20000;
            timer.AutoReset = true;
            timer.Elapsed += OnTimerEnd;

            timer.Enabled = true;
        }
    }
}
