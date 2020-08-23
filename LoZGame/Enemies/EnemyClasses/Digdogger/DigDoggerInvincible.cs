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
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.DigDoggerHealth);
            Physics.Mass = GameData.Instance.EnemyMassConstants.DigDoggerLargeMass;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            Physics.CurrentDirection = Physics.Direction.None;
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.DigDoggerDamage;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.DigDoggerSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            IsBossPart = true;
            AI = EnemyAI.LargeDigDogger;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
            MinMaxWander = new Point(GameData.Instance.EnemyMiscConstants.MinDirectionChange, GameData.Instance.EnemyMiscConstants.MaxDirectionChange);
            Physics.IsMovable = false;
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