namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Keese : IEnemy
    {
        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        public Vector2 CurrentLocation;

        private enum direction
        {
            Up,
            Down,
            Left,
            Right,
            UpLeft,
            UpRight,
            DownLeft,
            DownRight
        }
;

        private direction currentDirection;

        public Keese()
        {
            this.currentState = new LeftMovingKeeseState(this);
            this.CurrentLocation = new Vector2(650, 200);
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (direction)randomselect.Next(0, 7);
        }

        private void updateLoc()
        {
            switch (this.currentDirection)
            {
                case direction.Up:
                    this.currentState.MoveUp();
                    break;

                case direction.Down:
                    this.currentState.MoveDown();
                    break;

                case direction.Left:
                    this.currentState.MoveLeft();
                    break;

                case direction.Right:
                    this.currentState.MoveRight();
                    break;

                case direction.UpLeft:
                    this.currentState.MoveUpLeft();
                    break;

                case direction.UpRight:
                    this.currentState.MoveUpRight();
                    break;

                case direction.DownLeft:
                    this.currentState.MoveDownLeft();
                    break;

                case direction.DownRight:
                    this.currentState.MoveDownRight();
                    break;

                default:
                    break;
            }

            this.checkBorder();
            this.currentState.Update();
        }

        private void checkBorder()
        {
            if (this.CurrentLocation.Y < 30)
            {
                this.CurrentLocation = new Vector2(this.CurrentLocation.X, 30);
                this.lifeTime = this.directionChange + 1;
            }

            if (this.CurrentLocation.Y > 450)
            {
                this.CurrentLocation = new Vector2(this.CurrentLocation.X, 450);
                this.lifeTime = this.directionChange + 1;
            }

            if (this.CurrentLocation.X < 30)
            {
                this.CurrentLocation = new Vector2(30, this.CurrentLocation.Y);
                this.lifeTime = this.directionChange + 1;
            }

            if (this.CurrentLocation.X > 770)
            {
                this.CurrentLocation = new Vector2(770, this.CurrentLocation.Y);
                this.lifeTime = this.directionChange + 1;
            }
        }

        public void TakeDamage()
        {
            this.currentState.TakeDamage();
        }

        public void Die()
        {
            this.currentState.Die();
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