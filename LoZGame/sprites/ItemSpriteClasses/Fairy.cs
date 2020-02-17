namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    // Class to handle the completely stationary sprite
    class Fairy : IItemSprite
    {
        private static readonly int directionChange = 40;
        private static readonly int frameChange = 10;
        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle firstFrame;   // frames
        private Rectangle secondFrame;
        private Rectangle currentFrame; // frame to draw
        private readonly int scale;

        private enum direction
        {
            North,
            South,
            East,
            West,
            NorthEast,
            NorthWest,
            SouthEast,
            SouthWest,
        }

        private direction currentDirection;

        public Vector2 location { get; set; }

        private int lifeTime;

        public Fairy(Texture2D texture, Vector2 loc, int scale)
        {
            this.texture = texture;                          // assigns texture to passed texture
            this.firstFrame = new Rectangle(40, 0, 8, 16);
            this.secondFrame = new Rectangle(48, 0, 8, 16);
            this.currentFrame = this.firstFrame;
            this.lifeTime = 0;
            this.scale = scale;
            this.location = loc;
            this.getNewDirection();
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (direction)randomselect.Next(0, 8);
        }

        private void updateLoc()
        {
            switch (this.currentDirection)
            {
                case direction.North:
                    this.location = new Vector2(this.location.X, this.location.Y - 1);
                    break;
                case direction.South:
                    this.location = new Vector2(this.location.X, this.location.Y + 1);
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

            if (this.location.Y > 480 - this.currentFrame.Height * this.scale)
            {
                this.location = new Vector2(this.location.X, 480 - this.currentFrame.Height * this.scale);
                this.lifeTime = directionChange + 1;
            }

            if (this.location.X < 0)
            {
                this.location = new Vector2(0, this.location.Y);
                this.lifeTime = directionChange + 1;
            }

            if (this.location.X > 800 - this.currentFrame.Width * this.scale)
            {
                this.location = new Vector2(800 - this.currentFrame.Width * this.scale, this.location.Y);
                this.lifeTime = directionChange + 1;
            }
        }

        private void nextFrame()
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
            this.updateLoc();
            if (this.lifeTime > directionChange)
            {
                this.getNewDirection();
                this.lifeTime = 0;
            }

            if (this.lifeTime % frameChange == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.currentFrame, Color.White, 0, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }
    }
}
