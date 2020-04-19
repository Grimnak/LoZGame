﻿namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class OldMan : EnemyEssentials, IEnemy
    {
        private const int BreakingPoint = 25;
        private const float FireballSpeed = 2.5f;
        private readonly ISprite sprite;
        private Point flameOffset;
        private int timesShot;

        public OldMan(Vector2 location)
        {
            this.Physics = new Physics(location);
            this.flameOffset = new Point(130, 0);
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.OldManStateList);
            this.CurrentState = new IdleEnemyState(this);
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.OldManHealth);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.OldManDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.OldManSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.timesShot = 0;
        }

        private Vector2 UnitVectorToPlayer(Vector2 origin)
        {
            Vector2 unitVector = LoZGame.Instance.Link.Physics.Bounds.Center.ToVector2() - origin;
            unitVector.Normalize();
            return unitVector;
        }

        public override void Stun(int stunTime)
        {
        }

        public override void Attack()
        {
            this.CurrentState = new OldManSecretState(this);
        }

        public void ShootFireballs()
        {
            Console.WriteLine("Called Old Man's ShootFireball().");
            this.timesShot++;
            if (timesShot > BreakingPoint)
            {
                this.CurrentState = new OldManSecretState(this);
                this.timesShot = 0;
            }
            else if (!(this.CurrentState is OldManSecretState))
            {
                this.CurrentState = new OldManAngryState(this);
                Vector2 playerVectorOne = this.UnitVectorToPlayer((this.Physics.Bounds.Center - flameOffset).ToVector2());
                Vector2 playerVectorTwo = this.UnitVectorToPlayer((this.Physics.Bounds.Center + flameOffset).ToVector2());
                Vector2 velocityVectorOne = new Vector2(playerVectorOne.X * FireballSpeed, playerVectorOne.Y * FireballSpeed);
                Vector2 velocityVectorTwo = new Vector2(playerVectorTwo.X * FireballSpeed, playerVectorTwo.Y * FireballSpeed);
                Physics fireballOnePhysics = new Physics((this.Physics.Bounds.Center - flameOffset).ToVector2());
                fireballOnePhysics.MovementVelocity = velocityVectorOne;
                Physics fireballTwoPhysics = new Physics((this.Physics.Bounds.Center + flameOffset).ToVector2());
                fireballTwoPhysics.MovementVelocity = velocityVectorTwo;
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new FireballProjectile(fireballOnePhysics));
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new FireballProjectile(fireballTwoPhysics));
                Console.WriteLine("Spawned Old Man's fireballs.");
                Console.WriteLine("Fireball 1 location " + fireballOnePhysics.Location);
                Console.WriteLine("Fireball 2 location " + fireballTwoPhysics.Location);
            }
        }

        public override void TakeDamage(int damageAmount)
        {
        }

        public override void Update()
        {
            this.Physics.SetDepth();
            this.CurrentState.Update();
        }

        public override ISprite CreateCorrectSprite()
        {
            if (this.CurrentState is IdleEnemyState)
            {
                return EnemySpriteFactory.Instance.CreateOldManSprite();
            }
            return EnemySpriteFactory.Instance.CreateAngryOldManSprite();
        }
    }
}