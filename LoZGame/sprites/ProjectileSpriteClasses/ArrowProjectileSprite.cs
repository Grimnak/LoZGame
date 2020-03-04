namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class ArrowProjectileSprite : ISprite
    {
        private static readonly int Speed = 10;
        private static readonly int LinkSize = 30;

        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle frame;
        private Vector2 origin;
        private readonly int scale;
        private readonly string direction;
        private readonly float rotation;
        private float layer;
        private Vector2 size;
        private Vector2 location;

        public ArrowProjectileSprite(Texture2D texture, SpriteSheetData data, Vector2 loc, string direction, int scale)
        {
            this.Texture = texture;
            this.Data = data;
            this.location = loc;
            this.size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.frame = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
            this.scale = scale;
            this.direction = direction;
        }

        public void Update()
        {
            this.layer = 1 / (this.location.Y + this.size.Y);
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.frame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}