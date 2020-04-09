namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Keese : EnemyEssentials, IEnemy
    {
        private static int directionChangeMax = LoZGame.Instance.UpdateSpeed * 4;
        private static int directionChangeMin = LoZGame.Instance.UpdateSpeed;

        public int MaxChangeTime => directionChangeMax;

        public int MinChangeTime => directionChangeMin;

        public Keese(Vector2 location)
        {
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.KeeseHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassData.KeeseMass;
            this.CurrentState = new IdleKeeseState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.KeeseDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.MinKeeseSpeed;
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
                if (this.Physics.MovementVelocity.Length() <= GameData.Instance.EnemySpeedData.MaxKeeseSpeed)
                {
                    this.Physics.MovementVelocity += normalVel * GameData.Instance.EnemySpeedData.KeeseAccel;
                }
            }
            else
            {
                if (this.Physics.MovementVelocity.Length() >= GameData.Instance.EnemySpeedData.MinKeeseSpeed)
                {
                    this.Physics.MovementVelocity -= normalVel * GameData.Instance.EnemySpeedData.KeeseAccel;
                }
            }
        }
    }
}