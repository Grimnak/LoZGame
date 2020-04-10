namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class Dragon : EnemyEssentials, IEnemy
    {
        public Dragon(Vector2 location)
        {
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.DragonHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassData.DragonMass;
            this.Physics.IsMoveable = false;
            this.CurrentState = new LeftMovingDragonState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.DragonDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.DragonSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        /// <summary>
        /// Prevents the dragon from moving into the player area in the appropriate room.
        /// </summary>
        private void CheckLeftBound()
        {
            int leftBound = BlockSpriteFactory.Instance.HorizontalOffset + (7 * BlockSpriteFactory.Instance.TileWidth);
            if (this.Physics.Bounds.X < leftBound)
            {
                this.Physics.Bounds = new Rectangle(new Point(leftBound, this.Physics.Bounds.Y), new Point(this.Physics.Bounds.Width, this.Physics.Bounds.Height));
                this.Physics.MovementVelocity = Vector2.Zero;
            }
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