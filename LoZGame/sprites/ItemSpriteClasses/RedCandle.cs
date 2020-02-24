namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class RedCandle : IItemSprite
    {
        private readonly Texture2D texture;
        private Rectangle currentFrame;
        private readonly int scale;
        private int lifeTime;

        public Vector2 Location { get; set; }

        public RedCandle(Texture2D texture, Vector2 loc, int scale)
        {
            this.texture = texture;
            this.currentFrame = new Rectangle(160, 0, 6, 16);
            this.Location = loc;
            this.scale = scale;
            this.lifeTime = 0;
        }

        public void Update()
        {
            this.lifeTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Location, this.currentFrame, Color.White, 0, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }
    }
}