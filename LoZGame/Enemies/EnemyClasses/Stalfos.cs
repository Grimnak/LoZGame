using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class Stalfos : IEnemy
    {
        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        public Vector2 currentLocation;

        private enum direction { Up, Down, Left, Right };

        private direction currentDirection;

        public Stalfos()
        {
            this.currentState = new LeftMovingStalfosState(this);
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
                this.getNewDirection();
                this.lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            this.currentState.Draw(sb);
        }

        public IEnemyState CurrentState
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


