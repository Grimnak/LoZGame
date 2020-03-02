namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    internal class Health : IItem
    {
        private const int FrameChange = 10;
        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private ItemCollisionHandler CollisionHandler;
        private Vector2 origin;
        private Vector2 Size;
        private float rotation;
        private float layer;
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private readonly int scale;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public Health(Texture2D texture, SpriteSheetData data, Vector2 loc, int scale)
        {
            this.Data = data;
            this.Texture = texture;
            this.Physics = new Physics(loc, new Vector2(0, 0), new Vector2(0, 0));
            this.origin = new Vector2(data.Width / 2, data.Height / 2);
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Width * scale);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.CollisionHandler = new ItemCollisionHandler(this);
            this.layer = 1 / (this.Physics.Location.Y + this.Size.Y);
            this.rotation = 0;
            this.firstFrame = new Rectangle(0, 0, data.Width, data.Height);
            this.secondFrame = new Rectangle(0, data.Height, data.Width, data.Height);
            this.currentFrame = this.firstFrame;
            this.lifeTime = 0;
            this.scale = scale;
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                CollisionHandler.OnCollisionResponse(collisionSide);
            }
        }

        private void NextFrame()
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

        private void UpdateLoc()
        {
            if ((int)Math.Abs(this.Physics.Velocity.X) > 0 || (int)Math.Abs(this.Physics.Velocity.Y) > 0)
            {
                this.Physics.Move();
                this.Physics.Accelerate();
            }
            else
            {
                this.Physics.StopMovement();
            }
        }

        public void Update()
        {
            this.lifeTime++;
            this.UpdateLoc();
            if (this.lifeTime > 200)
            {
                this.lifeTime = 0;
            }

            if (this.lifeTime % FrameChange == 0)
            {
                this.NextFrame();
            }
        }

        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, this.Physics.Location, this.currentFrame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}