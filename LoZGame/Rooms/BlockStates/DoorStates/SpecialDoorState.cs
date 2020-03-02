using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    /*
     * The Player must kill all enemies to open these doors
     */
    public class SpecialDoorState : IDoorState
    {
        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = Color.White;
        private readonly Vector2 location;
        private readonly Vector2 UpScreenLoc = new Vector2(336, 0);
        private readonly Vector2 RightScreenLoc = new Vector2(784, 208);
        private readonly Vector2 DownScreenLoc = new Vector2(336, 416);
        private readonly Vector2 LeftScreenLoc = new Vector2(0, 208);

        public SpecialDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case "N":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorDown(UpScreenLoc);
                        location = UpScreenLoc;
                        break;
                    }
                case "E":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorLeft(RightScreenLoc);
                        location = RightScreenLoc;
                        break;
                    }
                case "S":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorUp(DownScreenLoc);
                        location = DownScreenLoc;
                        break;
                    }
                case "W":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorRight(LeftScreenLoc);
                        location = LeftScreenLoc;
                        break;
                    }
            }
        }

        public void Bombed()
        {
            Console.WriteLine("Cannot Bomb Normal Door!");
        }

        public void Close()
        {
            this.door.Close();
        }

        public void Open()
        {
            this.door.Open();
        }

        public void Draw()
        {
            this.sprite.Draw(location, spriteTint);
        }

        public void Update()
        {
        }
    }
}
