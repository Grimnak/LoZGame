namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    // Class to handle the completely stationary sprite
    internal class Fairy : IItemSprite
    {
        private static readonly int DirectionChange = 40;
        private static readonly int FrameChange = 10;
        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle firstFrame;   // frames
        private Rectangle secondFrame;
        private Rectangle currentFrame; // frame to draw
        private readonly int scale;

        private enum Direction
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

        private Direction currentDirection;

        public Vector2 Location { get; set; }

        private int lifeTime;

        public Fairy(Texture2D texture, Vector2 loc, int scale)
        {
            this.texture = texture;                          // assigns texture to passed texture
            this.firstFrame = new Rectangle(40, 0, 8, 16);
            this.secondFrame = new Rectangle(48, 0, 8, 16);
            this.currentFrame = this.firstFrame;
            this.lifeTime = 0;
            this.scale = scale;
            this.Location = loc;
            this.GetNewDirection();
        }

        private void GetNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (Direction)randomselect.Next(0, 8);
        }

        private void UpdateLoc()
        {
            switch (this.currentDirection)
            {
                case Direction.North:
                    this.Location = new Vector2(this.Location.X, this.Location.Y - 1);
                    break;

                case Direction.South:
                    this.Location = new Vector2(this.Location.X, this.Location.Y + 1);
                    break;

                case Direction.East:
                    this.Location = new Vector2(this.Location.X + 1, this.Location.Y);
                    break;

                case Direction.West:
                    this.Location = new Vector2(this.Location.X - 1, this.Location.Y);
                    break;

                case Direction.NorthEast:
                    this.Location = new Vector2(this.Location.X + 1, this.Location.Y - 1);
                    break;

                case Direction.NorthWest:
                    this.Location = new Vector2(this.Location.X - 1, this.Location.Y - 1);
                    break;

                case Direction.SouthEast:
                    this.Location = new Vector2(this.Location.X + 1, this.Location.Y + 1);
                    break;

                case Direction.SouthWest:
                    this.Location = new Vector2(this.Location.X - 1, this.Location.Y + 1);
                    break;

                default:
                    break;
            }

            this.CheckBorder();
        }

        private void CheckBorder()
        {
            if (this.Location.Y < 0)
            {
                this.Location = new Vector2(this.Location.X, 0);
                this.lifeTime = DirectionChange + 1;
            }

            if (this.Location.Y > 480 - (this.currentFrame.Height * this.scale))
            {
                this.Location = new Vector2(this.Location.X, 480 - (this.currentFrame.Height * this.scale));
                this.lifeTime = DirectionChange + 1;
            }

            if (this.Location.X < 0)
            {
                this.Location = new Vector2(0, this.Location.Y);
                this.lifeTime = DirectionChange + 1;
            }

            if (this.Location.X > 800 - (this.currentFrame.Width * this.scale))
            {
                this.Location = new Vector2(800 - (this.currentFrame.Width * this.scale), this.Location.Y);
                this.lifeTime = DirectionChange + 1;
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
            this.UpdateLoc();
            if (this.lifeTime > DirectionChange)
            {
                this.GetNewDirection();
                this.lifeTime = 0;
            }

            if (this.lifeTime % FrameChange == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Location, this.currentFrame, Color.White, 0, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }
    }
}