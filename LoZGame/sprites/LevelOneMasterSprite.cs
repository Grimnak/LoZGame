namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LevelOneMasterSprite
    {
        private Texture2D texture;
        private int screenWidth = LoZGame.Instance.GraphicsDevice.Viewport.X;
        private int screenHeight = LoZGame.Instance.GraphicsDevice.Viewport.Y;
        private Rectangle position;
        private int lifeTime;

        public LevelOneMasterSprite(Texture2D texture)
        {
            this.texture = texture;
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

        public void CurrentPosition(Vector2 currentRoom)
        {
            this.position = new Rectangle((int)currentRoom.X * screenWidth, (int)currentRoom.Y * screenHeight, screenWidth, screenHeight);
        }
    }
}