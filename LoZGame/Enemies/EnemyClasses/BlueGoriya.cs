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
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.BlueGoriyaStateList);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.BlueGoriyaHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.GoriyaMass;
            this.CurrentState = new SpawnEnemyState(this);
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.Cooldown = 0;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.BlueGoriyaDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.BlueGoriyaSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.AI = EnemyAI.Goriya;
            this.ApplyDamageMod();
            this.ApplySmallSpeedMod();
            this.ApplySmallWeightModPos();
            this.ApplyLargeHealthMod();
        }

        public override void Attack()
        {
            this.CurrentState = new AttackingBlueGoriyaState(this);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateBlueGoriyaSprite(this.Physics.CurrentDirection);
        }
    }
}
