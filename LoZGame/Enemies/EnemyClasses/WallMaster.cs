namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class WallMaster : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Physics Physics { get; set; }

        public int VelocityX
        {
            get; set;
        }

        public int VelocityY
        {
            get; set;
        }

        public int Health { get { return health; } set { health = value; } }

        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;

        private enum direction
        {
            Up,
            Down,
            Left,
            Right
        }

        private direction currentDirection;


        public WallMaster(Vector2 location)
        {
            this.Physics = new Physics(new Vector2(location.X, location.Y), new Vector2(0, 0), new Vector2(0, 0));
            this.currentState = new LeftMovingWallMasterState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, 25, 25);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (direction)randomselect.Next(0, 3);
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
            this.updateLoc();
            if (this.lifeTime > this.directionChange)
            {
                this.getNewDirection();
                this.lifeTime = 0;
            }
            this.bounds.X = (int)this.Physics.Location.X;
            this.bounds.Y = (int)this.Physics.Location.Y;
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
    }
}
