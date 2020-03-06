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
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;
        private readonly Vector2 location;

        public UnlockedDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case "N":
                {
                    this.sprite = BlockSpriteFactory.Instance.UnlockedDoorDown(door.UpScreenLoc);
                    location = door.UpScreenLoc;
                    door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                    door.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y + 1, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.VerticalOffset);
                    break;
                }
                case "E":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorLeft(door.RightScreenLoc);
                        location = door.RightScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        door.Bounds = new Rectangle((int)door.Physics.Location.X - 12, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.HorizontalOffset, BlockSpriteFactory.Instance.DoorWidth);
                        break;
                }
                case "S":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorUp(door.DownScreenLoc);
                        location = door.DownScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        door.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y - 5, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.VerticalOffset);
                        break;
                }
                case "W":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorRight(door.LeftScreenLoc);
                        location = door.LeftScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        door.Bounds = new Rectangle((int)door.Physics.Location.X + 5, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.HorizontalOffset, BlockSpriteFactory.Instance.DoorWidth);
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
