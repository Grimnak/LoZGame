namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Likelike : EnemyEssentials, IEnemy
    {
        public int Cooldown { get; set; }

        public EntityManager EntityManager { get; set; }

        public int Timer { get; set; }

        public Likelike(Vector2 location)
        {
            Timer = 0;
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.LikelikeStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.LikelikeHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.LikelikeMass;
            CurrentState = new SpawnEnemyState(this);
            EntityManager = LoZGame.Instance.GameObjects.Entities;
            Cooldown = 0;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            IsDead = false;
            Damage = GameData.Instance.EnemyDamageConstants.LikelikeDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.LikelikeSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public override void Update()
        {
            base.Update();
            if (CurrentState is AttackingLikelikeState)
            {
                Physics.Depth = 1.0f;
            }
        }

        public override void Attack()
        {
            CurrentState = new AttackingLikelikeState(this);
        }

        public override void Stun(int stunTime)
        {
            CurrentState.Stun(stunTime);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateLikelikeSprite();
        }
    }
}
