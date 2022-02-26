using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKClassLibary.Models
{
    public class Ports
    {
        private int _game;
        public int Game
        {
            get { return _game; }
            set 
            {
                if (value > 9999 && value < 100000)
                {
                    _game = value;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        private int _gotv;
        public int Gotv
        {
            get { return _gotv; }
            set
            {
                if (value > 9999 && value < 100000)
                    _gotv = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
