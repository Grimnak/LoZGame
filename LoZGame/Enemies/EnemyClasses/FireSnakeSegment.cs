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
            this.HasChild = false;
            this.Expired = false;
            this.IsDead = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.FireSnakeDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.FireSnakeSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public override void AddChild()
        {
            if (this.segmentID > 0)
            {
                this.HasChild = true;
                this.child = new FireSnakeSegment(this, this.segmentID - 1);
                LoZGame.Instance.GameObjects.Enemies.Add(child);
            }
        }

        public override void TakeDamage(int damageAmount)
        {
            if (this.HasChild)
            {
                this.child.TakeDamage(damageAmount);
            }
            else
            {
                this.parent.HasChild = false;
                this.Expired = true;
            }
        }

        public override void UpdateChild()
        {
            if (this.HasChild)
            {
                this.child.UpdateChild();
                this.child.Physics.MovementVelocity = this.Physics.MovementVelocity;
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateFireSnakeSprite();
        }
    }
}
