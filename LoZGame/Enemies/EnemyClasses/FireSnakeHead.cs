namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class FireSnakeHead : EnemyEssentials,  IEnemy
    {
        private List<IEnemy> children;
        private Vector2 passedVelocity;
        private int timeSinceLastPass;
        private bool spawnedChildren;

        public FireSnakeHead(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.FireSnakeStatelist);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.FireSnakeHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.FireSnakeMass;
            this.Physics.IsMoveable = false;
            this.CurrentState = new IdleEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.FireSnakeDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.FireSnakeSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.HasChild = true;
            this.children = new List<IEnemy>();
            this.spawnedChildren = false;
            this.EnemyName = EnemyNames.Firesnakehead;
            this.IsSpawning = false;
            this.ApplyDamageMod();
            this.ApplySmallSpeedMod();
            this.ApplySmallWeightModPos();
            this.ApplyLargeHealthMod();
        }

        public override void TakeDamage(int damageAmount)
        {
            if (this.children.Count > 0 && this.DamageTimer <= 0)
            {
                this.DamageTimer = LoZGame.Instance.UpdateSpeed / 2;
                this.children[this.children.Count - 1].Expired = true;
                this.children.RemoveAt(this.children.Count - 1);
            }
            else
            {
                base.TakeDamage(damageAmount);
            }
        }

        public override void UpdateChild()
        {
            if (this.children.Count > 0)
            {
                for (int i = this.children.Count - 1; i > 0; i--)
                {
                    this.children[i].Physics.MovementVelocity = this.children[i - 1].Physics.MovementVelocity;
                }
                this.children[0].Physics.MovementVelocity = this.Physics.MovementVelocity;
            }
        }

        public override void AddChild()
        {
            if (!this.spawnedChildren)
            {
                for (int i = 0; i < GameData.Instance.EnemyMiscConstants.FireSnakeLength; i++)
                {
                    IEnemy child = new FireSnakeSegment(this);
                    this.children.Add(child);
                    LoZGame.Instance.GameObjects.Enemies.Add(child);
                }
                this.spawnedChildren = true;
            }
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
