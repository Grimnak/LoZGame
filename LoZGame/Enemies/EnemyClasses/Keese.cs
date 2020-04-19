namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Keese : EnemyEssentials, IEnemy
    {
        public Keese(Vector2 location)
        {
            this.Physics = new Physics(location);
            this.CurrentState = new SpawnEnemyState(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.KeeseStatelist);
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.KeeseHealth);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.KeeseMass;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.KeeseDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.MinKeeseSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.AI = EnemyAI.Keese;
            this.MinMaxWander = new Point(GameData.Instance.EnemyMiscConstants.MinDirectionChange, GameData.Instance.EnemyMiscConstants.MaxDirectionChange);
            this.ApplyDamageMod();
            this.ApplySmallSpeedMod();
            this.ApplySmallWeightModPos();
            this.ApplySmallHealthMod();
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateKeeseSprite();
        }
    }
}