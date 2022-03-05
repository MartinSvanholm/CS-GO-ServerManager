using HVKClassLibary.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKClassLibary.Models
{
    public class Server
    {
        public Server(string name)
        {
            Name = name;
        }

        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Ports _ports;
        public Ports Ports
        {
            get { return _ports; }
            set { _ports = value; }
        }

        private csgo_settings _csgo_Settings;
                
        public csgo_settings Csgo_Settings
        {
            get { return _csgo_Settings; }
            set { _csgo_Settings = value; }
        }

        private string _name { get; set; }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _playersOnline;
        public int Players_Online
        {
            get { return _playersOnline; }
            set { _playersOnline = value; }
        }

        private string _ip;
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private bool _on;

        public bool On
        {
            get { return _on; }
            set { _on = value; }
        }

        private bool isPaused = false;

        public bool IsPaused
        {
            get { return isPaused; }
            set { isPaused = value; }
        }


        public List<Map> Maps { get; } = new List<Map> { 
            new Map("Inferno"),
            new Map("Mirage"),
            new Map("Overpass"),
            new Map("Nuke"),
            new Map("Vertigo"),
            new Map("Dust 2"),
            new Map("Ancient") };

        private Map _switchToMap { get; set; }

        public Map SwitchToMap
        {
            get => _switchToMap;
            set
            {
                _switchToMap = value;
                Trace.WriteLine($"map de_{_switchToMap.Name.ToLower()}");
            }
        }
    }
}
