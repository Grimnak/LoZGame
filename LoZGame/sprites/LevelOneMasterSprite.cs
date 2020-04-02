﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LevelOneMasterSprite
    {
        private readonly int screenWidth = LoZGame.Instance.GraphicsDevice.Viewport.X;
        private readonly int screenHeight = LoZGame.Instance.GraphicsDevice.Viewport.Y;
        private Texture2D texture;
        private Rectangle position;
        private int lifeTime;

        public LevelOneMasterSprite(Texture2D texture, Vector2 currentRoomLocation)
        {
            this.texture = texture;
            this.position = new Rectangle((int)currentRoomLocation.X * screenWidth, (int)currentRoomLocation.Y * screenHeight, screenWidth, screenHeight);
            this.lifeTime = 0;
        }

        public void Update(string direction, int transitionSpeed)
        {
            this.lifeTime++;
            if (this.lifeTime < screenHeight && direction == "Up")
            {
                this.position.Y -= transitionSpeed;
            }
            else if (this.lifeTime < screenHeight && direction == "Down")
            {
                this.position.Y += transitionSpeed;
            }
            else if (this.lifeTime < screenWidth && direction == "Left")
            {
                this.position.X -= transitionSpeed;
            }
            else if (this.lifeTime < screenWidth && direction == "Right")
            {
                this.position.X += transitionSpeed;
            }
        }

        public void Draw(Color tint) 
        {
            Rectangle destination = new Rectangle((int)position.X, (int)position.Y, position.Width, position.Height);
            LoZGame.Instance.SpriteBatch.Draw(texture, destination, tint);
        }
    }
}