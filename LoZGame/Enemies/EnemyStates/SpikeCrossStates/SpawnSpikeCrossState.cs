using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class SpawnSpikeCrossState : IEnemyState
    {
        private readonly SpikeCross spikeCross;
        private ISprite sprite;
        private int spawnTimer = 0;
        private int spawnTimerMax;

        public SpawnSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            this.spikeCross.Physics.StopVelocity();
            this.spikeCross.Physics.MovementVelocity = Vector2.Zero;
            this.sprite = EnemySpriteFactory.Instance.CreateEnemySpawn();
            this.spikeCross.CurrentState = this;
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void MoveDown()
        {
            throw new NotImplementedException();
        }

        public void MoveDownLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveDownRight()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void MoveUp()
        {
            throw new NotImplementedException();
        }

        public void MoveUpLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveUpRight()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Stun(int stunTime)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            this.spawnTimer++;
            this.sprite.Update();
            if (spawnTimer >= spawnTimerMax)
            {
                this.spikeCross.CurrentState = new IdleSpikeCrossState(this.spikeCross);
            }
        }
    }
}
