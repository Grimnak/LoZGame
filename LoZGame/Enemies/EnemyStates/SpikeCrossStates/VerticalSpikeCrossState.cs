namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class VerticalSpikeCrossState : IEnemyState
    {
        private readonly SpikeCross spikeCross;
        private readonly IEnemySprite sprite;

        public VerticalSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            this.spikeCross.VelocityX = 0;
            this.spikeCross.VelocityY = 1;
            this.sprite = EnemySpriteFactory.Instance.CreateSpikeCrossSprite();
        }

        public void MoveLeft()
        {
            this.spikeCross.CurrentState = new LeftMovingSpikeCrossState(this.spikeCross);
        }

        public void MoveRight()
        {
            this.spikeCross.CurrentState = new HorizontalSpikeCrossState(this.spikeCross);
        }

        public void MoveUp()
        {
            this.spikeCross.CurrentState = new UpMovingSpikeCrossState(this.spikeCross);
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

        public void TakeDamage()
        {
        }

        public void Die()
        {
        }

        public void Stop()
        {
            this.spikeCross.CurrentState = new IdleSpikeCrossState(this.spikeCross);
        }

        public void Update()
        {
            this.spikeCross.Physics.Location = new Vector2(this.spikeCross.Physics.Location.X + (this.spikeCross.VelocityX * spikeCross.AttackFactor), this.spikeCross.Physics.Location.Y + (this.spikeCross.VelocityY * this.spikeCross.AttackFactor));
            retreatCheck();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.spikeCross.Physics.Location, Color.White);
        }

        private void retreatCheck()
        {
            int spikeX = (int)spikeCross.Physics.Location.X;
            int spikeY = (int)spikeCross.Physics.Location.Y;
            int linkX = (int)LoZGame.Instance.Link.Physics.Location.X;
            int linkY = (int)LoZGame.Instance.Link.Physics.Location.Y;

            if (!spikeCross.Retreating)
            {
                if (spikeCross.AttackFactor > 0)
                {
                    if (spikeCross.Physics.Location.Y - (LoZGame.Instance.TileHeight * 3.5 + (LoZGame.Instance.VerticalOffset / 2)) >= 0)
                    {
                        spikeCross.Retreating = true;
                        spikeCross.AttackFactor = -1;
                    }
                }
                else
                {
                    if (spikeCross.Physics.Location.Y - (LoZGame.Instance.TileHeight * 3.5 + (LoZGame.Instance.VerticalOffset / 2)) <= 0)
                    {
                        spikeCross.Retreating = true;
                        spikeCross.AttackFactor = 1;
                    }
                }
            }
            else
            {
                if (spikeCross.Physics.Location.Y <= ((LoZGame.Instance.VerticalOffset / 2) + 3) || spikeCross.Physics.Location.Y >= (LoZGame.Instance.TileHeight * 7 + (LoZGame.Instance.VerticalOffset / 2) - 3))
                {
                    spikeCross.Attacking = false;
                    spikeCross.Retreating = false;
                    Stop();
                }
            }
        }
    }
}