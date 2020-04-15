namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class UnlockedDoorState : IDoorState
    {
        private const string North = "N";
        private const string South = "S";
        private const string East = "E";
        private const string West = "W";

        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;
        private Vector2 location;

        public UnlockedDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case North:
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorDown();
                        location = door.UpScreenLoc;
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        this.door.Physics.CurrentDirection = Physics.Direction.North;
                        break;
                }
                case East:
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorLeft();
                        location = door.RightScreenLoc;
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 7, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        this.door.Physics.CurrentDirection = Physics.Direction.East;
                        break;
                }
                case South:
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorUp();
                        location = door.DownScreenLoc;
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        this.door.Physics.CurrentDirection = Physics.Direction.South;
                        break;
                }
                case West:
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorRight();
                        location = door.LeftScreenLoc;
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        this.door.Physics.CurrentDirection = Physics.Direction.West;
                        break;
                }
            }
        }

        public void Bombed()
        {
        }

        public void Close()
        {
            this.door.Close();
        }

        public void Draw()
        {
            this.sprite.Draw(this.door.Physics.Location, spriteTint, this.door.Physics.Depth);
        }

        public void Open()
        {
        }

        public void Update()
        {
        }
    }
}
