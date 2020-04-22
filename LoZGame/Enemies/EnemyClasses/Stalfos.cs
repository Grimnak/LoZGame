namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Stalfos : EnemyEssentials, IEnemy
    {
        public Stalfos(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.StalfosStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.StalfosHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.StalfosMass;
            CurrentState = new SpawnEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.StalfosDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.StalfosSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Stalfos;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplySmallWeightModPos();
            ApplySmallHealthMod();
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateStalfosSprite();
        }
    }
}
