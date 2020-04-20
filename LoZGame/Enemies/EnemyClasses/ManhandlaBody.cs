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
        bool test;

        public ManhandlaBody(Vector2 location)
        {
            Console.WriteLine("Passed Loc: " + location);
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.ManhandlaBodyStateList);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.ManhandlaBodyHealth);
            this.Physics = new Physics(location);
            Console.WriteLine("Physics Loc: " + Physics.Location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            this.Physics.IsMoveable = false;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.CurrentState = new IdleEnemyState(this);
            Console.WriteLine("Bounds: " + Physics.Bounds);
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.IsTransparent = true;
            this.Damage = GameData.Instance.EnemyDamageConstants.DragonDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.ManhandlaMinSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.spawnedChildren = false;
            this.AI = EnemyAI.Manhandla;
            this.MinMaxWander = new Point(LoZGame.Instance.UpdateSpeed, LoZGame.Instance.UpdateSpeed * 2);
            this.IsSpawning = false;
            test = false;
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            base.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
            switch (collisionSide)
            {
                case CollisionDetection.CollisionSide.Top:
                case CollisionDetection.CollisionSide.Bottom:
                    this.Physics.MovementVelocity = new Vector2(this.Physics.MovementVelocity.X, -this.Physics.MovementVelocity.Y);
                    break;
                case CollisionDetection.CollisionSide.Left:
                case CollisionDetection.CollisionSide.Right:
                    this.Physics.MovementVelocity = new Vector2(-this.Physics.MovementVelocity.X, this.Physics.MovementVelocity.Y);
                    break;

            }
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
            if (!test)
            {
                Console.WriteLine(this.Physics.Bounds);
            }
            int Health = 0;
            foreach (IEnemy head in this.heads)
            {
                if (head.Health.CurrentHealth >= 0)
                {
                    Health += head.Health.CurrentHealth;
                }
            }
            if (Health <= 0 && !this.IsDead)
            {
                this.TakeDamage(this.Health.MaxHealth);
                this.Expired = true;
            }
            base.Update();
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
