namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class FireSnakeSegment : EnemyEssentials, IEnemy
    {
        private IEnemy parent;
        private IEnemy child;
        private int segmentID;
        private bool hasChild;
        private bool childAdded;

        public FireSnakeSegment(IEnemy parent, int segmentID)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = GameData.Instance.EnemyStateWeights.FireSnakeStatelist;
            this.parent = parent;
            this.segmentID = segmentID;
            this.Physics = new Physics(parent.Physics.Location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.FireSnakeMass;
            this.Physics.IsMoveable = false;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.CurrentState = new FollowFireSnakeState(this);
            this.hasChild = false;
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.FireSnakeDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.FireSnakeSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
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
            if (parent.DamageTimer > 0)
            {
                parent.TakeDamage(damageAmount);
            }
            if (this.hasChild)
            {
                this.child.TakeDamage(damageAmount);
            }
        }

        public override void UpdateChild()
        {
            if (this.hasChild)
            {
                if (this.Expired)
                {
                    this.child.Expired = true;
                }
                this.child.UpdateChild();
                this.child.Physics.MovementVelocity = this.Physics.MovementVelocity;
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

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateFireSnakeSprite();
        }
    }
}
