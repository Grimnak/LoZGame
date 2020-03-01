namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    // Class to handle the completely stationary sprite
    internal class Fairy : IItem
    {
        private static readonly int DirectionChange = 40;
        private static readonly int FrameChange = 10;
        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private ItemCollisionHandler CollisionHandler;
        private Vector2 origin;
        private Vector2 Size;
        private float rotation;
        private float layer;
        private Rectangle firstFrame;   // frames
        private Rectangle secondFrame;
        private Rectangle currentFrame; // frame to draw
        private readonly int scale;
        private int lifeTime;

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

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public Fairy(Texture2D texture, SpriteSheetData data, Vector2 loc, int scale)
        {
            this.Data = data;
            this.Texture = texture;
            this.Physics = new Physics(loc, new Vector2(0, 0), new Vector2(0, 0));
            this.origin = new Vector2(data.Width / 2, data.Height / 2);
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Width * scale);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.CollisionHandler = new ItemCollisionHandler(this);
            layer = this.Physics.Location.Y + this.Size.Y;
            this.rotation = 0;
            this.firstFrame = new Rectangle(0, 0, data.Width, data.Height);
            this.secondFrame = new Rectangle(0, data.Height, data.Width, data.Height);
            this.currentFrame = this.firstFrame;
            this.lifeTime = 0;
            this.scale = scale;
            this.GetNewDirection();
        }

        private void GetNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (Direction)randomselect.Next(0, 8);
            switch (this.currentDirection)
            {
                case Direction.North:
                    this.Physics.Velocity = new Vector2(0, -1);
                    break;

                case Direction.South:
                    this.Physics.Velocity = new Vector2(0, 1);
                    break;

                case Direction.East:
                    this.Physics.Velocity = new Vector2(1, 0);
                    break;

                case Direction.West:
                    this.Physics.Velocity = new Vector2(-1, 0);
                    break;

                case Direction.NorthEast:
                    this.Physics.Velocity = new Vector2(1, -1);
                    break;

                case Direction.NorthWest:
                    this.Physics.Velocity = new Vector2(-1, -1);
                    break;

                case Direction.SouthEast:
                    this.Physics.Velocity = new Vector2(1, 1);
                    break;

                case Direction.SouthWest:
                    this.Physics.Velocity = new Vector2(-1, 1);
                    break;

                default:
                    break;
            }
        }

        private void UpdateLoc()
        {
            
            this.CheckBorder();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.Physics.Location = new Vector2(432, 236);
            }
        }

        private void CheckBorder()
        {
            if (this.Physics.Location.Y < 0)
            {
                this.Physics.Location = new Vector2(this.Physics.Location.X, 0);
                this.lifeTime = DirectionChange + 1;
            }

            if (this.Physics.Location.Y > 480 - (this.currentFrame.Height * this.scale))
            {
                this.Physics.Location = new Vector2(this.Physics.Location.X, 480 - (this.currentFrame.Height * this.scale));
                this.lifeTime = DirectionChange + 1;
            }

            if (this.Physics.Location.X < 0)
            {
                this.Physics.Location = new Vector2(0, this.Physics.Location.Y);
                this.lifeTime = DirectionChange + 1;
            }

            if (this.Physics.Location.X > 800 - (this.currentFrame.Width * this.scale))
            {
                this.Physics.Location = new Vector2(800 - (this.currentFrame.Width * this.scale), this.Physics.Location.Y);
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

        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, this.Physics.Location, this.currentFrame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}