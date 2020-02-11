using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class SpikeCross : IEnemy
    {
        public IEnemyState state;
        public int health = 10;
        public Vector2 location;

        public SpikeCross()
        {
            state = new LeftMovingSpikeCrossState(this);
            location = new Vector2(400, 200);
        }
        public void moveLeft()
        {
            state.moveLeft();
        }
        public void moveRight()
        {
            state.moveRight();
        }
        public void moveUp()
        {
            state.moveUp();
        }
        public void moveDown()
        {
            state.moveDown();
        }
        public void attack()
        {
            //
        }
        public void takeDamage()
        {
            state.takeDamage();
        }
        public void die()
        {
            state.die();
        }
        public void update()
        {
            state.update();
        }
        public void draw()
        {

        }

    }
}