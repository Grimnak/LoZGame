namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Likelike : EnemyEssentials, IEnemy
    {
        public int Cooldown { get; set; }

        public string Direction { get; set; }

        public EntityManager EntityManager { get; set; }

        public Likelike(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.LikelikeStateList);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.LikelikeHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.LikelikeMass;
            this.CurrentState = new SpawnLikelikeState(this);
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.Cooldown = 0;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.IsDead = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.LikelikeDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.LikelikeSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateLikelikeSprite();
        }
    }
}
