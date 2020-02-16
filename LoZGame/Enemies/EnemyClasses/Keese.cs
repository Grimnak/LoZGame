using System;
using Microsoft.Xna.Framework;

using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{

    public class Keese : IEnemy
    {
        private IEnemyState currentState;
        private int health = 10;
        public Vector2 currentLocation;

        public Keese()
        {
            currentState = new LeftMovingKeeseState(this);
            currentLocation = new Vector2(400, 200);
        }

        public void moveLeft()
        {
            currentState.moveLeft();
        }
        public void moveRight()
        {
            currentState.moveRight();
        }
        public void moveUp()
        {
            currentState.moveUp();
        }
        public void moveDown()
        {
            currentState.moveDown();
        }
        public void attack()
        {
            //
        }
        public void takeDamage()
        {
            currentState.takeDamage();
        }
        public void die()
        {
            currentState.die();
        }
        public void update()
        {
            currentState.update();
        }
        public void draw(SpriteBatch sb)
        {
            currentState.draw(sb);
        }

        public IEnemyState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }

        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }
    }
}


