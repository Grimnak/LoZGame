namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class PolsVoice : EnemyEssentials, IEnemy
    {
        public int Cooldown { get; set; }

        public string Direction { get; set; }

        public EntityManager EntityManager { get; set; }

        public PolsVoice(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.PolsVoiceStateList);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.PolsVoiceHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.PolsVoiceMass;
            this.CurrentState = new SpawnEnemyState(this);
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.Cooldown = 0;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.PolsVoiceDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.PolsVoiceSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.AI = EnemyAI.PolsVoice;
            this.ApplyDamageMod();
            this.ApplySmallSpeedMod();
            this.ApplySmallWeightModPos();
            this.ApplySmallHealthMod();
            this.Physics.Gravity = GameData.Instance.EnemyMiscConstants.PolsVoiceGravity;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreatePolsVoiceSprite();
        }
    }
}
