using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{

    public class OldMan : IEnemy
    {
        public Vector2 currentLocation;

        public OldMan()
        {
            currentLocation = new Vector2(400, 200);
        }

        public void moveLeft()
        {
            //
        }
        public void moveRight()
        {
           //
        }
        public void moveUp()
        {
           //
        }
        public void moveDown()
        {
            //
        }
        public void attack()
        {
            //
        }
        public void takeDamage()
        {
            //
        }
        public void die()
        {
           //
        }
        public void update()
        {
            currentState.update();
        }
        public void draw()
        {

        }
    }
}

