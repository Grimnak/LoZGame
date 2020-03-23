namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Dragon : EnemyEssentials, IEnemy
    {
        public EntityManager EntityManager { get; set; }

        public Dragon(Vector2 location)
        {
            this.Health = new HealthManager(10);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.CurrentState = new LeftMovingDragonState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = 1;
            this.DamageTimer = 0;
            this.MoveSpeed = 1;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void TakeDamage(int damageAmount)
        {
            if (this.DamageTimer <= 0)
            {
                this.Health.DamageHealth(damageAmount);
                this.DamageTimer = 100;
            }

            if (this.Health.CurrentHealth <= 0)
            {
                this.CurrentState.Die();
            }

            if (this.DamageTimer > 0 && this.Health.CurrentHealth > 0)
            {
                this.DamageTimer--;
                if (this.DamageTimer % 10 > 5)
                {
                    this.CurrentTint = Color.DarkSlateGray;
                }
                else
                {
                    this.CurrentTint = LoZGame.Instance.DungeonTint;
                }
            }
        }
    }
}