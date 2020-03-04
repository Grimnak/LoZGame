using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class HiddenDoorState : IDoorState
    {
        private readonly Door door;

        public HiddenDoorState(Door door)
        {
            this.door = door;
        }

        public void Bombed()
        {
            this.door.Bombed();
        }

        public void Close()
        {
            Console.WriteLine("Cannot Close Hidden Door!");
        }

        public void Draw()
        {
            // Draw Nothing
        }

        public void Open()
        {
            Console.WriteLine("Cannot Open Hidden Door!");
        }

        public void Update()
        {
        }
    }
}
