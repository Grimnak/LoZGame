namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class MoldormSegment : EnemyEssentials, IEnemy
    {
        private IEnemy parent;
        private IEnemy child;
        private bool childAdded;

        public MoldormSegment(IEnemy parent)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = GameData.Instance.EnemyStateWeights.FireSnakeStateList;
            this.parent = parent;
            Physics = new Physics(parent.Physics.Location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.FireSnakeMass;
            Physics.IsMoveable = false;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            CurrentState = new FollowFireSnakeState(this);
            HasChild = false;
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.FireSnakeDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.FireSnakeSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Segment;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
        }

        public override void TakeDamage(int damageAmount)
        {
            if (parent.DamageTimer <= 0)
            {
                parent.TakeDamage(damageAmount);
            }
        }

        public override void UpdateState()
        {
        }

        public override void Stun(int stunTime)
        {
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateFireSnakeSprite();
        }
    }
}
