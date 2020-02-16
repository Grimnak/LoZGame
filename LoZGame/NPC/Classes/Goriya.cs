using System;
using Microsoft.Xna.Framework;

using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{

    public class Goriya : IEnemy
    {
        private IEnemyState currentState;
        private int health = 10;
        public Vector2 currentLocation;
        private string currentDirection = "left";

        public Goriya()
        {
            currentState = new LeftMovingGoriyaState(this);
            currentLocation = new Vector2(400, 200);
        }

        public void moveLeft()
        {
            currentDirection = "left";
            currentState.moveLeft();
        }
        public void moveRight()
        {
            currentDirection = "right";
            currentState.moveRight();
        }
        public void moveUp()
        {
            currentDirection = "up";
            currentState.moveUp();

        }
        public void moveDown()
        {
            currentDirection = "down";
            currentState.moveDown(); 
        }
        public void attack()
        {
            currentState.attack();
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

        public string direction
        {
            get { return currentDirection; }
            set { currentDirection = value; }
        }
    }
}


