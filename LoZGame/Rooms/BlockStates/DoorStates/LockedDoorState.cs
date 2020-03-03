using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class LockedDoorState : IDoorState
    {
        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Vector2 location;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;

        public LockedDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case "N":
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorDown(door.UpScreenLoc);
                        location = door.UpScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        door.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, 70, 1);
                        break;
                    }
                case "E":
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorLeft(door.RightScreenLoc);
                        location = door.RightScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        door.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, 1, 70);
                        break;
                    }
                case "S":
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorUp(door.DownScreenLoc);
                        location = door.DownScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        door.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, 70, 1);
                        break;
                    }
                case "W":
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorRight(door.LeftScreenLoc);
                        location = door.LeftScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        door.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, 1, 70);
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
            Console.WriteLine("Cannot Close Locked Door!");
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
