﻿namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class FireSnakeHead : EnemyEssentials,  IEnemy
    {
        private IEnemy child;
        private int segmentID;
        private Vector2 passedVelocity;
        private int timeSinceLastPass;

        public FireSnakeHead(Vector2 location)
        {
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.FireSnakeHP);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassData.FireSnakeMass;
            this.Physics.IsMoveable = false;
            this.CurrentState = new IdleFireSnakeState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.FireSnakeDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.FireSnakeSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
            this.segmentID = GameData.Instance.EnemyMiscData.FireSnakeLength;
            this.AddChild();
        }

        public override void Stun(int stunTime)
        {
            base.Stun(stunTime);
            this.child.Stun(stunTime);
        }

        public override void TakeDamage(int damageAmount)
        {
            base.TakeDamage(damageAmount);
            if (child.DamageTimer > 0)
            {
                this.child.TakeDamage(damageAmount);
            }
        }

        public override void AddChild()
        {
            this.child = new FireSnakeSegment(this, segmentID - 1);
            LoZGame.Instance.GameObjects.Enemies.Add(child);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}