namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class LockedDoorState : IDoorState
    {
        private const string North = "N";
        private const string South = "S";
        private const string East = "E";
        private const string West = "W";

        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;

        public LockedDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case North:
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorDown();
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        break;
                    }
                case East:
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorLeft();
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 7, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        break;
                    }
                case South:
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorUp();
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        break;
                    }
                case West:
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorRight();
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
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
            this.sprite.Draw(this.door.Physics.Location, spriteTint, this.door.Physics.Depth);
        }

        public void Update()
        {
        }
    }
}
