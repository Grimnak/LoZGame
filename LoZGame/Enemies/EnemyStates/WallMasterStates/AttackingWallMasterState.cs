﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingWallMasterState : IEnemyState
    {
        private readonly WallMaster wallMaster;
        private readonly ISprite sprite;

        public AttackingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            wallMaster.Physics.Velocity = new Vector2(-2, 0);
            this.sprite = EnemySpriteFactory.Instance.CreateAttackingWallMasterSprite();
            this.wallMaster.CurrentState = this;
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void MoveUpLeft()
        {
        }

        public void MoveUpRight()
        {
        }

        public void MoveDownLeft()
        {
        }

        public void MoveDownRight()
        {
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void TakeDamage(int damageAmount)
        {
            this.wallMaster.Health.DamageHealth(damageAmount);
        }

        public void Die()
        {
            this.wallMaster.CurrentState = new DeadWallMasterState(this.wallMaster);
        }

        public void Update()
        {
            this.wallMaster.Physics.Move();
            if (this.wallMaster.Physics.Location.X <= 0)
            {
                this.wallMaster.CurrentState = new RightMovingWallMasterState(this.wallMaster);
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.wallMaster.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}