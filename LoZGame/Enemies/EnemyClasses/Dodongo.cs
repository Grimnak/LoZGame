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
        public Dodongo()
        {
            this.currentState = new LeftMovingDodongoState(this);
            this.currentLocation = new Vector2(650, 200);
        }
        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        public Vector2 currentLocation;
        private readonly LoZGame game;
        private Direction currentDirection;
        private enum Direction 
        { 
            Up,
            Down,
            Left,
            Right 
        };

        private void GetNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (Direction)randomselect.Next(0, 5);
        }

        private void UpdateLoc()
        {
            switch (this.currentDirection)
            {
                case Direction.Up:
                    this.currentState.moveUp();
                    break;
                case Direction.Down:
                    this.currentState.moveDown();
                    break;
                case Direction.Left:
                    this.currentState.moveLeft();
                    break;
                case Direction.Right:
                    this.currentState.moveRight();
                    break;
                default:
                    break;
            }

            this.CheckBorder();
            this.currentState.Update();
        }

        private void CheckBorder()
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
            this.UpdateLoc();
            if (this.lifeTime > this.directionChange)
            {
                this.GetNewDirection();
                this.lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.currentState.Draw(spriteBatch);
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