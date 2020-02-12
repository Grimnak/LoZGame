using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LoZClone
{
    // Class to handle the completely stationary sprite
    class Fairy : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle firstFrame;   // frames
        private Rectangle secondFrame;
        private Rectangle currentFrame; // frame to draw
        private int scale;
        private enum direction {North, South, East, West, NorthEast, NorthWest, SouthEast, SouthWest };
        private direction currentDirection;
        public Vector2 location { get; set; }
        private int lifeTime;

        public Fairy(Texture2D texture, Vector2 loc, int scale) {
            Texture = texture;                          // assigns texture to passed texture
            firstFrame = new Rectangle(40, 0, 8, 16);
            secondFrame = new Rectangle(48, 0, 8, 16);
            currentFrame = firstFrame;
            lifeTime = 0;
            this.scale = scale;
            location = loc;
            this.getNewDirection();
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            currentDirection = (direction)(randomselect.Next(0, 7));
        }

        private void updateLoc()
        {
            switch (this.currentDirection)
            {
                case direction.North:
                    this.location = new Vector2(this.location.X - 1, this.location.Y);
                    break;
                case direction.South:
                    this.location = new Vector2(this.location.X + 1, this.location.Y);
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
            }
            if (this.location.X < 0)
            {
                this.location = new Vector2(0, this.location.Y);
            }
        }

        private void nextFrame()
        {
            if (currentFrame == firstFrame)
            {
                currentFrame = secondFrame;
            }
            else
            {
                currentFrame = firstFrame;
            }
        }
        public void Update()
        {
            lifeTime++;
            this.updateLoc();
            if (lifeTime > 20)
            {
                this.getNewDirection();
                lifeTime = 0;
            }
            if (lifeTime % 4 == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, firstFrame.Width * scale, firstFrame.Height * scale);
            spriteBatch.Draw(Texture, dest, currentFrame, Color.White);
        }

    }

    class Health : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Health(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;                          
            firstFrame = new Rectangle(0, 0, 7, 8);
            secondFrame = new Rectangle(0, 8, 7, 8);
            currentFrame = firstFrame;
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        private void nextFrame()
        {
            if (currentFrame == firstFrame)
            {
                currentFrame = secondFrame;
            } else
            {
                currentFrame = firstFrame;
            }
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 200)
            {
                lifeTime = 0;
            }
            if (lifeTime % 4 == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, firstFrame.Width * scale, firstFrame.Height * scale);
            spriteBatch.Draw(Texture, dest, currentFrame, Color.White);
        }

    }

    class TriForce : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public TriForce(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            firstFrame = new Rectangle(275, 0, 10, 16);
            secondFrame = new Rectangle(275, 16, 10, 16);
            currentFrame = firstFrame;
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        private void nextFrame()
        {
            if (currentFrame == firstFrame)
            {
                currentFrame = secondFrame;
            }
            else
            {
                currentFrame = firstFrame;
            }
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 200)
            {
                lifeTime = 0;
            }
            if (lifeTime % 4 == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, firstFrame.Width * scale, firstFrame.Height * scale);
            spriteBatch.Draw(Texture, dest, currentFrame, Color.White);
        }

    }

    class YellowRupee : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public YellowRupee(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            firstFrame = new Rectangle(72, 0, 8, 16);
            secondFrame = new Rectangle(72, 16, 8, 16);
            currentFrame = firstFrame;
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        private void nextFrame()
        {
            if (currentFrame == firstFrame)
            {
                currentFrame = secondFrame;
            }
            else
            {
                currentFrame = firstFrame;
            }
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 200)
            {
                lifeTime = 0;
            }
            if (lifeTime % 4 == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, firstFrame.Width * scale, firstFrame.Height * scale);
            spriteBatch.Draw(Texture, dest, currentFrame, Color.White);
        }

    }

    class FullHeart : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public FullHeart(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(0, 0, 7, 8);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class HalfHeart : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public HalfHeart(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(8, 0, 8, 8);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class EmptyHeart : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public EmptyHeart(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(16, 0, 7, 8);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class HeartContainer : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public HeartContainer(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(25, 0, 13, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;

        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }
    }

    class Clock : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Clock(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(58, 0, 11, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }
    }

    class Rupee : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Rupee(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(72, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class LifePotion : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public LifePotion(Texture2D texture, Vector2 loc, int scale)
        { 
            Texture = texture;
            frame = new Rectangle(80, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class SecondPotion : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }

        public SecondPotion(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(80, 16, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class Letter : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Letter(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(88, 16, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class Map : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Map(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(88, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class Food : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Food(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(96, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class WoodenSword : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public WoodenSword(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(104, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class WhiteSword : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public WhiteSword(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(104, 16, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class MagicSword : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public MagicSword(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(112, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class MagicShield : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public MagicShield(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(120, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class Boomerang : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Boomerang(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(129, 0, 5, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class MagicBoomerang : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public MagicBoomerang(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(129, 16, 5, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class Bomb : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Bomb(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(136, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class Bow : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Bow(Texture2D texture, Vector2 loc, int scale)
        {
            location = loc;
            Texture = texture;
            frame = new Rectangle(144, 0, 8, 16);
            lifeTime = 0;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class Arrow : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Arrow(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(154, 0, 5, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class SilverArrow : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public SilverArrow(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(154, 16, 5, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class RedCandle : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public RedCandle(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(160, 0, 6, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class BlueCandle : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public BlueCandle(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(160, 16, 6, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class RedRing : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public RedRing(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(169, 0, 7, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class BlueRing : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public BlueRing(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(169, 16, 7, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class PowerBracelet : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public PowerBracelet(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(176, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class Flute : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Flute(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(187, 0, 3, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class Raft : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Raft(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(193, 0, 14, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class StepLadder : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public StepLadder(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(208, 0, 16, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class MagicRod : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public MagicRod(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(226, 0, 4, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class MagicBook : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public MagicBook(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(232, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class Key : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Key(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(240, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class MagicKey : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public MagicKey(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(248, 0, 8, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }

    class Compass : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public Compass(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(258, 0, 11, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }
}
