namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FireballSprite : ISprite
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

        public FireballSprite(Texture2D texture, SpriteSheetData data, int scale)
        {
            this.Texture = texture;
            this.Data = data;
            this.scale = (int)(scale * 1.5f);
            this.Size = new Vector2(this.Data.Width * this.scale, this.Data.Height * this.scale);
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
            this.frameOne = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.frameTwo = new Rectangle(this.Data.Width, 0, this.Data.Width, this.Data.Height);
            this.frameThree = new Rectangle(this.Data.Width * 2, 0, this.Data.Width, this.Data.Height);
            this.frameFour = new Rectangle(this.Data.Width * 3, 0, this.Data.Width, this.Data.Height);
            this.currentFrame = this.frameOne;
            this.rotation = 0;
        }

        private void NextFrame()
        {
            if (this.currentFrame == this.frameOne)
            {
                this.currentFrame = this.frameTwo;
            }
            else if (this.currentFrame == this.frameTwo)
            {
                this.currentFrame = this.frameThree;
            }
            else if (this.currentFrame == this.frameThree)
            {
                this.currentFrame = this.frameFour;
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
            this.layer = 1 - (1 / (location.Y + this.Size.Y));
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.currentFrame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}