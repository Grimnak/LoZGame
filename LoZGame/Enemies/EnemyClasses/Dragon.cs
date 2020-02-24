namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Dragon : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
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

        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        private readonly EntityManager entity;

        public EntityManager EntityManager { get { return this.entity; } }

        private enum StateEnum
        {
            Idle,
            Left,
            Right,
            Attacking,
        }

        private StateEnum currentStateEnum;

        public Dragon(LoZGame game, EntityManager entity, Vector2 location)
        {
            this.Game = game;
            this.entity = entity;
            this.currentState = new LeftMovingDragonState(this);
            this.CurrentLocation = new Vector2(location.X, location.Y);
            this.Bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, 50, 70);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
        }

        private void GetNewDirection()
        {
            Random randomselect = new Random();
            this.currentStateEnum = (StateEnum)randomselect.Next(0, 3);
        }

        private void UpdateLoc()
        {
            switch (this.currentStateEnum)
            {
                case StateEnum.Attacking:
                    this.currentState.Attack();
                    break;

                case StateEnum.Idle:
                    this.currentState.Stop();
                    break;

                case StateEnum.Left:
                    this.currentState.MoveLeft();
                    break;

                case StateEnum.Right:
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

        public void Draw(SpriteBatch sb)
        {
            this.currentState.Draw(sb);
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

    }
}