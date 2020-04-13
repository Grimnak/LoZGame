namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

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
                if (Math.Abs(linkX - spikeX) < (this.spikeCross.Physics.Bounds.Width / 2))
                {
                    if (Math.Abs(linkY - spikeY) > (this.spikeCross.Physics.Bounds.Height / 2))
                    {
                        //Handles case for when link gets to the spikes original position before the spike fully retreats

                        this.spikeCross.MoveSpeed = GameData.Instance.EnemySpeedConstants.SpikeCrossSpeed * (linkY - spikeY) / Math.Abs(linkY - spikeY);
                        this.spikeCross.Attacking = true;
                        this.spikeCross.CurrentState.MoveDown();
                    }

                }
                else if (Math.Abs(linkY - spikeY) < (this.spikeCross.Physics.Bounds.Height / 2))
                {
                    if (Math.Abs(linkX - spikeX) > (this.spikeCross.Physics.Bounds.Width / 2))
                    {
                        //Handles case for when link gets to the spikes original position before the spike fully retreats

                        this.spikeCross.MoveSpeed = GameData.Instance.EnemySpeedConstants.SpikeCrossSpeed * (linkX - spikeX) / Math.Abs(linkX - spikeX);
                        this.spikeCross.Attacking = true;
                        this.spikeCross.CurrentState.MoveRight();
                    }

                }
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.spikeCross.Physics.Location, this.spikeCross.CurrentTint, this.spikeCross.Physics.Depth);
        }
    }
}