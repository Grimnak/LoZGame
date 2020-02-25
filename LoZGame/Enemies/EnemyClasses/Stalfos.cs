namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Stalfos : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Vector2 CurrentLocation
        {
            get; set;
        }

        public int VelocityX
        {
            get; set;
        }

        public int VelocityY
        {
            get; set;
        }

        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }

        private Direction currentDirection;

        public Stalfos(Vector2 location)
        {
            this.currentState = new LeftMovingStalfosState(this);
            this.CurrentLocation = new Vector2(location.X, location.Y);
            this.Bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, 30, 35);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
        }

        private void GetNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (Direction)randomselect.Next(0, 3);
        }

        private void UpdateLoc()
        {
            switch (this.currentDirection)
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
            this.currentState.Update();
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
            this.bounds.X = (int)this.CurrentLocation.X;
            this.bounds.Y = (int)this.CurrentLocation.Y;
        }

        public void Draw()
        {
            this.currentState.Draw();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IProjectile)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
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
