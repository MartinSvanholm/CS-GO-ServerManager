using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKClassLibary.Models.Account
{
    public class Account
    {
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                Trace.WriteLine(value);
            }
        }
        private string _email;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                Trace.WriteLine(value);
            }
        }

        private string _password;
    }
}
