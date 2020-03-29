namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Rope : EnemyEssentials, IEnemy
    {
        public Rope(Vector2 location)
        {
            this.Health = new HealthManager(2);
            this.Physics = new Physics(location);
            this.CurrentState = new LeftMovingRopeState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = 2;
            this.DamageTimer = 0;
            this.MoveSpeed = 1;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }
    }
}