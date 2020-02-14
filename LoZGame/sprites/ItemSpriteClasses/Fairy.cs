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
            currentDirection = (direction)(randomselect.Next(0, 7));
        }

        private void updateLoc()
        {
            switch (this.currentDirection)
            {
                case direction.North:
                    this.location = new Vector2(this.location.X - 1, this.location.Y);
                    break;
                case direction.South:
                    this.location = new Vector2(this.location.X + 1, this.location.Y);
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
            }
            if (this.location.X < 0)
            {
                this.location = new Vector2(0, this.location.Y);
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
            if (lifeTime > 20)
            {
                this.getNewDirection();
                lifeTime = 0;
            }
            if (lifeTime % 4 == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, firstFrame.Width * scale, firstFrame.Height * scale);
            spriteBatch.Draw(Texture, dest, currentFrame, Color.White);
        }

    }
}
