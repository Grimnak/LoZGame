﻿using System;

public class WallMasterSprite
{
    public class WallMasterSprite : IEnemySprite
    {
        public IEnemyState state;

        private Texture2D spriteSheet;

        private int currentFrame, totalFrames, frameDelay, frameDelayMax = 15;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle = new Rectangle(400, 240, 80, 80);
        public int health = 2;
        public string direction;

        public WallMasterSprite(Texture2D texture, string dir)
        {
            direction = dir;
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
        public void moveLeft()
        {
            destinationRectangle.X -= 5;
            if (destinationRectangle.X <= 0)
            {
                destinationRectangle.X == 0;
                state = new RightMovingWallMasterState(this);
            }
        }

        public void moveRight()
        {
            destinationRectangle.X += 5;
            if (destinationRectangle.X >= 800)
            {
                destinationRectangle.X == 800;
                state = new DownMovingWallMasterState(this);
            }
        }

        public void moveUp()
        {
            destinationRectangle.Y -= 5;
            if (destinationRectangle.Y <= 0)
            {
                destinationRectangle.Y = 0;
                state = new LeftMovingWallMasterState(this);
            }
        }

        public void moveDown()
        {
            destinationRectangle.Y += 5;
            if (destinationRectangle.Y >= 480)
            {
                destinationRectangle.Y = 480;
                state = new UpMovingWallMasterState(this);
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

