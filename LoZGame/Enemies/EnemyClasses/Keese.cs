namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Keese : EnemyEssentials, IEnemy
    {
        public Keese(Vector2 location)
        {
            Physics = new Physics(location);
            CurrentState = new SpawnEnemyState(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.KeeseStateList);
            RandomStateGenerator = new RandomStateGenerator(this);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.KeeseHealth);
            Physics.Mass = GameData.Instance.EnemyMassConstants.KeeseMass;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.KeeseDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.MinKeeseSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Keese;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
            MinMaxWander = new Point(GameData.Instance.EnemyMiscConstants.MinDirectionChange, GameData.Instance.EnemyMiscConstants.MaxDirectionChange);
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplySmallWeightModPos();
            ApplySmallHealthMod();
        }

        public override void Stun(int stunTime)
        {
            TakeDamage(Health.MaxHealth);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateKeeseSprite();
        }
    }
}