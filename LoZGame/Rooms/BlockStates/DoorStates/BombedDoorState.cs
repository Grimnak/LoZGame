namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BombedDoorState : IDoorState
    {
        private const string North = "N";
        private const string South = "S";
        private const string East = "E";
        private const string West = "W";

        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;

        public BombedDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case North:
                {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningDown();
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        this.door.Physics.CurrentDirection = Physics.Direction.North;
                        break;
                }
                case East:
                {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningLeft();
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 7, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        this.door.Physics.CurrentDirection = Physics.Direction.East;
                        break;
                }
                case South:
                {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningUp();
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        this.door.Physics.CurrentDirection = Physics.Direction.South;
                        break;
                }
                case West:
                {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningRight();
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
