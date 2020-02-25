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
        private readonly IBlockSprite sprite;
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
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningUp(UpScreenLoc);
                        break;
                    }
                case "E":
                    {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningRight(RightScreenLoc);
                        break;
                    }
                case "S":
                    {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningDown(DownScreenLoc);
                        break;
                    }
                case "W":
                    {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningLeft(LeftScreenLoc);
                        break;
                    }

            }
        }

        public void Bombed()
        {
            Console.WriteLine("Cannot Bomb Bombed Door!");
            throw new NotImplementedException();
        }

        public void Close()
{
            Console.WriteLine("Cannot Close Bombed Door!");
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
            throw new NotImplementedException();
        }

        public void Open()
        {
            Console.WriteLine("Cannot Open Bombed Door!");
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
