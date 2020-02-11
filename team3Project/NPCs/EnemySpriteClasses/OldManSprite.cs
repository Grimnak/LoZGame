using System;

public class OldManSprite
{
    public class OldManSprite : IEnemySprite
    {
        private Texture2D spriteSheet;

        private int currentFrame, totalFrames, frameDelay, frameDelayMax = 15;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle = new Rectangle(400, 240, 80, 80);

        public OldManSprite(Texture2D texture)
        {
            state = new DownMovingOldManState(this);
            spriteSheet = texture;
            currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Color spriteTint)
        {
            /* CHANGING */
            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(420, 120, 15, 12);
            }
            else
            {
                sourceRectangle = new Rectangle(420, 150, 15, 12);
            }
            spriteBatch.Begin();
            sb.Draw(spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
            spriteBatch.End();
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
