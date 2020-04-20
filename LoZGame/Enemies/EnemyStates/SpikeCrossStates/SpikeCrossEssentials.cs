namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class SpikeCrossEssentials
    {
        public SpikeCross spikeCross;
        private readonly ISprite sprite = EnemySpriteFactory.Instance.CreateSpikeCrossSprite();

        public virtual void MoveLeft()
        {
        }

        public virtual void MoveRight()
        {
        }

        public virtual void MoveUp()
        {
        }

        public virtual void MoveDown()
        {
        }

        public virtual void MoveUpLeft()
        {
        }

        public virtual void MoveUpRight()
        {
        }

        public virtual void MoveDownLeft()
        {
        }

        public virtual void MoveDownRight()
        {
        }

        public virtual void JumpLeft()
        {
        }

        public virtual void JumpRight()
        {
        }

        public virtual void JumpUp()
        {
        }

        public virtual void JumpDown()
        {
        }

        public virtual void JumpUpLeft()
        {
        }

        public virtual void JumpUpRight()
        {
        }

        public virtual void JumpDownLeft()
        {
        }

        public virtual void JumpDownRight()
        {
        }

        public virtual void Attack()
        {
        }

        public virtual void Die()
        {
        }

        public virtual void Stop()
        {
        }

        public void Stun(int stunTime)
        {
        }

        public void Draw()
        {
            this.sprite.Draw(this.spikeCross.Physics.Location, this.spikeCross.CurrentTint, this.spikeCross.Physics.Depth);
        }

        public void Spawn()
        {
        }

        public void retreatCheckHorizontal()
        {
            if (!spikeCross.Retreating)
            {
                if ((int)spikeCross.MoveSpeed > 0)
                {
                    if (spikeCross.Physics.Location.X - GameData.Instance.EnemyMiscConstants.SpikeCrossHorizontalBoundary >= 0)
                    {
                        spikeCross.Retreating = true;
                        spikeCross.Physics.MovementVelocity = new Vector2(-1, spikeCross.Physics.MovementVelocity.Y);
                    }
                }
                else
                {
                    if (spikeCross.Physics.Location.X - GameData.Instance.EnemyMiscConstants.SpikeCrossHorizontalBoundary <= 0)
                    {
                        spikeCross.Retreating = true;
                        spikeCross.Physics.MovementVelocity = new Vector2(1, spikeCross.Physics.MovementVelocity.Y);
                    }
                }
            }
            else
            {
                if (spikeCross.Physics.Location.X == spikeCross.InitialPos.X)
                {
                    spikeCross.Attacking = false;
                    spikeCross.Retreating = false;
                    Stop();
                }
            }
        }
        public void retreatCheckVertical()
        {
            if (!spikeCross.Retreating)
            {
                if ((int)spikeCross.MoveSpeed > 0)
                {
                    if (spikeCross.Physics.Location.Y - GameData.Instance.EnemyMiscConstants.SpikeCrossVertBoundary >= 0)
                    {
                        spikeCross.Retreating = true;
                        spikeCross.Physics.MovementVelocity = new Vector2(spikeCross.Physics.MovementVelocity.X, -1);

                    }
                }
                else
                {
                    if (spikeCross.Physics.Location.Y - GameData.Instance.EnemyMiscConstants.SpikeCrossVertBoundary <= 0)
                    {
                        spikeCross.Retreating = true;
                        spikeCross.Physics.MovementVelocity = new Vector2(spikeCross.Physics.MovementVelocity.X, 1);
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