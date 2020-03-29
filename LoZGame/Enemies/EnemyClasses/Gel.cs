namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Gel : EnemyEssentials, IEnemy
    {
        public bool ShouldMove { get; set; }

        public Gel(Vector2 location)
        {
            this.Health = new HealthManager(2);
            this.Physics = new Physics(location);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = 2;
            this.DamageTimer = 0;
            this.MoveSpeed = 2.5f;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
            this.CurrentState = new IdleGelState(this);
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override void Update()
        {
            this.HandleDamage();
            this.CurrentState.Update();
        }
    }
}