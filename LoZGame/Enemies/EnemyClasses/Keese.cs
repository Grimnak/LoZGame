namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Keese : EnemyEssentials, IEnemy
    {
        private const float MinMovementSpeed = 1.5f;
        private const float MaxMovementSpeed = 5.0f;

        public float MaxMoveSpeed { get { return MaxMovementSpeed; } }
        public float MinMoveSpeed { get { return MinMovementSpeed; } }

        public Keese(Vector2 location)
        {
            this.Health = new HealthManager(2);
            this.Physics = new Physics(location);
            this.CurrentState = new IdleKeeseState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.MoveSpeed = MinMovementSpeed;
            this.Damage = 2;
            this.DamageTimer = 0;
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