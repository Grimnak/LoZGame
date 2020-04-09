namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Dodongo : EnemyEssentials, IEnemy
    {

        public Dodongo(Vector2 location)
        {
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.DodongoHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = 10;
            this.Physics.IsMoveable = false;
            this.CurrentState = new LeftMovingDodongoState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.DodongoDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.DodongoSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }
    }
}