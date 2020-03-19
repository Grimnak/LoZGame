﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadDragonState : IEnemyState
    {
        private readonly Dragon dragon;
        private readonly DeadEnemySprite sprite;

        public DeadDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.dragon.CurrentState = this;
            LoZGame.Instance.Drops.AttemptDrop(this.dragon.Physics.Location);
            this.dragon.Expired = true;
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
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

        public void Die()
        {
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void Stun(int stunTime)
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.dragon.Physics.Location, this.dragon.CurrentTint);
        }
    }
}
