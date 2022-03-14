using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKClassLibary.Models.DTO_s.Server_DTO
{
    public class csgo_settings
    {
        public bool disable_bots { get; set; }
        public bool enable_gotv { get; set; }
        public string game_mode { get; set; }
        public string password { get; set; }
        public string rcon { get; set; }
        public string tickrate { get; set; }
    }
}
