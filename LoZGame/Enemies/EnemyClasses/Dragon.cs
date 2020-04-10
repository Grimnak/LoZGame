namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class Dragon : EnemyEssentials, IEnemy
    {
        private const float FireballSpeed = 3.5f;
        private const float FireballSpread = MathHelper.PiOver4 / 2;
        private const int NumberFireballs = 3;

        public EntityManager EntityManager { get; set; }

        public Dragon(Vector2 location)
        {
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.DragonHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassData.DragonMass;
            this.Physics.IsMoveable = false;
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.CurrentState = new LeftMovingDragonState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.DragonDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.DragonSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public void ShootFireballs()
        {
            Vector2 velocityVector = this.UnitVectorToPlayer(this.Physics.Bounds.Location.ToVector2());

            velocityVector *= FireballSpeed;
            for (int i = 0; i < NumberFireballs; i++)
            {
                float rotation = ((-1 * (float)(NumberFireballs - 1) / 2.0f) * FireballSpread) + (i * FireballSpread);
                Vector2 rotatedVelocity = this.RotateVector(velocityVector, rotation);
                Physics fireballPhysics = new Physics(this.Physics.Bounds.Location.ToVector2())
                {
                    MovementVelocity = new Vector2(rotatedVelocity.X, rotatedVelocity.Y)
                };
                EntityManager.EnemyProjectileManager.Add(EntityManager.EnemyProjectileManager.Fireball, fireballPhysics);
            }
        }

        /// <summary>
        /// Prevents the dragon from moving into the player area in the appropriate room.
        /// </summary>
        private void CheckLeftBound()
        {
            int leftBound = BlockSpriteFactory.Instance.HorizontalOffset + (7 * BlockSpriteFactory.Instance.TileWidth);
            if (this.Physics.Bounds.X < leftBound)
            {
                this.Physics.Bounds = new Rectangle(new Point(leftBound, this.Physics.Bounds.Y), new Point(this.Physics.Bounds.Width, this.Physics.Bounds.Height));
                this.Physics.MovementVelocity = Vector2.Zero;
            }
        }

        public override void Update()
        {
            base.Update();
            this.CheckLeftBound();
        }
    }
}