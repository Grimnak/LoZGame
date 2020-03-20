namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Rope : IEnemy
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

        public int VelocityX
        {
            get; set;
        }

        public int VelocityY
        {
            get; set;
        }

        public HealthManager Health { get; set; }

        public Color CurrentTint { get; set; }

        public int MoveSpeed { get; set; }

        public int Damage => damage;

        public int DamageTimer { get; set; }

        public bool Attacking
        {
            get; set;
        }

        private IEnemyState currentState;
        private int damage = 1;
        private int health = 1;

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }

        private Direction currentDirection;

        public Rope(Vector2 location)
        {
            this.Health = new HealthManager(health);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.currentState = new LeftMovingRopeState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
            Attacking = false;
            this.expired = false;
            this.DamageTimer = 0;
            this.MoveSpeed = 1;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (Direction)randomselect.Next(0, 3);
        }

        private void updateLoc()
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
        public void Stun(int stunTime)
        {
            this.currentState.Stun(stunTime);
        }

        public void TakeDamage(int damageAmount)
        {
            if (this.DamageTimer <= 0)
            {
                this.Health.DamageHealth(damageAmount);
                this.DamageTimer = 50;
            }
            if (this.Health.CurrentHealth <= 0)
            {
                this.currentState.Die();
            }
            this.HandleDamage();
        }

        private void DamagePushback()
        {
            if (Math.Abs((int)this.Physics.Velocity.X) != 0 || Math.Abs((int)this.Physics.Velocity.Y) != 0)
            {
                this.Physics.Move();
                this.Physics.Accelerate();
            }
        }

        private void HandleDamage()
        {
            if (this.DamageTimer > 0 && this.Health.CurrentHealth > 0)
            {
                this.DamageTimer--;
                if (this.DamageTimer % 10 > 5)
                {
                    this.CurrentTint = Color.DarkSlateGray;
                }
                else
                {
                    this.CurrentTint = Color.White;
                }
                this.DamagePushback();
            }
        }

        public void Update()
        {
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