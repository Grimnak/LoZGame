using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class Flame : IEnemy
    {
        public Vector2 currentLocation;

        public Flame()
        {
            currentLocation = new Vector2(650, 200);
        }

        public void takeDamage()
        {
            //
        }
        public void die()
        {
           //
        }
        public void Update()
        {
            currentState.Update();
        }
        public void Draw(SpriteBatch sb)
        {
            currentState.Draw(sb);
        }
    }
}

