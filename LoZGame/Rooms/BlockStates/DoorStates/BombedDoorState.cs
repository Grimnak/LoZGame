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
                        this.FrameSprite = BlockSpriteFactory.Instance.BombedOpeningDown();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.BombedOpeningLeft();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.BombedOpeningUp();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.BombedOpeningRight();
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
