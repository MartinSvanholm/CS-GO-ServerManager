using HVKClassLibary.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Timers;

namespace HVKClassLibary.Models
{
    public class Server
    {
        public Server(string id, string name, string connectionString, int playersOnline, string serverSatus, bool isOn)
        {
            Id = id;
            Name = name;
            ConnectionString = connectionString;
            this.serverSatus = serverSatus;
            PlayersOnline = playersOnline;
            IsOn = isOn;

            Timer = new System.Timers.Timer(30000);
            Timer.Elapsed += OnTimedEvent;
        }

        public event EventHandler ServerStatusChanged;

        private static System.Timers.Timer Timer;

        public string Id { get; }

        public string Name { get; }

        public string ConnectionString { get; }

        private string serverSatus;
        public string ServerStatus
        {
            get { return serverSatus; }
            set
            {
                if (value == "Online" || value == "Offline" || value == "Booting")
                {
                    serverSatus = value;
                }
                else
                    throw new ArgumentException($"Server status cannot be {value}");
            }
        }
        
        public int PlayersOnline { get; }

        private bool isOn;
        public bool IsOn
        {
            get => isOn;
            set => isOn = value;
        }

        private bool isMatchPaused;
        public bool IsMatchPaused
        {
            get { return isMatchPaused; }
            set
            {
                if (IsOn == true)
                    isMatchPaused = value;
                else
                    throw new ArgumentException("Kamp kan ikke pauses når serveren er offline");
            }
        }

        public async Task<string> OnOffToggleServer()
        {
            if (IsOn == true)
            {
                try
                {
                    await ServerProcessor.ServerSpecificAction(Id, "stop");
                    ServerStatusChanged.Invoke(this, EventArgs.Empty);
                    return "Server stoppet.";
                }
                catch (HttpRequestException)
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    await ServerProcessor.ServerSpecificAction(Id, "start");
                    ServerStatusChanged.Invoke(this, EventArgs.Empty);
                    Timer.Start();
                    return "Server startet.";
                }
                catch (HttpRequestException)
                {
                    throw;
                }
            }
        }

        public async Task SendCommand(string command)
        {
            try
            {
                await ServerProcessor.SendCommand(Id, command);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            ServerStatusChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
