namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class RaftSprite : ISprite
    {
        private const int DespawnTimer = 1000;
        private const int SpawnTimer = 60;

        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Vector2 origin;
        private float rotation;
        private Rectangle frame;
        private int lifeTime;
        private readonly int scale;

        public RaftSprite(Texture2D texture, SpriteSheetData data, int scale)
        {
            this.Data = data;
            this.Texture = texture;
            this.origin = new Vector2(data.Width / 2, data.Height / 2);
            this.rotation = 0;
            this.frame = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.scale = scale;
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > DespawnTimer)
            {
                this.lifeTime = 0;
            }
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            if (this.lifeTime > SpawnTimer || this.lifeTime % 5 <= 2)
            {
                float layer = 1 / (location.Y + (this.Data.Height * this.scale));
                LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.frame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, layer);
            }
        }
    }
}