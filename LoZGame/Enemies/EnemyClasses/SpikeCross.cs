using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class SpikeCross : IEnemy
    {
        private ISpikeCrossState currentState;
        private int health = 10, lifeTime = 0, directionChange = 40;
        public Vector2 currentLocation;
        private enum direction { Up, Down, Left, Right, Idle};
        private direction currentDirection;

        public SpikeCross()
        {
            currentState = new LeftMovingSpikeCrossState(this);
            currentLocation = new Vector2(650, 200);
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
                case direction.Up:
                    currentState.moveUp();
                    break;
                case direction.Down:
                    currentState.moveDown();
                    break;
                case direction.Left:
                    currentState.moveLeft();
                    break;
                case direction.Right:
                    currentState.moveRight();
                    break;
                case direction.Idle:
                    currentState.stop();
                    break;
                default:
                    break;
            }
            currentState.Update();
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
            lifeTime++;
            this.updateLoc();
            if (lifeTime > directionChange)
            {
                this.getNewDirection();
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            currentState.Draw(sb);
        }

        public ISpikeCrossState CurrentState
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


