using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKClassLibary.Models.DTO_s.Server_DTO
{
    public class ServerDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ip { get; set; }
        public string raw_ip { get; set; }
        public string custom_domain { get; set; }
        public bool on { get; set; }
        public bool booting { get; set; }
        public int players_online { get; set; }
        public string game { get; set; }
        public csgo_settings csgo_settings { get; set; }
        public ports ports { get; set; }
        public teamspeak3_settings teamspeak3_settings { get; set; }
    }
}
