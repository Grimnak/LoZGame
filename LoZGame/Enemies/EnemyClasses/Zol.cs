namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Zol : IEnemy
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

        public bool ShouldMove
        {
            get; set;
        }

        public HealthManager Health { get; set; }

        public int Damage => damage;

        private IEnemyState currentState;
        private int damage = 2;
        private int health = 4;
        private int lifeTime = 0;
        private int timeSinceIdle = 0;
        private int timeInIdle = 0;
        private int movementWaitMax = 12;
        private readonly int directionChange = 40;
        private RandomStateGenerator randomStateGenerator;

        public Zol(Vector2 location)
        {
            this.Health = new HealthManager(health);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.currentState = new LeftMovingZolState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, 25, 25);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
            this.ShouldMove = true;
            this.randomStateGenerator = new RandomStateGenerator(this, 2, 6);
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
                if (timeInIdle++ > movementWaitMax)
                {
                    ShouldMove = !ShouldMove;
                    timeInIdle = 0;
                }
            }
        }

        public void TakeDamage(int damageAmount)
        {
            this.currentState.TakeDamage(damageAmount);
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                this.lifeTime = 0;
            }
            this.decideToMove();
            this.CurrentState.Update();
            this.bounds.X = (int)this.Physics.Location.X;
            this.bounds.Y = (int)this.Physics.Location.Y;
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

        public IEnemyState CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }
        }
    }
}
