namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombProjectileSprite : ISprite
    {
        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle frame;
        private readonly int scale;
        private float rotation;
        private float layer;
        private Vector2 origin;
        private Vector2 Size;

        public BombProjectileSprite(Texture2D texture, SpriteSheetData data, int scale)
        {
            this.Texture = texture;
            this.Data = data;
            this.frame = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
            this.rotation = 0;
            this.scale = scale;
        }

        public void Update()
        {
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            this.layer = 1 - (1 / (location.Y + this.Size.Y));
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.frame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}