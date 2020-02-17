using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class Keese : IEnemy
    {
        private IKeeseState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        public Vector2 currentLocation;

        private enum direction { Up, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight };

        private direction currentDirection;

        public Keese()
        {
            this.currentState = new LeftMovingKeeseState(this);
            this.currentLocation = new Vector2(650, 200);
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (direction)(randomselect.Next(0, 7));
        }

        private void updateLoc()
        {
            switch (this.currentDirection)
            {
                case direction.Up:
                    this.currentState.moveUp();
                    break;
                case direction.Down:
                    this.currentState.moveDown();
                    break;
                case direction.Left:
                    this.currentState.moveLeft();
                    break;
                case direction.Right:
                    this.currentState.moveRight();
                    break;
                case direction.UpLeft:
                    this.currentState.moveUpLeft();
                    break;
                case direction.UpRight:
                    this.currentState.moveUpRight();
                    break;
                case direction.DownLeft:
                    this.currentState.moveDownLeft();
                    break;
                case direction.DownRight:
                    this.currentState.moveDownRight();
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
       /* public void Update()
        {
            currentState.Update();
        } */

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

           /* if (lifeTime % frameChange == 0)
            {
                this.nextFrame();
            } 
        } */
        public void Draw(SpriteBatch sb)
        {
            this.currentState.Draw(sb);
        }

        public IKeeseState CurrentState
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


