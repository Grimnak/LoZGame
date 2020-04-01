namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    public class Dragon : EnemyEssentials, IEnemy
    {
        private const float FireballSpeed = 3.5f;
        private const float FireballSpread = MathHelper.PiOver4 / 2;
        private const int NumberFireballs = 3;

        public EntityManager EntityManager { get; set; }

        public Dragon(Vector2 location)
        {
            this.Health = new HealthManager(32);
            this.Physics = new Physics(location);
            this.Physics.Mass = -1;
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.CurrentState = new LeftMovingDragonState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = 4;
            this.DamageTimer = 0;
            this.MoveSpeed = 1;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public void ShootFireballs()
        {
            Vector2 playerVector = this.UnitVectorToPlayer(this.Physics.Location);
            Vector2 velocityVector;
            if (playerVector.X < 0)
            {
                velocityVector = new Vector2(playerVector.X * FireballSpeed, playerVector.Y * FireballSpeed);
            } else
            {
                velocityVector = new Vector2(-1 * FireballSpeed, 0);
            }
            for (int i = 0; i < NumberFireballs; i++)
            {
                float rotation = ((-1 * ((NumberFireballs - 1) / 2)) * FireballSpread) + (i * FireballSpread);
                Vector2 rotatedVelocity = this.RotateVector(velocityVector, rotation);
                Vector2 fireBallLocation = new Vector2(this.Physics.Location.X, this.Physics.Location.Y);
                Physics fireballPhysics = new Physics(fireBallLocation);
                fireballPhysics.MovementVelocity = rotatedVelocity;
                EntityManager.EnemyProjectileManager.Add(EntityManager.EnemyProjectileManager.Fireball, fireballPhysics);
            }
        }

        private void CheckLeftBound()
        {
            int leftBound = BlockSpriteFactory.Instance.HorizontalOffset + (7 * BlockSpriteFactory.Instance.TileWidth);
            if (this.Physics.Bounds.X < leftBound)
            {
                this.Physics.Bounds = new Rectangle(new Point(leftBound, this.Physics.Bounds.Y), new Point(this.Physics.Bounds.Width, this.Physics.Bounds.Height));
                this.RandomStateGenerator.Update();
            }
        }

        public override void Update()
        {
            base.Update();
            this.CheckLeftBound();
        }
    }
}