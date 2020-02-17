using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    // Class to handle the completely stationary sprite
    class Fairy : IItemSprite
    {
        private static int directionChange = 40;
        private static int frameChange = 10;
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle firstFrame;   // frames
        private Rectangle secondFrame;
        private Rectangle currentFrame; // frame to draw
        private int scale;
        private enum direction { North, South, East, West, NorthEast, NorthWest, SouthEast, SouthWest };
        private direction currentDirection;
        public Vector2 location { get; set; }
        private int lifeTime;

        public Fairy(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;                          // assigns texture to passed texture
            firstFrame = new Rectangle(40, 0, 8, 16);
            secondFrame = new Rectangle(48, 0, 8, 16);
            currentFrame = firstFrame;
            lifeTime = 0;
            this.scale = scale;
            location = loc;
            this.getNewDirection();
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            currentDirection = (direction)(randomselect.Next(0, 8));
        }

        private void updateLoc()
        {
            switch (this.currentDirection)
            {
                case direction.North:
                    this.location = new Vector2(this.location.X, this.location.Y - 1);
                    break;
                case direction.South:
                    this.location = new Vector2(this.location.X , this.location.Y + 1);
                    break;
                case direction.East:
                    this.location = new Vector2(this.location.X + 1, this.location.Y);
                    break;
                case direction.West:
                    this.location = new Vector2(this.location.X - 1, this.location.Y);
                    break;
                case direction.NorthEast:
                    this.location = new Vector2(this.location.X + 1, this.location.Y - 1);
                    break;
                case direction.NorthWest:
                    this.location = new Vector2(this.location.X - 1, this.location.Y - 1);
                    break;
                case direction.SouthEast:
                    this.location = new Vector2(this.location.X + 1, this.location.Y + 1);
                    break;
                case direction.SouthWest:
                    this.location = new Vector2(this.location.X - 1, this.location.Y + 1);
                    break;
                default:
                    break;
            }
            this.checkBorder();
        }
        private void checkBorder()
        {
            if (this.location.Y < 0)
            {
                this.location = new Vector2(this.location.X, 0);
                this.lifeTime = directionChange + 1;
            }
            if (this.location.Y > 480 - currentFrame.Height*scale)
            {
                this.location = new Vector2(this.location.X, 480 - currentFrame.Height * scale);
                this.lifeTime = directionChange + 1;
            } 
            if (this.location.X < 0)
            {
                this.location = new Vector2(0, this.location.Y);
                this.lifeTime = directionChange + 1;
            }
            if (this.location.X > 800 - currentFrame.Width * scale)
            {
                this.location = new Vector2(800 - currentFrame.Width * scale, this.location.Y);
                this.lifeTime = directionChange + 1;
            }
        }

        private void nextFrame()
        {
            if (currentFrame == firstFrame)
            {
                currentFrame = secondFrame;
            }
            else
            {
                currentFrame = firstFrame;
            }
        }
        public void Update()
        {
            lifeTime++;
            this.updateLoc();
            if (lifeTime > directionChange)
            {
                this.getNewDirection();
                lifeTime = 0;
            }
            if (lifeTime % frameChange == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, location, currentFrame, Color.White, 0, new Vector2(0,0), scale, SpriteEffects.None, 0f);
        }
    }
}
