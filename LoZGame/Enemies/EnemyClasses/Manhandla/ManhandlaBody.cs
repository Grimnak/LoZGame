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
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.ManhandlaBodyStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.ManhandlaBodyHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            Physics.IsMovable = false;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            MoveSpeed = GameData.Instance.EnemySpeedConstants.ManhandlaMinSpeed;
            CurrentState = new IdleEnemyState(this);
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            IsTransparent = true;
            Damage = GameData.Instance.EnemyDamageConstants.DragonDamage;
            DamageTimer = 0;
            CurrentTint = LoZGame.Instance.DefaultTint;
            spawnedChildren = false;
            AI = EnemyAI.Manhandla;
            DropTable = GameData.Instance.EnemyDropTables.ManhandlaDropTable;
            MinMaxWander = new Point(LoZGame.Instance.UpdateSpeed, LoZGame.Instance.UpdateSpeed * 2);
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
                    Physics.MovementVelocity = new Vector2(Physics.MovementVelocity.X, -Physics.MovementVelocity.Y);
                    break;
                case CollisionDetection.CollisionSide.Left:
                case CollisionDetection.CollisionSide.Right:
                    Physics.MovementVelocity = new Vector2(-Physics.MovementVelocity.X, Physics.MovementVelocity.Y);
                    break;

            }
        }

        public override void AddChild()
        {
            if (!spawnedChildren)
            {
                heads = new List<IEnemy>();
                IEnemy northHead = new ManhandlaHead(this, Physics.Direction.North);
                IEnemy southHead = new ManhandlaHead(this, Physics.Direction.South);
                IEnemy eastHead = new ManhandlaHead(this, Physics.Direction.East);
                IEnemy westHead = new ManhandlaHead(this, Physics.Direction.West);
                heads.Add(northHead);
                heads.Add(southHead);
                heads.Add(eastHead);
                heads.Add(westHead);
                LoZGame.Instance.GameObjects.Enemies.Add(northHead);
                LoZGame.Instance.GameObjects.Enemies.Add(southHead);
                LoZGame.Instance.GameObjects.Enemies.Add(eastHead);
                LoZGame.Instance.GameObjects.Enemies.Add(westHead);
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
            return EnemySpriteFactory.Instance.CreateManhandlaBodySprite();
        }
    }
}
