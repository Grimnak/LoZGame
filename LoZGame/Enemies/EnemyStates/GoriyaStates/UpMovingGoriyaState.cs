﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingGoriyaState : IEnemyState
    {
        private readonly Goriya goriya;
        private readonly IEnemySprite sprite;

        public UpMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            this.goriya.VelocityX = 0;
            this.goriya.VelocityY = -1;
            this.sprite = EnemySpriteFactory.Instance.CreateUpMovingGoriyaSprite();
            this.goriya.CurrentState = this;
        }

        public void MoveLeft()
        {
            this.goriya.CurrentState = new LeftMovingGoriyaState(this.goriya);
        }

        public void MoveRight()
        {
            this.goriya.CurrentState = new RightMovingGoriyaState(this.goriya);
        }

        public void MoveUp()
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

        public void Stop()
        {
        }

        public void MoveDown()
        {
            this.goriya.CurrentState = new DownMovingGoriyaState(this.goriya);
        }

        public void Attack()
        {
            this.goriya.CurrentState = new AttackingGoriyaState(this.goriya);
        }

        public void TakeDamage(int damageAmount)
        {
            this.goriya.Health.DamageHealth(damageAmount);
        }

        public void Die()
        {
            this.goriya.CurrentState = new DeadGoriyaState(this.goriya);
        }

        public void Update()
        {
            this.goriya.Physics.Location = new Vector2(this.goriya.Physics.Location.X + this.goriya.VelocityX, this.goriya.Physics.Location.Y + this.goriya.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.goriya.Physics.Location, Color.White);
        }
    }
}