namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Gel : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;
        private bool expired;

        public bool Expired { get { return this.expired; } set { this.expired = value; } }

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Physics Physics { get; set; }

        public bool ShouldMove
        {
            get; set;
        }

        public HealthManager Health { get; set; }

        public int Damage => damage;

        private IEnemyState currentState;
        private int damage = 1;
        private int health = 1;
        private int timeInIdle = 0;
        private int timeSinceIdle = 0;
        private int movementWaitMax = 24;
        private int idleWaitMax = 12;
        private RandomStateGenerator randomStateGenerator;

        public Gel(Vector2 location)
        {
            this.Health = new HealthManager(health);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.currentState = new LeftMovingGelState(this);
            this.bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Physics.Location = new Vector2(location.X, location.Y);
            this.ShouldMove = true;
            this.randomStateGenerator = new RandomStateGenerator(this, 2, 6);
            this.expired = false;
        }

        private void decideToMove()
        {
            if (ShouldMove)
            {
                if (timeSinceIdle++ > movementWaitMax)
                {
                    ShouldMove = !ShouldMove;
                    timeSinceIdle = 0;
                }
            }
            else
            {
                if (timeInIdle++ > idleWaitMax)
                {
                    ShouldMove = !ShouldMove;
                    timeInIdle = 0;
                    randomStateGenerator.Update();
                }
            }
        }

        public void TakeDamage(int damageAmount)
        {
            this.currentState.TakeDamage(damageAmount);
        }

        public void Die()
        {
            this.currentState.Die();
        }

        public void Update()
        {
            this.decideToMove();
            this.CurrentState.Update();
            this.bounds.X = (int)this.Physics.Location.X;
            this.bounds.Y = (int)this.Physics.Location.Y;
            if (this.Health.CurrentHealth <= 0)
            {
                this.CurrentState = new DeadGelState(this);
            }
        }

        public void Draw()
        {
            this.currentState.Draw();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            enemyCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public IEnemyState CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }
        }
    }
}
