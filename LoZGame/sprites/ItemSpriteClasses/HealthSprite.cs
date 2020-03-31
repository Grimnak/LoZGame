﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class HealthSprite : SpriteEssentials, ISprite
    {
        private const int FrameChange = 10;
        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteData Data;
        private Vector2 origin;
        private float rotation;
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private readonly int scale;

        public HealthSprite(Texture2D texture, SpriteData data, int scale)
        {
            this.Data = data;
            this.Texture = texture;
            this.origin = new Vector2(0, 0);
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
        }

        public void Update()
        {
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            float layer = 1 - (1 / (location.Y + (this.Data.Height * this.scale)));
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.currentFrame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, layer);
        }
    }
}