namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ManhandlaBody : EnemyEssentials, IEnemy
    {
        private bool spawnedChildren;
        List<IEnemy> heads;

        public ManhandlaBody(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.ManhandlaBodyStateList);
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
            this.AI = EnemyAI.Manhandla;
            this.MinMaxWander = new Point(LoZGame.Instance.UpdateSpeed * 3, LoZGame.Instance.UpdateSpeed * 6);
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
                IEnemy northHead = new ManhandlaHead(this, Physics.Direction.North);
                IEnemy southHead = new ManhandlaHead(this, Physics.Direction.South);
                IEnemy eastHead = new ManhandlaHead(this, Physics.Direction.East);
                IEnemy westHead = new ManhandlaHead(this, Physics.Direction.West);
                this.heads.Add(northHead);
                this.heads.Add(southHead);
                this.heads.Add(eastHead);
                this.heads.Add(westHead);
                LoZGame.Instance.GameObjects.Enemies.Add(northHead);
                LoZGame.Instance.GameObjects.Enemies.Add(southHead);
                LoZGame.Instance.GameObjects.Enemies.Add(eastHead);
                LoZGame.Instance.GameObjects.Enemies.Add(westHead);
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
            Console.WriteLine(Health);
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
            return EnemySpriteFactory.Instance.CreateManhandlaBodySprite();
        }
    }
}
