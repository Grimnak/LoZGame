namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Rope : EnemyEssentials, IEnemy
    {
        public bool Attacking { get; set; }

        public string Direction { get; set; }

        private EnemyDamageData enemyDamageData;
        private EnemySpeedData enemySpeedData;

        public Rope(Vector2 location)
        {
            this.enemyDamageData = new EnemyDamageData();
            this.enemySpeedData = new EnemySpeedData();
            this.Health = new HealthManager(2);
            this.Physics = new Physics(location);
            this.CurrentState = new LeftMovingRopeState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = enemyDamageData.RopeDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = enemySpeedData.RopeSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
            this.Attacking = false;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.Attacking == true)
            {
                this.Attacking = false;
            }
            base.OnCollisionResponse(otherCollider, collisionSide);
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.Attacking == true)
            {
                this.Attacking = false;
            }

            base.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }
    }
}