namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class IdleSpikeCrossState : IEnemyState
    {
        private readonly SpikeCross spikeCross;
        private readonly ISprite sprite;

        public IdleSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            this.spikeCross.Physics.StopVelocity();
            this.sprite = EnemySpriteFactory.Instance.CreateSpikeCrossSprite();
            this.spikeCross.CurrentState = this;
        }

        public void MoveLeft()
        {
            this.spikeCross.CurrentState = new HorizontalSpikeCrossState(this.spikeCross);
        }

        public void MoveRight()
        {
            this.spikeCross.CurrentState = new HorizontalSpikeCrossState(this.spikeCross);
        }

        public void MoveUp()
        {
            this.spikeCross.CurrentState = new VerticalSpikeCrossState(this.spikeCross);
        }

        public void MoveDown()
        {
            this.spikeCross.CurrentState = new VerticalSpikeCrossState(this.spikeCross);
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

        public void Die()
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
            this.CheckForLink();
            this.sprite.Update();
        }

        private void CheckForLink()
        {
            int spikeX = (int)this.spikeCross.Physics.Location.X;
            int spikeY = (int)this.spikeCross.Physics.Location.Y;
            int linkX = (int)LoZGame.Instance.Link.Physics.Location.X;
            int linkY = (int)LoZGame.Instance.Link.Physics.Location.Y;

            if (!this.spikeCross.Attacking)
            {
                if (spikeX == linkX)
                {
                    this.spikeCross.Attacking = true;
                    this.spikeCross.MoveSpeed = 3 * (linkY - spikeY) / Math.Abs(linkY - spikeY);
                    this.spikeCross.CurrentState.MoveDown();
                }
                else if (spikeY == linkY)
                {
                    this.spikeCross.Attacking = true;
                    this.spikeCross.MoveSpeed = 3 * (linkX - spikeX) / Math.Abs(linkX - spikeX);
                    this.spikeCross.CurrentState.MoveRight();
                }
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.spikeCross.Physics.Location, this.spikeCross.CurrentTint);
        }
    }
}