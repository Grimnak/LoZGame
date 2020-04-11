namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Dodongo : EnemyEssentials, IEnemy
    {
        public Dodongo(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = GameData.Instance.DefaultEnemyStates.DodongoStatelist;
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.DodongoHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassData.DodongoMass;
            this.Physics.Mass = 10;
            this.Physics.IsMoveable = false;
            this.CurrentState = new LeftMovingDodongoState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.DodongoDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.DodongoSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public override ISprite CreateCorrectSprite()
        {
            switch (this.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    return EnemySpriteFactory.Instance.CreateUpMovingDodongoSprite();
                case Physics.Direction.West:
                    return EnemySpriteFactory.Instance.CreateLeftMovingDodongoSprite();
                case Physics.Direction.South:
                    return EnemySpriteFactory.Instance.CreateDownMovingDodongoSprite();
                default:
                    return EnemySpriteFactory.Instance.CreateRightMovingDodongoSprite();
            }
        }
    }
}