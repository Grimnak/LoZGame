namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Keese : EnemyEssentials, IEnemy
    {
        private const float MinMovementSpeed = 1.5f;
        private const float MaxMovementSpeed = 5.0f;
        private const float Accel = 0.025f;
        private static int directionChangeMax = LoZGame.Instance.UpdateSpeed * 4;
        private static int directionChangeMin = LoZGame.Instance.UpdateSpeed;

        public float MaxMoveSpeed { get { return MaxMovementSpeed; } }

        public float MinMoveSpeed { get { return MinMovementSpeed; } }

        public float Acceleration => Accel;

        public int MaxChangeTime => directionChangeMax;

        public int MinChangeTime => directionChangeMin;

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

        public void UpdateMoveSpeed(int lifeTime, int directionChange)
        {
            Vector2 normalVel = this.Physics.MovementVelocity / this.Physics.MovementVelocity.Length();
            if (lifeTime < directionChange / 2)
            {
                if (this.Physics.MovementVelocity.Length() <= this.MaxMoveSpeed)
                {
                    this.Physics.MovementVelocity += normalVel * this.Acceleration;
                }
            }
            else
            {
                if (this.Physics.MovementVelocity.Length() >= this.MinMoveSpeed)
                {
                    this.Physics.MovementVelocity -= normalVel * this.Acceleration;
                }
            }
        }
    }
}