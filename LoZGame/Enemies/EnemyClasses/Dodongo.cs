using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    
    public class Dodongo : IEnemy
    {
        private IEnemyState currentState;
        private int health = 10, lifeTime = 0, directionChange = 40;
        public Vector2 currentLocation;
        private LoZGame game;
        private enum direction { Up, Down, Left, Right };
        private direction currentDirection;
       
        public Dodongo()
        {
            currentState = new LeftMovingDodongoState(this);
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

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch);
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


