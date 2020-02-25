using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class Door 
    {
        private string location; // relative location on screen

        private string state { get; set; } // current state

        public Door(string loc, string starting)
        {
            this.location = loc;
            this.state = starting;
        }

    }
}
