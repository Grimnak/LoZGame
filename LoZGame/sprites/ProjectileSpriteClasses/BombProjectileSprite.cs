namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombProjectileSprite : ISprite
    {
        private static readonly int LinkSize = 32;
        private static readonly int MaxLife = 120;
        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle frame;
        private int lifeTime;
        private readonly int scale;
        private readonly int instance;
        private float rotation;
        private readonly bool hostile;
        private readonly ExplosionManager explosion;
        private float layer;
        private Vector2 location;
        private Vector2 origin;
        private Vector2 Size;

        public BombProjectileSprite(Texture2D texture, SpriteSheetData data, Vector2 loc, string direction, int scale)
        {
            this.Texture = texture;
            this.Data = data;
            this.frame = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
            this.location = loc;
            this.rotation = 0;

            this.scale = scale;
            this.layer = 1 / (this.location.Y + this.Size.Y);
        }

        public void Update()
        {
            Vector2 explosionRadius = ProjectileSpriteFactory.Instance.ExplosionCenter;
            Vector2 expolsionLoc = new Vector2(this.origin.X - (explosionRadius.X * scale), this.origin.Y - (explosionRadius.Y * scale));
            this.explosion.AddExplosion(this.explosion.Explosion, expolsionLoc);
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.frame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}