﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class RedGoriya : EnemyEssentials, IEnemy
    {
        public RedGoriya(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.GoriyaStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.RedGoriyaHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.GoriyaMass;
            CurrentState = new SpawnEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.RedGoriyaDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.GoriyaSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Goriya;
            DropTable = GameData.Instance.EnemyDropTables.RedGoriyaDropTable;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplySmallWeightModPos();
            ApplySmallHealthMod();
        }

        public override void Attack()
        {
            CurrentState = new AttackingGoriyaState(this);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateGoriyaSprite(Physics.CurrentDirection);
        }
    }
}
