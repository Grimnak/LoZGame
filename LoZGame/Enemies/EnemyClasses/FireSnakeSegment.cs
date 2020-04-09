namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class FireSnakeSegment : EnemyEssentials,  IEnemy
    {
        private IEnemy parent;
        private IEnemy child;
        public int segmentID;
        private bool hasChild;
        public FireSnakeSegment(IEnemy parent, int segmentID)
        {
            this.parent = parent;
            this.segmentID = segmentID;
            this.Physics = new Physics(parent.Physics.Location);
            this.Physics.Mass = GameData.Instance.EnemyMassData.FireSnakeMass;
            this.Physics.IsMoveable = false;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.CurrentState = new FollowFireSnakeState(this, this.parent);
            this.hasChild = false;
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.FireSnakeDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.FireSnakeSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
            this.AddChild();
        }

        public override void AddChild()
        {
            if (this.segmentID > 0)
            {
                this.hasChild = true;
                this.child = new FireSnakeSegment(this, this.segmentID - 1);
                LoZGame.Instance.GameObjects.Enemies.Add(child);
            }
        }

        public override void TakeDamage(int damageAmount)
        {
            base.TakeDamage(damageAmount);
            if (parent.DamageTimer > 0)
            {
                parent.TakeDamage(damageAmount);
            }
            if (this.hasChild)
            {
                this.child.TakeDamage(damageAmount);
            }
        }

        public override void Stun(int stunTime)
        {
            parent.Stun(stunTime);
            if (this.hasChild)
            {
                this.child.Stun(stunTime);
            }
            this.CurrentState.Stun(stunTime);
        }

        public override void Update()
        {
            if (this.Expired && this.hasChild)
            {
                this.child.Expired = true;
            }
            base.Update();
        }
    }
}
