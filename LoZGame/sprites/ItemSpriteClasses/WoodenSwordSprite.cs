namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class WoodenSwordSprite : ISprite
    {
        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Vector2 origin;
        private Vector2 Size;
        private float rotation;
        private float layer;
        private Rectangle frame;
        private int lifeTime;
        private readonly int scale;

        public Physics Physics { get; set; }

        public WoodenSwordSprite(Texture2D texture, SpriteSheetData data, Vector2 loc, int scale)
        {
            this.Data = data;
            this.Texture = texture;
            this.Physics = new Physics(loc, new Vector2(0, 0), new Vector2(0, 0));
            this.origin = new Vector2(data.Width / 2, data.Height / 2);
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Width * scale);
            this.layer = 1 / (0 + this.Size.Y);
            this.rotation = 0;
            this.frame = new Rectangle(0, 0, data.Width, data.Height);
            this.lifeTime = 0;
            this.scale = scale;
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
            if (this.lifeTime > 20)
            {
                this.lifeTime = 0;
            }
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, location, this.frame, spriteTint, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}