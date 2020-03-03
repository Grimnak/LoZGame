﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly ISprite sprite;

        public LeftMovingGelState(Gel gel)
        {
            this.gel = gel;
            this.gel.Physics.Velocity = new Vector2(-2, 0);
            this.sprite = EnemySpriteFactory.Instance.CreateGelSprite();
            this.gel.CurrentState = this;
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            this.gel.CurrentState = new RightMovingGelState(this.gel);
        }

        public void MoveUp()
        {
            this.gel.CurrentState = new UpMovingGelState(this.gel);
        }

        public void MoveDown()
        {
            this.gel.CurrentState = new DownMovingGelState(this.gel);
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
            this.gel.Health.DamageHealth(damageAmount);
        }

        public void Die()
        {
            this.gel.CurrentState = new DeadGelState(this.gel);
        }

        public void Update()
        {
            if (this.gel.ShouldMove)
            {
                this.gel.Physics.Move();
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.gel.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}