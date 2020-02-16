using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class Gel : IEnemy
    {
        private IEnemyState currentState;
        private int health = 10;
        public Vector2 currentLocation;

        public Gel()
        {
            currentState = new LeftMovingGelState(this);
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
        public void Update()
        {
            currentState.Update();
        }
        public void Draw(SpriteBatch sb)
        {
            currentState.Draw(sb);
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


