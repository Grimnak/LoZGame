namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Dodongo : EnemyEssentials, IEnemy
    {
        public Dodongo(Vector2 location)
        {
            this.Health = new HealthManager(32);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.CurrentState = new LeftMovingDodongoState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
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
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, this.Bounds.Width, this.Bounds.Height);
        }
    }
}