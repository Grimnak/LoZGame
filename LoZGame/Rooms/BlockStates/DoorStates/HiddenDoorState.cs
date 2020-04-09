﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class HiddenDoorState : IDoorState
    {
        private readonly Door door;

        public HiddenDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case "N":
                    {
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y - 12, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        break;
                    }
                case "E":
                    {
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 7, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        break;
                    }
                case "S":
                    {
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        break;
                    }
                case "W":
                    {
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 20, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
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

        public void Draw()
        {
        }

        public void Open()
        {
        }

        public void Update()
        {
        }
    }
}
