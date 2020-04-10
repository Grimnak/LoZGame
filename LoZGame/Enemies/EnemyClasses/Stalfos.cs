namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Stalfos : EnemyEssentials, IEnemy
    {

        public Stalfos(Vector2 location)
        {
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.StalfosHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassData.StalfosMass;
            this.CurrentState = new LeftMovingStalfosState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.StalfosDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.StalfosSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }
        public ISprite CreateCorrectSprite()
        {
            return ItemSpriteFactory.Instance.Fairy();
        }
    }
}
