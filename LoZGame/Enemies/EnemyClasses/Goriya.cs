using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class Goriya : IEnemy
    {
        private IGoriyaState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        public Vector2 currentLocation;
        private string currentDirection = "left";

        private enum stateEnum { Up, Down, Left, Right, Attacking };

        private stateEnum state;

        public Goriya()
        {
            this.currentState = new LeftMovingGoriyaState(this);
            this.currentLocation = new Vector2(650, 200);
        }

        private void getNewState()
        {
            Random randomselect = new Random();
            this.state = (stateEnum)(randomselect.Next(0, 7));
        }

        private void updateLoc()
        {
            switch (this.state)
            {
                case stateEnum.Up:
                    this.currentDirection = "up";
                    this.currentState.moveUp();
                    break;
                case stateEnum.Down:
                    this.currentDirection = "down";
                    this.currentState.moveDown();
                    break;
                case stateEnum.Left:
                    this.currentDirection = "left";
                    this.currentState.moveLeft();
                    break;
                case stateEnum.Right:
                    this.currentDirection = "right";
                    this.currentState.moveRight();
                    break;
                case stateEnum.Attacking:
                    this.currentState.attack();
                    break;
                default:
                    break;
            }
            this.checkBorder();
            this.currentState.Update();
        }
        
        private void checkBorder()
        {
              if (this.currentLocation.Y < 30)
              {
                  this.currentLocation = new Vector2(this.currentLocation.X, 30);
                  this.lifeTime = this.directionChange + 1;
              }
              if (this.currentLocation.Y > 450)
              {
                  this.currentLocation = new Vector2(this.currentLocation.X, 450);
                  this.lifeTime = this.directionChange + 1;
              }
              if (this.currentLocation.X < 30)
              {
                  this.currentLocation = new Vector2(30, this.currentLocation.Y);
                  this.lifeTime = this.directionChange + 1;
              }
              if (this.currentLocation.X > 770)
              {
                  this.currentLocation = new Vector2(770, this.currentLocation.Y);
                  this.lifeTime = this.directionChange + 1;
              }
        } 

        public void takeDamage()
        {
            this.currentState.takeDamage();
        }

        public void die()
        {
            this.currentState.die();
        }

        public void Update()
        {
            this.lifeTime++;
            this.updateLoc();
            if (this.lifeTime > this.directionChange)
            {
                this.getNewState();
                this.lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            this.currentState.Draw(sb);
        }

        public IGoriyaState CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }

        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        public string direction
        {
            get { return this.currentDirection; }
            set { this.currentDirection = value; }
        }
    }
}


