namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class HorizontalSpikeCrossState : IEnemyState
    {
        private readonly SpikeCross spikeCross;
        private readonly ISprite sprite;

        public HorizontalSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            this.spikeCross.Physics.Velocity = new Vector2(1 * spikeCross.AttackFactor, 0);
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
            this.spikeCross.Physics.Move();
            retreatCheck();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.spikeCross.Physics.Location, LoZGame.Instance.DungeonTint);
        }
        private void retreatCheck()
        {
            if (!spikeCross.Retreating)
            {
                if (spikeCross.AttackFactor > 0)
                {
                    if (spikeCross.Physics.Location.X - (BlockSpriteFactory.Instance.TileWidth * 6 + (BlockSpriteFactory.Instance.HorizontalOffset / 2)) >= 0)
                    {
                        spikeCross.Retreating = true;
                      //  spikeCross.AttackFactor = -1;
                        spikeCross.Physics.Velocity = new Vector2 (-1, spikeCross.Physics.Velocity.Y);
                    }
                }
                else
                {
                    if (spikeCross.Physics.Location.X - (BlockSpriteFactory.Instance.TileWidth * 6 + (BlockSpriteFactory.Instance.HorizontalOffset / 2)) <= 0)
                    {
                        spikeCross.Retreating = true;
                       // spikeCross.AttackFactor = 1;
                        spikeCross.Physics.Velocity = new Vector2(1, spikeCross.Physics.Velocity.Y);
                    }
                }
            }
            else
            {
                if (spikeCross.Physics.Location.X <= ((BlockSpriteFactory.Instance.HorizontalOffset / 2) + 3) 
                    || spikeCross.Physics.Location.X >= (BlockSpriteFactory.Instance.TileWidth * 12 + (BlockSpriteFactory.Instance.HorizontalOffset / 2) - 3))
                {
                    spikeCross.Attacking = false;
                    spikeCross.Retreating = false;
                    Stop();
                }
            }
        }
    }
}