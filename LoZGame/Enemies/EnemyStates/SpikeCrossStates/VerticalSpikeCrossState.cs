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
            this.spikeCross.Physics.Velocity = new Vector2(0, 1 * spikeCross.MoveSpeed);
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

        public void Die()
        {
        }

        public void Stop()
        {
            this.spikeCross.CurrentState = new IdleSpikeCrossState(this.spikeCross);
        }

        public void Stun(int stunTime)
        {
        }

        public void Update()
        {
            this.spikeCross.Physics.Move();
            retreatCheck();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.spikeCross.Physics.Location, this.spikeCross.CurrentTint);
        }

        private void retreatCheck()
        {
            if (!spikeCross.Retreating)
            {
                if (spikeCross.MoveSpeed > 0)
                {
                    if (spikeCross.Physics.Location.Y - ((BlockSpriteFactory.Instance.TileHeight * 3.5) + (BlockSpriteFactory.Instance.VerticalOffset / 2)) >= 0)
                    {
                        spikeCross.Retreating = true;
                        spikeCross.Physics.Velocity = new Vector2(spikeCross.Physics.Velocity.X, -1);

                    }
                }
                else
                {
                    if (spikeCross.Physics.Location.Y - ((BlockSpriteFactory.Instance.TileHeight * 3.5) + (BlockSpriteFactory.Instance.VerticalOffset / 2)) <= 0)
                    {
                        spikeCross.Retreating = true;
                        spikeCross.Physics.Velocity = new Vector2(spikeCross.Physics.Velocity.X, 1);
                    }
                }
            }
            else
            {
                if (spikeCross.Physics.Location.Y == spikeCross.InitialPos.Y)
                {
                    spikeCross.Attacking = false;
                    spikeCross.Retreating = false;
                    Stop();
                }
            }
        }
    }
}