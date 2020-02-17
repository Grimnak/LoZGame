namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class Arrow : IItemSprite
    {
        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private readonly int scale;
        private readonly float rotation;

        public Vector2 location { get; set; }

        public Arrow(Texture2D texture, Vector2 loc, int scale)
        {
            this.texture = texture;
            this.frame = new Rectangle(154, 0, 5, 16);
            this.lifeTime = 20;
            this.location = new Vector2(loc.X, loc.Y);
            this.scale = scale;
            this.rotation = 0;
        }

        public void Update()
        {
            this.lifeTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.frame, Color.White, this.rotation, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }

    }
}
