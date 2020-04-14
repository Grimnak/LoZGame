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
        }

        public void Die()
        {
        }

        public void Draw()
        {
        }

        public void MoveDown()
        {
        }

        public void MoveDownLeft()
        {
        }

        public void MoveDownRight()
        {
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

        public void MoveUpLeft()
        {
        }

        public void MoveUpRight()
        {
        }

        public void Stop()
        {
        }

        public void Stun(int stunTime)
        {
        }

        public void Spawn()
        {
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
