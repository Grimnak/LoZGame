namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Zol : EnemyEssentials, IEnemy
    {
        public bool ShouldMove { get; set; }

        public Zol(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = GameData.Instance.DefaultEnemyStates.ZolStatelist;
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.ZolHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassData.ZolMass;
            this.CurrentState = new LeftMovingZolState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.ShouldMove = true;
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.ZolDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.ZolSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override void Update()
        {
            this.HandleDamage();
            this.CurrentState.Update();
            this.Physics.SetDepth();
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateZolSprite();
        }

    }
}