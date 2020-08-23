namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Vire : EnemyEssentials, IEnemy
    {
        public int Cooldown { get; set; }

        public string Direction { get; set; }

        public EntityManager EntityManager { get; set; }

        public Vire(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.VireStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.VireHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.VireMass;
            CurrentState = new SpawnEnemyState(this);
            EntityManager = LoZGame.Instance.GameObjects.Entities;
            Cooldown = 0;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.VireDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.VireSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Vire;
            DropTable = GameData.Instance.EnemyDropTables.VireDropTable;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplySmallWeightModPos();
            ApplySmallHealthMod();
            Physics.Gravity = GameData.Instance.EnemyMiscConstants.VireGravity;
        }

        public override void Stun(int stunTime)
        {
        }

        public override void TakeDamage(int damageAmount)
        {
            if (damageAmount <= 4)
            {
                SpawnVireKeese();
                CurrentState = new HiddenVireState(this);
            }
            base.TakeDamage(damageAmount);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateDownMovingVireSprite();
        }

        private void SpawnVireKeese()
        {
            LoZGame.Instance.GameObjects.Enemies.Add(new VireKeese(Physics.Location));
            LoZGame.Instance.GameObjects.Enemies.Add(new VireKeese(Physics.Location));
        }
    }
}
