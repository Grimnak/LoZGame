using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    // Class to handle the completely stationary sprite
    class Fairy : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle firstFrame;   // frames
        private Rectangle secondFrame;
        private Rectangle currentFrame; // frame to draw
        public Vector2 location { get; set; }
        private int lifeTime;

        public Fairy(Texture2D texture, Vector2 loc) {
            Texture = texture;                          // assigns texture to passed texture
            firstFrame = new Rectangle(40, 0, 8, 16);
            secondFrame = new Rectangle(48, 0, 8, 16);
            currentFrame = firstFrame;
            lifeTime = 0;
            location = loc;
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
            if (lifeTime > 20)
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
            spriteBatch.Draw(Texture, location, currentFrame, Color.White);

        }

    }

    class Health : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Health(Texture2D texture, Vector2 loc)
        {
            Texture = texture;                          
            firstFrame = new Rectangle(0, 0, 7, 8);
            secondFrame = new Rectangle(0, 8, 7, 8);
            currentFrame = firstFrame;
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, currentFrame, Color.White);
        }

    }

    class TriForce : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public TriForce(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            firstFrame = new Rectangle(275, 0, 10, 16);
            secondFrame = new Rectangle(275, 16, 10, 16);
            currentFrame = firstFrame;
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, currentFrame, Color.White);
        }

    }

    class YellowRupee : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public YellowRupee(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            firstFrame = new Rectangle(72, 0, 8, 16);
            secondFrame = new Rectangle(72, 16, 8, 16);
            currentFrame = firstFrame;
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, currentFrame, Color.White);
        }

    }

    class FullHeart : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public FullHeart(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(0, 0, 7, 8);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class HalfHeart : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public HalfHeart(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(8, 0, 8, 8);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class EmptyHeart : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public EmptyHeart(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(16, 0, 7, 8);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class HeartContainer : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public HeartContainer(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(25, 0, 13, 16);
            lifeTime = 0;
            location = loc;

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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Clock : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Clock(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(58, 0, 11, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Rupee : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Rupee(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(72, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class LifePotion : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public LifePotion(Texture2D texture, Vector2 loc)
        { 
            Texture = texture;
            frame = new Rectangle(80, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class SecondPotion : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }

        public SecondPotion(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(80, 16, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Letter : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Letter(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(88, 16, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Map : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Map(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(88, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Food : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Food(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(96, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class WoodenSword : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public WoodenSword(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(104, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class WhiteSword : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public WhiteSword(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(104, 16, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class MagicSword : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public MagicSword(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(112, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class MagicShield : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public MagicShield(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(120, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Boomerang : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Boomerang(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(129, 0, 5, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class MagicBoomerang : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public MagicBoomerang(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(129, 16, 5, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Bomb : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Bomb(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(136, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Bow : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Bow(Texture2D texture, Vector2 loc)
        {
            location = loc;
            Texture = texture;
            frame = new Rectangle(144, 0, 8, 16);
            lifeTime = 0;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Arrow : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Arrow(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(154, 0, 5, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class SilverArrow : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public SilverArrow(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(154, 16, 5, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class RedCandle : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public RedCandle(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(160, 0, 6, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class BlueCandle : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public BlueCandle(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(160, 16, 6, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class RedRing : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public RedRing(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(169, 0, 7, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class BlueRing : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public BlueRing(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(169, 16, 7, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class PowerBracelet : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public PowerBracelet(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(176, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Flute : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Flute(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(187, 0, 3, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Raft : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Raft(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(193, 0, 14, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class StepLadder : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public StepLadder(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(208, 0, 16, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class MagicRod : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public MagicRod(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(226, 0, 4, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class MagicBook : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public MagicBook(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(232, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Key : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Key(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(240, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class MagicKey : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public MagicKey(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(248, 0, 8, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }

    class Compass : ISprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        public Vector2 location { get; set; }
        public Compass(Texture2D texture, Vector2 loc)
        {
            Texture = texture;
            frame = new Rectangle(258, 0, 11, 16);
            lifeTime = 0;
            location = loc;
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
            // draaws the sill link at the specified location
            spriteBatch.Draw(Texture, location, frame, Color.White);
        }

    }
}
