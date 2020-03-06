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
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
            this.frameOne = new Rectangle(0, 0, 15, 15);
            this.frameTwo = new Rectangle(15, 0, 15,15);
            this.currentFrame = this.frameTwo;
            this.rotation = rotation;
        }

        private void NextFrame()
        {
            if (this.currentFrame == this.frameOne)
            {
                this.currentFrame = this.frameTwo;
            }
            else
            {
                this.currentFrame = this.frameOne;
            }
        }

        public void Update()
        {
            this.NextFrame();
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            Rectangle dest = new Rectangle((int)location.X - (this.Data.Width / 2), (int)location.Y - (this.Data.Height / 2), this.Data.Width, this.Data.Height);
            float layer = 1 - (1 / dest.Bottom);
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, dest, this.currentFrame, spriteTint, this.rotation, this.origin, SpriteEffects.None, 1.0f);
        }
    }
}