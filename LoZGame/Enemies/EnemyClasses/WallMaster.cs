namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class WallMaster : EnemyEssentials, IEnemy
    {
        public EnemyDamageData EnemyDamageData { get; set; }

        public EnemySpeedData EnemySpeedData { get; set; }

        public WallMaster(Vector2 location)
        {
            this.EnemyDamageData = new EnemyDamageData();
            this.EnemySpeedData = new EnemySpeedData();
            this.Health = new HealthManager(EnemyDamageData.WallMasterHealth);
            this.Physics = new Physics(location);
            this.CurrentState = new LeftMovingWallMasterState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = EnemyDamageData.WallMasterDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = EnemySpeedData.WallMasterSpeed;
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
    }
}