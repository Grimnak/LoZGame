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
        private readonly ISprite sprite;
        private readonly Vector2 UpScreenLoc = new Vector2(336, 0);
        private readonly Vector2 RightScreenLoc = new Vector2(784, 208);
        private readonly Vector2 DownScreenLoc = new Vector2(336, 416);
        private readonly Vector2 LeftScreenLoc = new Vector2(0, 208);

        public HiddenDoorState(Door door)
        {
            this.door = door;
            this.sprite = null;
        }

        public void Bombed()
        {
            this.door.Bombed();
        }

        public void Close()
        {
            Console.WriteLine("Cannot Close Hidden Door!");
            throw new NotImplementedException();
        }

        public void Draw()
        {
            // Draw Nothing
        }

        public void Open()
        {
            Console.WriteLine("Cannot Open Hidden Door!");
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
