namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Dragon : EnemyEssentials, IEnemy
    {
        public Dragon(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.DragonStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.DragonHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            Physics.IsMovable = false;
            CurrentState = new IdleEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.DragonDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.DragonSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            DropTable = GameData.Instance.EnemyDropTables.DragonDropTable;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplyLargeWeightModPos();
            ApplyLargeHealthMod();
            ApplyLargeHealthMod();
        }

        /// <summary>
        /// Prevents the dragon from moving into the player area in the appropriate room.
        /// </summary>
        private void CheckLeftBound()
        {
            float leftBound = BlockSpriteFactory.Instance.HorizontalOffset + (7 * BlockSpriteFactory.Instance.TileWidth);
            if (Physics.Bounds.X < (int)leftBound)
            {
                Physics.Bounds = new Rectangle(new Point((int)leftBound, Physics.Bounds.Y), new Point(Physics.Bounds.Width, Physics.Bounds.Height));
                Physics.MovementVelocity = Vector2.Zero;
            }
        }

        public override void Stun(int stunTime)
        {
        }

        public override void Attack()
        {
            CurrentState = new AttackingDragonState(this);
        }

        public override void Update()
        {
            base.Update();
            CheckLeftBound();
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateDragonSprite();
        }
    }
}