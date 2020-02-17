using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class Goriya : IEnemy
    {
        private IGoriyaState currentState;
        private int health = 10, lifeTime = 0, directionChange = 40;
        public Vector2 currentLocation;
        private string currentDirection = "left";
        private enum stateEnum { Up, Down, Left, Right, Attacking };
        private stateEnum state;

        public Goriya()
        {
            currentState = new LeftMovingGoriyaState(this);
            currentLocation = new Vector2(650, 200);
        }

        private void getNewState()
        {
            Random randomselect = new Random();
            state = (stateEnum)(randomselect.Next(0, 7));
        }

        private void updateLoc()
        {
            switch (this.state)
            {
                case stateEnum.Up:
                    currentDirection = "up";
                    currentState.moveUp();
                    break;
                case stateEnum.Down:
                    currentDirection = "down";
                    currentState.moveDown();
                    break;
                case stateEnum.Left:
                    currentDirection = "left";
                    currentState.moveLeft();
                    break;
                case stateEnum.Right:
                    currentDirection = "right";
                    currentState.moveRight();
                    break;
                case stateEnum.Attacking:
                    currentState.attack();
                    break;
                default:
                    break;
            }
            this.checkBorder();
            currentState.Update();
        }
        
        private void checkBorder()
        {
              if (this.currentLocation.Y < 30)
              {
                  this.currentLocation = new Vector2(this.currentLocation.X, 30);
                  this.lifeTime = directionChange + 1;
              }
              if (this.currentLocation.Y > 450)
              {
                  this.currentLocation = new Vector2(this.currentLocation.X, 450);
                  this.lifeTime = directionChange + 1;
              }
              if (this.currentLocation.X < 30)
              {
                  this.currentLocation = new Vector2(30, this.currentLocation.Y);
                  this.lifeTime = directionChange + 1;
              }
              if (this.currentLocation.X > 770)
              {
                  this.currentLocation = new Vector2(770, this.currentLocation.Y);
                  this.lifeTime = directionChange + 1;
              }
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
                this.getNewState();
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            currentState.Draw(sb);
        }

        public IGoriyaState CurrentState
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


