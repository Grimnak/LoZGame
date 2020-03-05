namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombExplosionSprite : ISprite
    {
        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle frameOne;
        private Rectangle frameTwo;
        private Rectangle frameThree;
        private Rectangle currentFrame;
        private Vector2 origin;
        private Vector2 Size;
        private float layer;
        private readonly int scale;
        private readonly float rotation;
        private readonly int instance;
        private Vector2 location;

        public BombExplosionSprite(Texture2D texture, SpriteSheetData data, int scale)
        {
            this.Texture = texture;
            this.Data = data;
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.frameOne = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.frameTwo = new Rectangle(0, this.Data.Height, this.Data.Width, this.Data.Height);
            this.frameThree = new Rectangle(0, this.Data.Height * 2, this.Data.Width, this.Data.Height);
            this.currentFrame = this.frameOne;
            this.scale = scale;
            this.rotation = 0;
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
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
        }

        public void Update()
        {
            this.NextFrame();
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            this.layer = 1 - (1 / (location.Y + this.Size.Y));
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.currentFrame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}