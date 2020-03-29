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
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;

        public LockedDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case "N":
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorDown(door.UpScreenLoc);
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y - 12, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.VerticalOffset);
                        break;
                    }
                case "E":
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorLeft(door.RightScreenLoc);
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 7, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.HorizontalOffset, BlockSpriteFactory.Instance.DoorWidth);
                        break;
                    }
                case "S":
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorUp(door.DownScreenLoc);
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.VerticalOffset);
                        break;
                    }
                case "W":
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorRight(door.LeftScreenLoc);
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 19, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.HorizontalOffset, BlockSpriteFactory.Instance.DoorWidth);
                        break;
                    }
            }
        }

        public void Bombed()
        {
            this.door.Bombed();
        }

        public void Close()
        {
        }

        public void Open()
        {
            this.door.Open();
        }

        public void Draw()
        {
            this.sprite.Draw(this.door.Physics.Location, spriteTint);
        }

        public void Update()
        {
        }
    }
}
