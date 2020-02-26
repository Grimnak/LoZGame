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

        private IDoorState state { get; set; } // current state

        public Door(string loc, string starting)
        {
            this.location = loc;
            switch (starting)
            {
                case "locked":
                    this.state = new LockedDoorState(this);
                    break;
                case "special":
                    this.state = new SpecialDoorState(this);
                    break;
                case "bombed":
                    this.state = new HiddenDoorState(this);
                    break;
                default:
                    this.state = new UnlockedDoorState(this);
                    break;
            }
        }

        public void Close()
        {
            this.state = new LockedDoorState(this);
        }

        public void Open()
        {
            this.state = new UnlockedDoorState(this);
        }

        public void Bombed()
        {
            this.state = new BombedDoorState(this);
        }

        public string GetLoc()
        {
            return this.location;
        }
    }
}
