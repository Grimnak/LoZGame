using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class Boomerang : IItemSprite, IUsableItem
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int scale;
        private string direction;

        private int instance;
        private bool expired;
        private bool isStatic;

        private float rotation;
        private Vector2 originalLocation;
        private int travDirection;
        private static int maxDistance = 300;

        private static int maxFrameDelay = 2;
        private static int maxRotationDelay = 4;
        private int rotationDelay;
        private int frameDelay;

        public Vector2 location { get; set; }
        public Boomerang(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(129, 0, 5, 16);
            location = loc;
            this.scale = scale;
            isStatic = true;
        }

        public Boomerang(Texture2D texture, Vector2 loc, string direction, int scale, int instance)
        {
            Texture = texture;
            frame = new Rectangle(129, 0, 5, 16);
            this.scale = scale;
            this.instance = instance;
            expired = false;
            isStatic = false;
            rotation = 0;
            travDirection = 1;
            this.direction = direction;
            frameDelay = 0;
            rotationDelay = 0;

            if (direction.Equals("Up"))
            {
                location = new Vector2(loc.X, loc.Y - 32);
            }
            else if (direction.Equals("Left"))
            {
                location = new Vector2(loc.X - 32, loc.Y);
            }
            else if (direction.Equals("Right"))
            {
                location = new Vector2(loc.X + 32, loc.Y);
            }
            else
            {
                location = new Vector2(loc.X, loc.Y + 32);
            }

            originalLocation = new Vector2(loc.X, loc.Y);
        }


        public void rotate()
        {
            if (rotation == 0)
            {
                rotation = MathHelper.PiOver2;
            }
            else if (rotation == MathHelper.PiOver2)
            {
                rotation = MathHelper.Pi;
            }
            else if (rotation == MathHelper.Pi)
            {
                rotation = -1 * MathHelper.PiOver2;
            }
            else
            {
                rotation = 0;
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
            frameDelay++;
            rotationDelay++;
            if (rotationDelay == maxRotationDelay)
            {
                rotationDelay = 0;
                this.rotate();
            }
            if (!isStatic && frameDelay == maxFrameDelay)
            {
                frameDelay = 0;
                if (direction.Equals("Up"))
                {
                    if (location.Y - 10 < originalLocation.Y - maxDistance)
                    {
                        travDirection = -1;
                    }
                    if (location.Y > originalLocation.Y)
                    {
                        expired = true;
                    }
                    location = new Vector2(location.X, location.Y - travDirection*10);
                }
                else if (direction.Equals("Left"))
                {
                    if (location.X - 10 < originalLocation.X - maxDistance)
                    {
                        travDirection = -1;
                    }
                    if (location.X > originalLocation.X)
                    {
                        expired = true;
                    }
                    location = new Vector2(location.X - travDirection*10, location.Y);
                }
                else if (direction.Equals("Right"))
                {
                    if (location.X + 10 > originalLocation.X + maxDistance)
                    {
                        travDirection = -1;
                    }
                    if (location.X < originalLocation.X)
                    {
                        expired = true;
                    }
                    location = new Vector2(location.X + travDirection*10, location.Y);
                }
                else
                {
                    if (location.Y + 10 > originalLocation.Y + maxDistance)
                    {
                        travDirection = -1;
                    }
                    if (location.Y < originalLocation.Y)
                    {
                        expired = true;
                    }
                    location = new Vector2(location.X, location.Y + travDirection*10);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            if (isStatic)
            {
                spriteBatch.Draw(Texture, dest, frame, Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture, this.location, frame, Color.White, rotation, new Vector2(3, 8), scale, SpriteEffects.None, 0f);
            }
        }

    }
}
