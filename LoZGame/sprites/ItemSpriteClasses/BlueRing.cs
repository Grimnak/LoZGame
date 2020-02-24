namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BlueRing : IItemSprite
    {
        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private readonly int scale;

        public Vector2 Location { get; set; }

        public BlueRing(Texture2D texture, Vector2 loc, int scale)
        {
            this.texture = texture;
            this.frame = new Rectangle(169, 16, 7, 16);
            this.lifeTime = 0;
            this.Location = loc;
            this.scale = scale;
        }

        public void Update()
        {
            this.lifeTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.frame.Width * this.scale, this.frame.Height * this.scale);
            spriteBatch.Draw(this.texture, dest, this.frame, Color.White);
        }
    }
}