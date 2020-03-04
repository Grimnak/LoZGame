namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BoomerangProjectileSprite : ISprite
    {

        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle frame;
        private Vector2 origin;
        private Vector2 Size;
        private readonly int scale;
        private readonly int dX;
        private readonly int dY;

        private readonly int instance;
        private float rotation;
        private float layer;

        public Physics Physics { get; set; }

        public BoomerangProjectileSprite(Texture2D texture, SpriteSheetData data, IPlayer player, int scale, int instance)
        {
            this.Texture = texture;
            this.Data = data;
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.frame = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
            this.scale = scale;
            this.instance = instance;
            this.rotation = 0;
            this.layer = 1 / (this.Physics.Location.Y + this.Size.Y);
        }

        private void Rotate()
        {
            this.rotation += MathHelper.PiOver4 / 2;
        }

        public void Update()
        {
            this.Rotate();
            this.layer = 1 / (this.Physics.Location.Y + this.Size.Y);
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.frame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}