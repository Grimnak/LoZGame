using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class Keese : IEnemy
    {
        private IKeeseState currentState;
        private int health = 10, lifeTime = 0, directionChange = 40;
        public Vector2 currentLocation;
        private enum direction { Up, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight };
        private direction currentDirection;

        public Keese()
        {
            currentState = new LeftMovingKeeseState(this);
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
                case direction.UpLeft:
                    currentState.moveUpLeft();
                    break;
                case direction.UpRight:
                    currentState.moveUpRight();
                    break;
                case direction.DownLeft:
                    currentState.moveDownLeft();
                    break;
                case direction.DownRight:
                    currentState.moveDownRight();
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
       /* public void Update()
        {
            currentState.Update();
        } */

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
           /* if (lifeTime % frameChange == 0)
            {
                this.nextFrame();
            } 
        } */
        public void Draw(SpriteBatch sb)
        {
            currentState.Draw(sb);
        }

        public IKeeseState CurrentState
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


