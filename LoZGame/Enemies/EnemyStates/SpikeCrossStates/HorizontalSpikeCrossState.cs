﻿namespace LoZClone
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
            this.spikeCross.Physics.MovementVelocity = new Vector2(1 * spikeCross.MoveSpeed, 0);
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
            this.sprite.Draw(this.spikeCross.Physics.Location, this.spikeCross.CurrentTint, this.spikeCross.Physics.Depth);
        }

        private void retreatCheck()
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
    }
}