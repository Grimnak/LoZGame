namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Goriya : EnemyEssentials, IEnemy
    {
        public int Cooldown { get; set; }

        public string Direction { get; set; }

        public EntityManager EntityManager { get; set; }

        public Goriya(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.GoriyaStatelist);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.RedGoriyaHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.GoriyaMass;
            this.CurrentState = new SpawnGoriyaState(this);
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.Cooldown = 0;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.RedGoriyaDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.GoriyaSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateGoriyaSprite(this.Physics.CurrentDirection);
        }
    }
}
