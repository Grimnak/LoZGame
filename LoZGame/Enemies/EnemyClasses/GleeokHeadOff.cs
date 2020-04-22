namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GleeokHeadOff : EnemyEssentials, IEnemy
    {
        private IEnemy parent;
        private Point parentOffset;
        private List<IEnemy> necksegments;
        private Point neckBase;
        private int maxX;
        private int maxY;

        public GleeokHeadOff(IEnemy body, Point spawnPoint)
        {
            parent = body;
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.GleeockHeadStateList);
            Health = new HealthManager(1);
            Physics = new Physics(spawnPoint.ToVector2());
            Physics.Mass = 1;
            Physics.IsMoveable = false;
            CurrentState = new IdleEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            IsTransparent = true;
            IsKillable = false;
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.FullHeart;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.FireSnakeSpeed;
            DamageTimer = 0;
            MinMaxWander = new Point(LoZGame.Instance.UpdateSpeed);
            CurrentTint = LoZGame.Instance.DefaultTint;
            HasChild = false;
            AI = EnemyAI.GleeokHeadOff;
            IsSpawning = false;
            ApplyDamageMod();
            ApplyLargeSpeedMod();
        }

        public override void Stun(int stunTime)
        {
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public override void Update()
        {
            base.Update();
            Physics.Depth = 1;
            if (parent.IsDead)
            {
                IsDead = true;
                CurrentState.Die();
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateGleeockHeadOffSprite();
        }
    }
}