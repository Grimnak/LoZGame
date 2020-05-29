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
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>()
            {
                { RandomStateGenerator.StateType.Idle, 1}
            };
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.ManhandlaBodyHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            Physics.IsMovable = false;
            CurrentState = new IdleEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            IsTransparent = true;
            Damage = GameData.Instance.EnemyDamageConstants.DragonDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.ManhandlaMinSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            spawnedChildren = false;
            AI = EnemyAI.NoSpawn;
            DropTable = GameData.Instance.EnemyDropTables.GleeokDropTable;
            IsSpawning = false;
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public override void AddChild()
        {
            if (!spawnedChildren)
            {
                heads = new List<IEnemy>();
                for (int i = 0; i < numHeads; i++)
                {
                    IEnemy head = new GleeokHead(this);
                    heads.Add(head);
                    LoZGame.Instance.GameObjects.Enemies.Add(head);
                }
                spawnedChildren = true;
            }
        }

        public override void Update()
        {
            int Health = 0;
            foreach (IEnemy head in heads)
            {
                if (head.Health.CurrentHealth >= 0)
                {
                    Health += head.Health.CurrentHealth;
                }
            }
            if (Health <= 0 && !IsDead)
            {
                TakeDamage(this.Health.MaxHealth);
                Expired = true;
            }
            base.Update();
        }

        public override void Stun(int stunTime)
        {
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateGleeokBodySprite();
        }
    }
}