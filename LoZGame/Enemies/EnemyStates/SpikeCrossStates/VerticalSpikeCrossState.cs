namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class VerticalSpikeCrossState : IEnemyState
    {
        private readonly SpikeCross spikeCross;
        private readonly ISprite sprite;

        public VerticalSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            this.spikeCross.VelocityX = 0;
            this.spikeCross.VelocityY = 1;
            this.sprite = EnemySpriteFactory.Instance.CreateSpikeCrossSprite();
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

        public void TakeDamage(int damageAmount)
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
            this.sprite.Draw(this.spikeCross.Physics.Location, LoZGame.Instance.DungeonTint);
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
                    if (spikeCross.Physics.Location.Y - (BlockSpriteFactory.Instance.TileHeight * 3.5 + (BlockSpriteFactory.Instance.VerticalOffset / 2)) >= 0)
                    {
                        spikeCross.Retreating = true;
                        spikeCross.AttackFactor = -1;
                    }
                }
                else
                {
                    if (spikeCross.Physics.Location.Y - (BlockSpriteFactory.Instance.TileHeight * 3.5 + (BlockSpriteFactory.Instance.VerticalOffset / 2)) <= 0)
                    {
                        spikeCross.Retreating = true;
                        spikeCross.AttackFactor = 1;
                    }
                }
            }
            else
            {
                if (spikeCross.Physics.Location.Y <= ((BlockSpriteFactory.Instance.VerticalOffset / 2) + 3) 
                    || spikeCross.Physics.Location.Y >= (BlockSpriteFactory.Instance.TileHeight * 7 + (BlockSpriteFactory.Instance.VerticalOffset / 2) - 3))
                {
                    spikeCross.Attacking = false;
                    spikeCross.Retreating = false;
                    Stop();
                }
            }
        }
    }
}