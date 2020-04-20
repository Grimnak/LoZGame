namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GleeokBody : EnemyEssentials, IEnemy
    {
        private bool spawnedChildren;
        List<IEnemy> heads;
        int numHeads = 3 + LoZGame.Instance.Difficulty;

        public GleeokBody(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>()
            {
                { RandomStateGenerator.StateType.Idle, 1}
            };
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.ManhandlaBodyHP);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            this.Physics.IsMoveable = false;
            this.CurrentState = new IdleEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.IsTransparent = true;
            this.Damage = GameData.Instance.EnemyDamageConstants.DragonDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.ManhandlaMinSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.spawnedChildren = false;
            this.AI = EnemyAI.NoSpawn;
            this.IsSpawning = false;
        }

        public override void TakeDamage(int damageAmount)
        {
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public override void AddChild()
        {
            if (!this.spawnedChildren)
            {
                this.heads = new List<IEnemy>();
                for (int i = 0; i < numHeads; i++)
                {
                    IEnemy head = new GleeokHead(this);
                    this.heads.Add(head);
                    LoZGame.Instance.GameObjects.Enemies.Add(head);
                }
                this.spawnedChildren = true;
            }
        }

        public override void Update()
        {
            base.Update();
            int Health = 0;
            foreach (IEnemy head in this.heads)
            {
                if (head.Health.CurrentHealth >= 0)
                {
                    Health += head.Health.CurrentHealth;
                }
            }
            if (Health <= 0)
            {
                this.IsDead = true;
                this.CurrentState.Die();
            }

        }

        public override void Stun(int stunTime)
        {
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateGleeockBodySprite();
        }
    }
}
