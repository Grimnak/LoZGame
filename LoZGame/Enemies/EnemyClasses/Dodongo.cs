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
        private int health = 10;
        public Vector2 currentLocation;
        private LoZGame game;
        public IEnemyState State
        {
            set
            {
                currentState = value;
            }
        }

        public Dodongo()
        {
            currentState = new LeftMovingDodongoState(this);
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


