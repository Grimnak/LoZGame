﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoZClone
{
    class ArrowProjectile : IProjectile
    {
        private static int travelRate = 7;
        private static int linkSize = 32;
        private static int width = 5;
        private static int height = 16;

        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private Vector2 origin;
        private int lifeTime;
        private int scale;
        private string direction;
        private float rotation;
        private int dX, dY;

        private int instance;
        private bool expired;
        private bool hostile;
        public bool IsHostile { get { return hostile; } }
        public Vector2 location { get; set; }
        

        public ArrowProjectile(Texture2D texture, Vector2 loc, string direction, int scale, int instance)
        {
            Texture = texture;
            frame = new Rectangle(154, 0, 5, 16);
            lifeTime = 100;
            this.scale = scale;
            this.direction = direction;
            this.hostile = false;
            this.instance = instance;
            expired = false;
            origin = new Vector2(width * scale / 2, height * scale / 2);
            if (this.direction.Equals("Up"))
            {
                location = new Vector2(loc.X - ((width * scale) - linkSize), loc.Y);
                rotation = 0;
                dX = 0;
                dY = -1;
            }
            else if (this.direction.Equals("Left"))
            {
                location = new Vector2(loc.X, loc.Y - ((width * scale) - linkSize) / 2);
                rotation = -1 * MathHelper.PiOver2;
                dX = -1;
                dY = 0;
            }
            else if (this.direction.Equals("Right"))
            {
                location = new Vector2(loc.X + linkSize, loc.Y - ((width * scale) - linkSize));
                rotation = MathHelper.PiOver2;
                dX = 1;
                dY = 0;
            }
            else
            {
                location = new Vector2(loc.X - ((width * scale) - linkSize) / 2, loc.Y + linkSize);
                rotation = MathHelper.Pi;
                dX = 0;
                dY = 1;
            }
        }

        public bool IsExpired
        {
            get { return expired; }
        }

        public int Instance
        {
            get { return instance; }
        }

        public void Update()
        {
            lifeTime--;
            if (lifeTime <= 0)
            {
                expired = true;
            }
            this.location = new Vector2(this.location.X + dX * travelRate, this.location.Y + dY * travelRate);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, frame, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);
        }
    }
}
