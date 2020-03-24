namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamExplosionSprite : ISprite
    {
        private static readonly int FrameChange = 10;

        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle frameOne;
        private Rectangle frameTwo;
        private Rectangle frameThree;
        private Rectangle frameFour;
        private Rectangle currentFrame;
        private int lifeTime;
        private readonly int scale;
        private readonly string direction;
        private readonly float rotation;
        private float layer;
        private readonly SpriteEffects effect;
        private Vector2 origin;
        private Vector2 Size;

        public SwordBeamExplosionSprite(Texture2D texture, SpriteSheetData data, SpriteEffects effect, int scale)
        {
            this.Data = data;
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.Texture = texture;
            this.frameOne = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.frameTwo = new Rectangle(0, this.Data.Height, this.Data.Width, this.Data.Height);
            this.frameThree = new Rectangle(0, this.Data.Height * 2, this.Data.Width, this.Data.Height);
            this.frameFour = new Rectangle(0, this.Data.Height * 3, this.Data.Width, this.Data.Height);
            this.currentFrame = this.frameOne;
            this.scale = scale;
            this.effect = effect;
            this.rotation = 0.0f;
            this.origin = Vector2.Zero;
        }

        private void NextFrame()
        {
            if (this.currentFrame == this.frameOne)
            {
                this.currentFrame = this.frameTwo;
            }
            else if (this.currentFrame == this.frameTwo)
            {
                this.currentFrame = this.frameThree;
            }
            else if (this.currentFrame == this.frameThree)
            {
                this.currentFrame = this.frameFour;
            }
            else
            {
                this.currentFrame = this.frameOne;
            }
        }

        public void Update()
        {
            this.NextFrame();
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.currentFrame, spriteTint, this.rotation, this.origin, this.scale, this.effect, 1.0f);
        }
    }
}