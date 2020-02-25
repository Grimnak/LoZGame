namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Goriya : IEnemy
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
        private int coolDown;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        private string currentDirection = "Left";
        private readonly EntityManager entity;

        private enum StateEnum
        {
            Up,
            Down,
            Left,
            Right,
            Attacking,
        }

        private StateEnum state;

        public Goriya(Vector2 location)
        {
            this.currentState = new LeftMovingGoriyaState(this);
            this.entity = EntityManager.Instance;
            this.CurrentLocation = new Vector2(location.X, location.Y);
            this.coolDown = 0;
            this.bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
        }

        private void GetNewState()
        {
            Random randomselect = new Random();
            this.state = (StateEnum)randomselect.Next(0, 4);
        }

        private void UpdateLoc()
        {
            switch (this.state)
            {
                case StateEnum.Up:
                    this.currentDirection = "Up";
                    this.currentState.MoveUp();
                    break;

                case StateEnum.Down:
                    this.currentDirection = "Down";
                    this.currentState.MoveDown();
                    break;

                case StateEnum.Left:
                    this.currentDirection = "Left";
                    this.currentState.MoveLeft();
                    break;

                case StateEnum.Right:
                    this.currentDirection = "Right";
                    this.currentState.MoveRight();
                    break;

                case StateEnum.Attacking:
                    this.currentState.Attack();
                    if (this.coolDown == 0)
                    {
                        this.coolDown = 240;
                        this.entity.EnemyProjectileManager.AddEnemyRang(this, this.currentDirection);
                    }

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
            if (this.coolDown > 0)
            {
                this.coolDown--;
            }
            if (this.lifeTime > this.directionChange)
            {
                this.GetNewState();
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

        public string Direction
        {
            get { return this.currentDirection; }
            set { this.currentDirection = value; }
        }
    }
}
