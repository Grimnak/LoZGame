namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Dragon : EnemyEssentials, IEnemy
    {
        public Dragon(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.DragonStateList);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.DragonHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            this.Physics.IsMoveable = false;
            this.CurrentState = new IdleEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.DragonDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.DragonSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.ApplyDamageMod();
            this.ApplySmallSpeedMod();
            this.ApplyLargeWeightModPos();
            this.ApplyLargeHealthMod();
            this.ApplyLargeHealthMod();
        }

        /// <summary>
        /// Prevents the dragon from moving into the player area in the appropriate room.
        /// </summary>
        private void CheckLeftBound()
        {
            float leftBound = BlockSpriteFactory.Instance.HorizontalOffset + (7 * BlockSpriteFactory.Instance.TileWidth);
            if (this.Physics.Bounds.X < (int)leftBound)
            {
                this.Physics.Bounds = new Rectangle(new Point((int)leftBound, this.Physics.Bounds.Y), new Point(this.Physics.Bounds.Width, this.Physics.Bounds.Height));
                this.Physics.MovementVelocity = Vector2.Zero;
            }
        }

        public override void Stun(int stunTime)
        {
        }

        public override void Attack()
        {
            this.CurrentState = new AttackingDragonState(this);
        }

        public override void Update()
        {
            base.Update();
            this.CheckLeftBound();
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateDragonSprite();
        }
    }
}