namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class GreenWoodSwordSprite : ISprite
    {
        private readonly Texture2D Texture;
        private readonly SpriteSheetData Data;
        private Rectangle frameOne;
        private Rectangle frameTwo;
        private Rectangle frameThree;
        private Rectangle frameFour;
        private Rectangle currentFrame;
        private readonly int scale;
        private readonly float rotation;
        private float layer;
        private Vector2 origin;
        private Vector2 Size;

        public GreenWoodSwordSprite(Texture2D texture, SpriteSheetData data, float rotation)
        {
            this.Texture = texture;
            this.Data = data;
            this.Size = new Vector2(this.Data.Width, this.Data.Height);
            this.origin = new Vector2(7.5f, 7.5f);
            this.frameOne = new Rectangle(0, 0, 15, 15);
            this.frameTwo = new Rectangle(15, 0, 15, 15);
            this.currentFrame = Rectangle.Empty;
            this.rotation = rotation;
        }

        private void NextFrame()
        {
            if (this.currentFrame == this.frameTwo)
            {
                this.currentFrame = this.frameOne;
            }
            else
            {
                this.currentFrame = this.frameTwo;
            }
        }

        public void Update()
        {
            this.NextFrame();
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            Rectangle dest = new Rectangle((int)location.X - (this.Data.Width / 2), (int)location.Y - (this.Data.Height / 2), this.Data.Width, this.Data.Height);
            float layer = 1 - (1 / (location.Y + this.Data.Height));
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, dest, this.currentFrame, spriteTint, this.rotation, this.origin, SpriteEffects.None, layer);
        }
    }
}