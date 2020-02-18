﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingStalfosState : IEnemyState
    {
        private readonly Stalfos stalfos;
        private readonly IStalfosSprite sprite;

        public RightMovingStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            this.sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
        }

        public void MoveLeft()
        {
            this.stalfos.CurrentState = new LeftMovingStalfosState(this.stalfos);
        }

        public void MoveRight()
        {
            // Blank b/c already moving right
        }

        public void MoveUp()
        {
            this.stalfos.CurrentState = new UpMovingStalfosState(this.stalfos);
        }

        public void MoveDown()
        {
            this.stalfos.CurrentState = new DownMovingStalfosState(this.stalfos);
        }

        public void TakeDamage()
        {
            this.stalfos.Health--;
            if (this.stalfos.Health == 0)
            {
                this.stalfos.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.stalfos.CurrentState = new DeadStalfosState(this.stalfos);
        }

        public void Update()
        {
            this.stalfos.CurrentLocation = new Vector2(this.stalfos.CurrentLocation.X + 1, this.stalfos.CurrentLocation.Y);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.stalfos.CurrentLocation, Color.White);
        }
    }
}