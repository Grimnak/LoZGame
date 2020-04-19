namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BombedDoorState : DoorEssentials, IDoorState
    {
        private static readonly Color ShadowColor = Color.Black;
        private static readonly float ShadowLayer = 0.994f;
        private Texture2D ShadowSprite;
        private Rectangle ShadowSource;

        public BombedDoorState(IDoor door)
        {
            this.Door = door; 
            this.ShadowSprite = new Texture2D(LoZGame.Instance.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            this.ShadowSprite.SetData<Color>(new Color[] { ShadowColor });
            this.ShadowSource = new Rectangle(0, 0, 1, 1);
            switch (door.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.BombedDownDoor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.BombedLeftDoor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.BombedUpDoor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.BombedRightDoor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
            }
        }

        public override void Bombed()
        {
        }

        public override void Close()
        {
        }

        public override void Open()
        {
        }

        public override void DrawFloor()
        {
            LoZGame.Instance.SpriteBatch.Draw(this.ShadowSprite, this.Door.Physics.Bounds, this.ShadowSource, ShadowColor, 0.0f, Vector2.Zero, SpriteEffects.None, ShadowLayer);
        }
    }
}
