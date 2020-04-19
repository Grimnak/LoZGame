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
        private bool childAdded;

        public FireSnakeSegment(IEnemy parent)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = GameData.Instance.EnemyStateWeights.FireSnakeStatelist;
            this.parent = parent;
            this.Physics = new Physics(parent.Physics.Location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.FireSnakeMass;
            this.Physics.IsMoveable = false;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.CurrentState = new FollowFireSnakeState(this);
            this.HasChild = false;
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.FireSnakeDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.FireSnakeSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.EnemyName = EnemyNames.NoAI;
        }

        public override void TakeDamage(int damageAmount)
        {
            if (this.parent.DamageTimer <= 0)
            {
                this.parent.TakeDamage(damageAmount);
            }
        }

        public override void UpdateState()
        {
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateFireSnakeSprite();
        }
    }
}
