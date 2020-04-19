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
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.VireStateList);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.VireHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.VireMass;
            this.CurrentState = new SpawnVireState(this);
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.Cooldown = 0;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.VireDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.VireSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override void TakeDamage(int damageAmount)
        {
            if (damageAmount <= 4)
            {
                this.SpawnVireKeese();
                this.Expired = true;
            }
            base.TakeDamage(damageAmount);
        }

        public override ISprite CreateCorrectSprite()
        {
            if (this.Physics.CurrentDirection == Physics.Direction.South)
            {
                return EnemySpriteFactory.Instance.CreateDownMovingVireSprite();
            }
            else
            {
                return EnemySpriteFactory.Instance.CreateDownMovingVireSprite();
            }
        }

        public override void Update()
        {
            if (this.Physics.MovementVelocity.X != 0)
            {
                this.Physics.Jump();
            }
            base.Update();
        }

        private void SpawnVireKeese()
        {
            LoZGame.Instance.GameObjects.Enemies.Add(new VireKeese(this.Physics.Location));
            LoZGame.Instance.GameObjects.Enemies.Add(new VireKeese(this.Physics.Location));
        }
    }
}
