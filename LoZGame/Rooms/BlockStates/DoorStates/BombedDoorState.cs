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
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;

        public BombedDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case "N":
                    {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningDown(door.UpScreenLoc);
                        location = door.UpScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        door.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y - 12, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.VerticalOffset);
                        break;
                    }
                case "E":
                    {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningLeft(door.RightScreenLoc);
                        location = door.RightScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        door.Bounds = new Rectangle((int)door.Physics.Location.X - 7, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.HorizontalOffset, BlockSpriteFactory.Instance.DoorWidth);
                        break;
                    }
                case "S":
                    {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningUp(door.DownScreenLoc);
                        location = door.DownScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        door.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.VerticalOffset);
                        break;
                    }
                case "W":
                    {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningRight(door.LeftScreenLoc);
                        location = door.LeftScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        door.Bounds = new Rectangle((int)door.Physics.Location.X - 19, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.HorizontalOffset, BlockSpriteFactory.Instance.DoorWidth);
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
