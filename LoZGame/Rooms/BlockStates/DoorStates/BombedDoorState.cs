using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class BombedDoorState : IDoorState
    {
        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Vector2 location;
        private readonly Color spriteTint = Color.White;
        private readonly Vector2 UpScreenLoc = new Vector2(336, 0);
        private readonly Vector2 RightScreenLoc = new Vector2(784, 208);
        private readonly Vector2 DownScreenLoc = new Vector2(336, 416);
        private readonly Vector2 LeftScreenLoc = new Vector2(0, 208);

        public BombedDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case "N":
                    {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningDown(UpScreenLoc);
                        location = UpScreenLoc;
                        break;
                    }
                case "E":
                    {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningLeft(RightScreenLoc);
                        location = RightScreenLoc;
                        break;
                    }
                case "S":
                    {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningUp(DownScreenLoc);
                        location = DownScreenLoc;
                        break;
                    }
                case "W":
                    {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningRight(LeftScreenLoc);
                        location = LeftScreenLoc;
                        break;
                    }

            }
        }

        public void Bombed()
        {
            Console.WriteLine("Cannot Bomb Bombed Door!");
        }

        public void Close()
{
            Console.WriteLine("Cannot Close Bombed Door!");
        }

        public void Draw()
        {
            this.sprite.Draw(location, spriteTint);
        }

        public void Open()
        {
            Console.WriteLine("Cannot Open Bombed Door!");
        }

        public void Update()
        {
        }
    }
}
