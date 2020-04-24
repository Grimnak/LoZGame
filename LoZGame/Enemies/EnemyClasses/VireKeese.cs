namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class VireKeese : EnemyEssentials, IEnemy
    {
        public int Cooldown { get; set; }

        public EntityManager EntityManager { get; set; }

        public VireKeese(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.KeeseStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.KeeseHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.KeeseMass;
            CurrentState = new SpawnEnemyState(this);
            EntityManager = LoZGame.Instance.GameObjects.Entities;
            Cooldown = 0;
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
        }

        public override void Stun(int stunTime)
        {
            TakeDamage(Health.MaxHealth);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateVireKeeseSprite();
        }
    }
}
