namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class HeartContainerSprite : SpriteEssentials, ISprite
    {
        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteData Data;
        private Vector2 origin;
        private float rotation;
        private Rectangle frame;
        private int lifeTime;
        private readonly int scale;

        public HeartContainerSprite(Texture2D texture, SpriteData data, int scale)
        {
            this.Data = data;
            this.Texture = texture;
            this.origin = new Vector2(0, 0);
            this.rotation = 0;
            this.frame = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.scale = scale;
        }

        public void Update()
        {
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            float layer = 1 - (1 / (location.Y + (this.Data.Height * this.scale)));
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.frame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, layer);
        }
    }
}