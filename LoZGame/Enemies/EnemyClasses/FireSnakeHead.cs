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
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.DefaultEnemyStates.FireSnakeStatelist);
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
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.segmentID = GameData.Instance.EnemyMiscData.FireSnakeLength;
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

        public override void UpdateChild()
        {
            if (this.CurrentState is DeadFireSnakeState)
            {
                this.child.Expired = true;
            }
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

        public override void Update()
        {
            base.Update();
            /*foreach (KeyValuePair<RandomStateGenerator.StateType, int> state in this.States)
            {
                Console.WriteLine(state.Key + " || " + state.Value);
            }*/
        }
    }
}
