namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GleeokNeck : EnemyEssentials, IEnemy
    {
        private IEnemy parent;

        public GleeokNeck(IEnemy body)
        {
            this.parent = body;
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.ManhandlaHeadStateList);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.GleeokNeckHealth);
            this.Physics = new Physics(body.Physics.Bounds.Center.ToVector2());
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            this.Physics.IsMoveable = false;
            this.CurrentState = new IdleEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = 0;
            this.DamageTimer = 0;
            this.MoveSpeed = 0;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.HasChild = true;
            this.AI = EnemyAI.NoAI;
            this.IsTransparent = true;
            this.ApplyDamageMod();
            this.ApplyLargeWeightModPos();
            this.ApplyLargeHealthMod();
        }

        public override void Stun(int stunTime)
        {
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            // ignore collisions
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            // ignore obstacles
        }

        public override void Update()
        {
            if (this.parent.IsDead)
            {
                this.Expired = true;
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateGleeockNeckSprite();
        }
    }
}