namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class BlueGoriya : EnemyEssentials, IEnemy
    {
        public int Cooldown { get; set; }

        public string Direction { get; set; }

        public EntityManager EntityManager { get; set; }

        public BlueGoriya(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.GoriyaStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.BlueGoriyaHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.GoriyaMass;
            CurrentState = new SpawnEnemyState(this);
            EntityManager = LoZGame.Instance.GameObjects.Entities;
            Cooldown = 0;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.BlueGoriyaDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.BlueGoriyaSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Goriya;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplySmallWeightModPos();
            ApplyLargeHealthMod();
        }

        public override void Attack()
        {
            CurrentState = new AttackingBlueGoriyaState(this);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateBlueGoriyaSprite(Physics.CurrentDirection);
        }
    }
}
