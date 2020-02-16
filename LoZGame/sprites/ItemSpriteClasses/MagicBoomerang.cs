﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class MagicBoomerang : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int scale;
        private float rotation;
        private int lifeTime;

        public Vector2 location { get; set; }
        public MagicBoomerang(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(129, 16, 5, 16);
            location = loc;
            this.scale = scale;
            this.rotation = 0;
        }

        public void Update()
        {
            lifeTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, frame, Color.White, rotation, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }

    }
}