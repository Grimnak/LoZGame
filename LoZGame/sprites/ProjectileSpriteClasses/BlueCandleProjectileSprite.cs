namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BlueCandleProjectileSprite : ISprite
    {

        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private Rectangle currentFrame;
        private Vector2 origin;
        private Vector2 Size;
        private readonly int scale;
        private float layer;
        private readonly int instance;
        private int rotation;

        public Vector2 Location { get; set; }

        public BlueCandleProjectileSprite(Texture2D texture, SpriteSheetData data, Vector2 loc, string direction, int scale, int instance)
        {
            this.rotation = 0;
            this.Data = data;
            this.Texture = texture;
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.firstFrame = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.secondFrame = new Rectangle(0, this.Data.Height, this.Data.Width, this.Data.Height);
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
            this.currentFrame = this.firstFrame;
            this.scale = scale;
            this.instance = instance;

            this.layer = 1 / (this.Location.Y + this.Size.Y);
        }

        public int Instance => this.instance;

        private void NextFrame()
        {
            if (this.currentFrame == this.firstFrame)
            {
                this.currentFrame = this.secondFrame;
            }
            else
            {
                this.currentFrame = this.firstFrame;
            }
        }

        public void Update()
        {
            this.NextFrame();
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.currentFrame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}