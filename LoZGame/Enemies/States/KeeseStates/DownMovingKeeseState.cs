﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DownMovingKeeseState : IKeeseState
    {
        private readonly Keese keese;
        private readonly IEnemySprite sprite;

        public DownMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            this.sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
        }

        public void MoveLeft()
        {
            this.keese.CurrentState = new LeftMovingKeeseState(this.keese);
        }

        public void MoveRight()
        {
            this.keese.CurrentState = new RightMovingKeeseState(this.keese);
        }

        public void MoveUp()
        {
            this.keese.CurrentState = new UpMovingKeeseState(this.keese);
        }

        public void MoveDown()
        {
            // Blank b/c already moving down
        }

        public void MoveUpLeft()
        {
            this.keese.CurrentState = new UpLeftMovingKeeseState(this.keese);
        }

        public void MoveUpRight()
        {
            this.keese.CurrentState = new UpRightMovingKeeseState(this.keese);
        }

        public void MoveDownLeft()
        {
            this.keese.CurrentState = new DownLeftMovingKeeseState(this.keese);
        }

        public void MoveDownRight()
        {
            this.keese.CurrentState = new DownRightMovingKeeseState(this.keese);
        }

        public void TakeDamage()
        {
            this.keese.Health--;
            if (this.keese.Health == 0)
            {
                this.keese.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.keese.CurrentState = new DeadKeeseState(this.keese);
        }

        public void Update()
        {
            this.keese.CurrentLocation = new Vector2(this.keese.CurrentLocation.X, this.keese.CurrentLocation.Y + 2);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.keese.CurrentLocation, Color.White);
        }
    }
}