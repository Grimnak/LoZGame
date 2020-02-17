using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class Dragon : IEnemy
    {
        private IDragonState currentState;
        private int health = 10, lifeTime = 0, directionChange = 40;
        public Vector2 currentLocation;
        private enum stateEnum { Idle, Left, Right, Attacking};
        private stateEnum currentStateEnum;

        public Dragon()
        {
            currentState = new LeftMovingDragonState(this);
            currentLocation = new Vector2(650, 200);
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            currentStateEnum = (stateEnum)(randomselect.Next(0, 7));
        }

        private void updateLoc()
        {
            switch (this.currentStateEnum)
            {
                case stateEnum.Attacking:
                    currentState.attack();
                    break;
                case stateEnum.Idle:
                    currentState.stop();
                    break;
                case stateEnum.Left:
                    currentState.moveLeft();
                    break;
                case stateEnum.Right:
                    currentState.moveRight();
                    break;
                default:
                    break;
            }
            // this.checkBorder();
            currentState.Update();
        }
        /*   private void checkBorder()
          {
              if (this.currentLocation.Y < 0)
              {
                  this.currentLocation = new Vector2(this.currentLocation.X, 0);
                  this.lifeTime = directionChange + 1;
              }
              if (this.currentLocation.Y > 480 - currentFrame.Height * scale)
              {
                  this.currentLocation = new Vector2(this.currentLocation.X, 480 - currentFrame.Height * scale);
                  this.lifeTime = directionChange + 1;
              }
              if (this.currentLocation.X < 0)
              {
                  this.currentLocation = new Vector2(0, this.currentLocation.Y);
                  this.lifeTime = directionChange + 1;
              }
              if (this.currentLocation.X > 800 - currentFrame.Width * scale)
              {
                  this.currentLocation = new Vector2(800 - currentFrame.Width * scale, this.currentLocation.Y);
                  this.lifeTime = directionChange + 1;
              }
          } */

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

        public IDragonState CurrentState
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


