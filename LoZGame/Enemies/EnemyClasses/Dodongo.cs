namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Dodongo : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private LoZGame game;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public LoZGame Game
        {
            get; set;
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
        private Direction currentDirection;

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }

        public Dodongo(Vector2 location)
        {
            this.Game = LoZGame.Instance;
            this.currentState = new LeftMovingDodongoState(this);
            this.Bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, 32, 16);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
            this.CurrentLocation = new Vector2(location.X, location.Y);
        }

        private void GetNewDirection()
        {
            Random randomselect = new Random();
            this.CurrentDirection = (Direction)randomselect.Next(0, 3);
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

        public void Draw(SpriteBatch spriteBatch)
        {
            this.currentState.Draw(spriteBatch);
        }

        public void OnCollisionResponse(ICollider otherCollider)
        {
            if (otherCollider is IProjectile)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider);
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

        private Direction CurrentDirection { get => this.CurrentDirection1; set => this.CurrentDirection1 = value; }

        private Direction CurrentDirection1 { get => this.CurrentDirection2; set => this.CurrentDirection2 = value; }

        private Direction CurrentDirection2 { get => this.currentDirection; set => this.currentDirection = value; }
    }
}
