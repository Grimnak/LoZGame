namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Keese : EnemyEssentials, IEnemy
    {
        private static int directionChangeMax = LoZGame.Instance.UpdateSpeed * 4;
        private static int directionChangeMin = LoZGame.Instance.UpdateSpeed;

        public int MaxChangeTime => directionChangeMax;

        public int MinChangeTime => directionChangeMin;

        public EnemyDamageData EnemyDamageData { get; set; }

        public EnemySpeedData EnemySpeedData { get; set; }

        public Keese(Vector2 location)
        {
            this.EnemyDamageData = new EnemyDamageData();
            this.EnemySpeedData = new EnemySpeedData();
            this.Health = new HealthManager(EnemyDamageData.KeeseHealth);
            this.Physics = new Physics(location);
            this.CurrentState = new IdleKeeseState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = EnemyDamageData.KeeseDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = EnemySpeedData.MinKeeseSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public void UpdateMoveSpeed(int lifeTime, int directionChange)
        {
            Vector2 normalVel = this.Physics.MovementVelocity / this.Physics.MovementVelocity.Length();
            if (lifeTime < directionChange / 2)
            {
                if (this.Physics.MovementVelocity.Length() <= this.EnemySpeedData.MaxKeeseSpeed)
                {
                    this.Physics.MovementVelocity += normalVel * this.EnemySpeedData.KeeseAccel;
                }
            }
            else
            {
                if (this.Physics.MovementVelocity.Length() >= this.EnemySpeedData.MinKeeseSpeed)
                {
                    this.Physics.MovementVelocity -= normalVel * this.EnemySpeedData.KeeseAccel;
                }
            }
        }
    }
}