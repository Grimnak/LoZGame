namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class DigDogger : EnemyEssentials, IEnemy
    {
        IEnemy protectedSelf;

        public DigDogger(Vector2 location, IEnemy parent)
        {
            protectedSelf = parent;
            Physics = new Physics(location);
            CurrentState = new SpawnEnemyState(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.DigDoggerStateList);
            RandomStateGenerator = new RandomStateGenerator(this);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.DigDoggerHealth);
            Physics.Mass = GameData.Instance.EnemyMassConstants.DigDoggerSmallMass;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.DigDoggerDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.DigDoggerFleeSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.SmallDigDogger;
            DropTable = GameData.Instance.EnemyDropTables.DigDoggerDropTable;
            MinMaxWander = new Point(GameData.Instance.EnemyMiscConstants.MinDirectionChange, GameData.Instance.EnemyMiscConstants.MaxDirectionChange);
            Physics.IsMoveable = false;
            ApplyDamageMod();
            ApplyLargeSpeedMod();
            ApplyLargeWeightModPos();
            ApplyLargeHealthMod();
        }

        public override void Stun(int stunTime)
        {
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateSmallDigDogger(Physics.CurrentDirection);
        }
    }
}