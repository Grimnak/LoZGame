namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class VireEssentials : EnemyStateEssentials, IEnemyState
    {
        public override void MoveLeft()
        {
            // jump left
        }

        public override void MoveRight()
        {
            // jump right
        }

        public override void MoveUp()
        {
            this.Enemy.CurrentState = new UpMovingVireState(this.Enemy);
        }

        public override void MoveDown()
        {
            this.Enemy.CurrentState = new DownMovingVireState(this.Enemy);
        }

        public override void MoveUpLeft()
        {
        }

        public override void MoveUpRight()
        {
        }

        public override void MoveDownLeft()
        {
        }

        public override void MoveDownRight()
        {
        }

        public override void Attack()
        {
        }

        public override void Stop()
        {
        }

        public override void Stun(int stunTime)
        {
        }

        public void Hide()
        {
            this.Enemy.CurrentState = new HiddenVireState(this.Enemy);
        }

        public override void Update()
        {
            base.Update();
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(3);
            }
        }
    }
}