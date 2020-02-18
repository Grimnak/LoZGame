namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Dodongo : IEnemy
    {
        public Dodongo()
        {
            this.currentState = new LeftMovingDodongoState(this);
            this.CurrentLocation = new Vector2(650, 200);
        }

        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        public Vector2 CurrentLocation;
        private Direction currentDirection;

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }

        private void GetNewDirection()
        {
            Random randomselect = new Random();
            this.CurrentDirection = (Direction)randomselect.Next(0, 5);
        }

        private void UpdateLoc()
        {
            switch (this.CurrentDirection)
            {
                case Direction.Up:
                    this.currentState.MoveUp();
                    break;

                case Direction.Down:
                    this.currentState.MoveDown();
                    break;

                case Direction.Left:
                    this.currentState.MoveLeft();
                    break;

                case Direction.Right:
                    this.currentState.MoveRight();
                    break;

                default:
                    break;
            }

            this.CheckBorder();
            this.currentState.Update();
        }

        private void CheckBorder()
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

        private Direction CurrentDirection { get => this.CurrentDirection1; set => this.CurrentDirection1 = value; }

        private Direction CurrentDirection1 { get => this.CurrentDirection2; set => this.CurrentDirection2 = value; }

        private Direction CurrentDirection2 { get => this.currentDirection; set => this.currentDirection = value; }
    }
}