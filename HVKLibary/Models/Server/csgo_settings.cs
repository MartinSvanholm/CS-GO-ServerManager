using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKClassLibary.Models
{
    public class csgo_settings
    {
        private string _rcon;
        public string Rcon
        {
            get { return _rcon; }
            set { _rcon = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _mapgroup_start_map;

        public string Mapgroup_Start_Map
        {
            get { return _mapgroup_start_map; }
            set { _mapgroup_start_map = value; }
        }

    }
}
