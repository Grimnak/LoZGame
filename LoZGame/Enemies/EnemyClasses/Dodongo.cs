namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Dodongo : EnemyEssentials, IEnemy
    {
        public Dodongo(Vector2 location)
        {
            this.Health = new HealthManager(32);
            this.Physics = new Physics(location);
            this.Physics.Mass = -1;
            this.CurrentState = new LeftMovingDodongoState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = 4;
            this.DamageTimer = 0;
            this.MoveSpeed = 1;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void Update()
        {
            this.HandleDamage();
            this.CurrentState.Update();
            this.Physics.SetDepth(); ;
        }
    }
}