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
        public Server(string id, string name, string connectionString, int playersOnline, string serverSatus)
        {
            Id = id;
            Name = name;
            ConnectionString = connectionString;
            this.serverSatus = serverSatus;
            PlayersOnline = playersOnline;
        }

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

        private bool isMatchPaused;
        public bool IsMatchPaused
        {
            get { return isMatchPaused; }
            set
            {
                if (ServerStatusToIsOnConverter() == true)
                    isMatchPaused = value;
                else
                    throw new ArgumentException("Kamp kan ikke pauses når serveren er offline");
            }
        }

        public async Task<string> OnOffToggleServer()
        {
            if (ServerStatusToIsOnConverter() == true)
            {
                try
                {
                    await ServerProcessor.ServerAction(Id, "stop");
                    ServerStatus = "Offline";
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
                    await ServerProcessor.ServerAction(Id, "start");
                    ServerStatus = "Booting";
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

        private bool ServerStatusToIsOnConverter()
        {
            switch (ServerStatus)
            {
                case "Booting":
                    return false;
                case "Online":
                    return true;
                case "Offline":
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ServerStatus));
            }
        }
    }
}
