namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BombedDoorState : IDoorState
    {
        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;

        public BombedDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case "N":
                {
                    this.sprite = BlockSpriteFactory.Instance.BombedOpeningDown(door.UpScreenLoc);
                    door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y - 12, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.VerticalOffset);
                    break;
                }
                case "E":
                {
                    this.sprite = BlockSpriteFactory.Instance.BombedOpeningLeft(door.RightScreenLoc);
                    door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 7, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.HorizontalOffset, BlockSpriteFactory.Instance.DoorWidth);
                    break;
                }
                case "S":
                {
                    this.sprite = BlockSpriteFactory.Instance.BombedOpeningUp(door.DownScreenLoc);
                    door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.VerticalOffset);
                    break;
                }
                case "W":
                {
                    this.sprite = BlockSpriteFactory.Instance.BombedOpeningRight(door.LeftScreenLoc);
                    door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 19, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.HorizontalOffset, BlockSpriteFactory.Instance.DoorWidth);
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
            this.sprite.Draw(this.door.Physics.Location, spriteTint);
        }

        public void Open()
        {
        }

        public void Update()
        {
        }
    }
}
