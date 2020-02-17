using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class Dragon : IEnemy
    {
        private IDragonState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        public Vector2 currentLocation;

        private enum stateEnum { Idle, Left, Right, Attacking};

        private stateEnum currentStateEnum;

        public Dragon()
        {
            this.currentState = new LeftMovingDragonState(this);
            this.currentLocation = new Vector2(650, 200);
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            this.currentStateEnum = (stateEnum)(randomselect.Next(0, 5));
        }

        private void updateLoc()
        {
            switch (this.currentStateEnum)
            {
                case stateEnum.Attacking:
                    this.currentState.attack();
                    break;
                case stateEnum.Idle:
                    this.currentState.stop();
                    break;
                case stateEnum.Left:
                    this.currentState.moveLeft();
                    break;
                case stateEnum.Right:
                    this.currentState.moveRight();
                    break;
                default:
                    break;
            }
            this.checkBorder();
            this.currentState.Update();
        }
 
        private void checkBorder()
        {
              if (this.currentLocation.Y < 0)
              {
                  this.currentLocation = new Vector2(this.currentLocation.X, 0);
                  this.lifeTime = this.directionChange + 1;
              }
              if (this.currentLocation.Y > 430)
              {
                  this.currentLocation = new Vector2(this.currentLocation.X, 430);
                  this.lifeTime = this.directionChange + 1;
              }
              if (this.currentLocation.X < 0)
              {
                  this.currentLocation = new Vector2(0, this.currentLocation.Y);
                  this.lifeTime = this.directionChange + 1;
              }
              if (this.currentLocation.X > 750)
              {
                  this.currentLocation = new Vector2(750, this.currentLocation.Y);
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
                this.getNewDirection();
                this.lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            this.currentState.Draw(sb);
        }

        public IDragonState CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }

        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }
    }
}


