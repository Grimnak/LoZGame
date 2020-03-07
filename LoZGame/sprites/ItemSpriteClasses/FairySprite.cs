namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    // Class to handle the completely stationary sprite
    internal class FairySprite : ISprite
    {
        
        

        private static readonly int FrameChange = 10;
        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Vector2 origin;
        private Vector2 Size;
        private float rotation;
        private Rectangle firstFrame;   // frames
        private Rectangle secondFrame;
        private Rectangle currentFrame; // frame to draw
        private readonly int scale;
        private int lifeTime;

        public Physics Physics { get; set; }

        public FairySprite(Texture2D texture, SpriteSheetData data, int scale)
        {
            this.Data = data;
            this.Texture = texture;
            this.origin = new Vector2(0, 0);
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Width * scale);
            this.rotation = 0;
            this.firstFrame = new Rectangle(0, 0, data.Width, data.Height);
            this.secondFrame = new Rectangle(0, data.Height, data.Width, data.Height);
            this.currentFrame = this.firstFrame;
            this.lifeTime = 0;
            this.scale = scale;
        }

        private void NextFrame()
        {
            if (this.currentFrame == this.firstFrame)
            {
                this.currentFrame = this.secondFrame;
            }
            else
            {
                this.currentFrame = this.firstFrame;
            }
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime % FrameChange == 0)
            {
                this.NextFrame();
            }
        }

        public void Draw(Vector2 location, Color spriteTint)
        {

            float layer = 1 - (1 / (location.Y + (this.Data.Height * this.scale)));
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.currentFrame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, layer);
        }
    }
}