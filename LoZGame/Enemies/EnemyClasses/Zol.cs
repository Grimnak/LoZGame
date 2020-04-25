namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;

    public class Zol : EnemyEssentials, IEnemy
    {
        public Zol(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.ZolStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.ZolHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.ZolMass;
            CurrentState = new SpawnEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.ZolDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.ZolSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Zol;
            DropTable = GameData.Instance.EnemyDropTables.ZolDropTable;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplyLargeWeightModPos();
            ApplySmallHealthMod();
        }

        public override void Stun(int stunTime)
        {
        }

        public override void TakeDamage(int damageAmount)
        {
            if (damageAmount <= 4)
            {
                SoundFactory.Instance.PlayEnemyHit();
                SpawnGels();
                Expired = true;
            }
            else
            {
                SoundFactory.Instance.PlayEnemyDie();
                IsDead = true;
                CurrentState.Die();
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateZolSprite();
        }

        private void SpawnGels()
        {
            LoZGame.Instance.GameObjects.Enemies.Add(new Gel(Physics.Location));
            LoZGame.Instance.GameObjects.Enemies.Add(new Gel(Physics.Location));
        }
    }
}