﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class WallMaster : IEnemy
    {
        private IEnemyState currentState;
        private int health = 10, lifeTime = 0, directionChange = 40;
        public Vector2 currentLocation;
        private enum direction { Up, Down, Left, Right };
        private direction currentDirection;

        public WallMaster()
        {
            currentState = new LeftMovingWallMasterState(this);
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
                this.getNewDirection();
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            currentState.Draw(sb);
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

