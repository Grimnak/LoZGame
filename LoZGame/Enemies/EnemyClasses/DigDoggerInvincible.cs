namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class DigDoggerInvincible : EnemyEssentials, IEnemy
    {
        private ISprite currentSprite;

        public DigDoggerInvincible(Vector2 location)
        {
            Physics = new Physics(location);
            CurrentState = new SpawnEnemyState(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.DigDoggerStateList);
            RandomStateGenerator = new RandomStateGenerator(this);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.DragonHealth);
            Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            Physics.CurrentDirection = Physics.Direction.None;
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.DragonDamage;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.DragonSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Keese;
            DropTable = GameData.Instance.EnemyDropTables.DragonDropTable;
            MinMaxWander = new Point(GameData.Instance.EnemyMiscConstants.MinDirectionChange, GameData.Instance.EnemyMiscConstants.MaxDirectionChange);
            this.currentSprite = EnemySpriteFactory.Instance.CreateLargeDigDogger(Physics.Direction.None);
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplyLargeWeightModPos();
        }

        public override void UpdateChild()
        {
            IEnemy exposedSelf = new DigDogger(this.Physics.Location, this);
            Point offset = new Point(this.Physics.Bounds.Width / 2) - new Point(EnemySpriteFactory.GetEnemyHeight(exposedSelf) / 2);
            exposedSelf.Physics.Bounds = new Rectangle(exposedSelf.Physics.Bounds.Location + offset, exposedSelf.Physics.Bounds.Size);
            exposedSelf.Physics.SetLocation();
            LoZGame.Instance.GameObjects.Enemies.Add(exposedSelf);
            this.Expired = true;
        }

        public override void TakeDamage(int damageAmount)
        {
            UpdateChild();
        }

        public override void Stun(int stunTime)
        {
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateLargeDigDogger(Physics.CurrentDirection);
        }
    }
}