namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Zol : EnemyEssentials, IEnemy
    {
        public Zol(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.ZolStatelist);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.ZolHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.ZolMass;
            this.CurrentState = new SpawnEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.ZolDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.ZolSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.EnemyName = EnemyNames.Zol;
        }

        private void SpawnGels()
        {
            LoZGame.Instance.GameObjects.Enemies.Add(new Gel(this.Physics.Location));
            LoZGame.Instance.GameObjects.Enemies.Add(new Gel(this.Physics.Location));
        }

        public override void TakeDamage(int damageAmount)
        {
            if (damageAmount <= 4)
            {
                SoundFactory.Instance.PlayEnemyHit();
                this.SpawnGels();
                this.Expired = true;
            }
            else
            {
                SoundFactory.Instance.PlayEnemyDie();
                this.CurrentState.Die();
            }
        }

        public override void Update()
        {
            this.HandleDamage();
            if (!LoZGame.Instance.Players[0].Inventory.HasClock || this.IsSpawning || this.IsDead)
            {
                this.CurrentState.Update();
                this.Physics.SetDepth();
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateZolSprite();
        }

    }
}