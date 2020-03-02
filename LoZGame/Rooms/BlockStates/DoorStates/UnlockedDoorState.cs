using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class UnlockedDoorState : IDoorState
    {
        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = Color.White;
        private readonly Vector2 location;
        private readonly Vector2 UpScreenLoc = new Vector2(336, 0);
        private readonly Vector2 RightScreenLoc = new Vector2(784, 208);
        private readonly Vector2 DownScreenLoc = new Vector2(336, 416);
        private readonly Vector2 LeftScreenLoc = new Vector2(0, 208);

        public UnlockedDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case "N":
                {
                    this.sprite = BlockSpriteFactory.Instance.UnlockedDoorDown(UpScreenLoc);
                    location = UpScreenLoc;
                    break;
                }
                case "E":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorLeft(RightScreenLoc);
                        location = RightScreenLoc;
                        break;
                }
                case "S":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorUp(DownScreenLoc);
                        location = DownScreenLoc;
                        break;
                }
                case "W":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorRight(LeftScreenLoc);
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

        public void Draw()
        {
            this.sprite.Draw(location, spriteTint);
        }

        public void Open()
        {
            Console.WriteLine("Cannot Open Unlocked Door!");
        }

        public void Update()
        {
        }
    }
}
