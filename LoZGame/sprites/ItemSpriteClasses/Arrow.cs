﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class Arrow : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        private float rotation;
        public Vector2 location { get; set; }
        public Arrow(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(154, 0, 5, 16);
            lifeTime = 20;
            this.location = new Vector2(loc.X, loc.Y);
            this.scale = scale;
            this.rotation = 0;
        }

        public void Update()
        {
            lifeTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, frame, Color.White, rotation, new Vector2(2,8), scale, SpriteEffects.None, 0f);
        }

    }
}
