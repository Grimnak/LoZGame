namespace LoZClone
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
        private bool childAdded;

        public FireSnakeHead(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.FireSnakeStatelist);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.FireSnakeHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.FireSnakeMass;
            this.Physics.IsMoveable = false;
            this.CurrentState = new IdleFireSnakeState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.IsDead = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.FireSnakeDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.FireSnakeSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.segmentID = GameData.Instance.EnemyMiscConstants.FireSnakeLength;
            this.HasChild = true;
        }

        public override void TakeDamage(int damageAmount)
        {
            if (this.HasChild)
            {
                this.child.TakeDamage(damageAmount);
            }
            else
            {
                base.TakeDamage(damageAmount);
            }
        }

        public override void UpdateChild()
        {
            this.child.UpdateChild();
            this.child.Physics.MovementVelocity = this.Physics.MovementVelocity;
        }

        public override void AddChild()
        {
            this.child = new FireSnakeSegment(this, segmentID - 1);
            LoZGame.Instance.GameObjects.Enemies.Add(child);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateFireSnakeSprite();
        }
    }
}
