namespace LoZGame
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Gel : IEnemy
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
            Right
        }
;

        private direction currentDirection;

        public Gel()
        {
            this.currentState = new LeftMovingGelState(this);
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