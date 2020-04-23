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
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.PolsVoiceStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.PolsVoiceHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.PolsVoiceMass;
            CurrentState = new SpawnEnemyState(this);
            EntityManager = LoZGame.Instance.GameObjects.Entities;
            Cooldown = 0;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.PolsVoiceDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.PolsVoiceSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.PolsVoice;
            DropTable = GameData.Instance.EnemyDropTables.PolsVoiceDropTable;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplySmallWeightModPos();
            ApplySmallHealthMod();
            Physics.Gravity = GameData.Instance.EnemyMiscConstants.PolsVoiceGravity;
        }

        public override void Stun(int stunTime)
        {
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreatePolsVoiceSprite();
        }
    }
}
