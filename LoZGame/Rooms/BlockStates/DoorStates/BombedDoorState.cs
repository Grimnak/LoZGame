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
            Door = door; 
            ShadowSprite = new Texture2D(LoZGame.Instance.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            ShadowSprite.SetData<Color>(new Color[] { ShadowColor });
            ShadowSource = new Rectangle(0, 0, 1, 1);
            switch (door.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.BombedDownDoor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.BombedLeftDoor();
                        OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.BombedUpDoor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.BombedRightDoor();
                        OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
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
            LoZGame.Instance.SpriteBatch.Draw(ShadowSprite, Door.Physics.Bounds, ShadowSource, ShadowColor, 0.0f, Vector2.Zero, SpriteEffects.None, ShadowLayer);
        }
    }
}
