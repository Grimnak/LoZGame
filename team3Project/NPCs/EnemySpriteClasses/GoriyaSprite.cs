using System;
namespace LoZClone
{
    public class UpMovingGoriyaSprite : IEnemySprite
    {
        public IEnemyState state;

        private Texture2D spriteSheet;

        private int currentFrame, totalFrames, frameDelay, frameDelayMax = 15;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle = new Rectangle(400, 240, 80, 80);
        public int health = 2;
        public string direction;

        public UpMovingGoriyaSprite(Texture2D texture, string dir)
        {
            direction = dir;
            spriteSheet = texture;
            currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Color spriteTint)
        {
            /* Hard coded because only two animation states */
            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(60, 59, 15, 17);
            }
            else
            {
                sourceRectangle = new Rectangle(60, 89, 15, 17);
            }
            spriteBatch.Begin();
            sb.Draw(spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
            spriteBatch.End();
        }

        public void moveLeft()
        {
            destinationRectangle.X -= 5;
            if (destinationRectangle.X <= 0)
            {
                destinationRectangle.X == 0;
                state = new RightMovingStalfosState(this);
            }
        }

        public void moveRight()
        {
            destinationRectangle.X += 5;
            if (destinationRectangle.X >= 800)
            {
                destinationRectangle.X == 800;
                state = new DownMovingStalfosState(this);
            }
        }

        public void moveUp()
        {
            destinationRectangle.Y -= 5;
            if (destinationRectangle.Y <= 0)
            {
                destinationRectangle.Y = 0;
                state = new LeftMovingStalfosState(this);
            }
        }

        public void moveDown()
        {
            destinationRectangle.Y += 5;
            if (destinationRectangle.Y >= 480)
            {
                destinationRectangle.Y = 480;
                state = new UpMovingStalfosState(this);
            }
        }

        public void Update()
        {
            frameDelay++;
            if (frameDelay == frameDelayMax)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                frameDelay = 0;
            }
        }

        public void Attack() { }

    }
}
