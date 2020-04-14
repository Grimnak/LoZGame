using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class SpawnGoriyaState : GoriyaEssentials, IEnemyState
    {
        private int spawnTimer = 0;
        private int spawnTimerMax;

        public SpawnGoriyaState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = EnemySpriteFactory.Instance.CreateEnemySpawn();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
            this.spawnTimerMax = GameData.Instance.EnemyMiscConstants.SpawnTimerMaximum;
        }

        public override void Update()
        {
            this.spawnTimer++;
            this.Sprite.Update();
            if (spawnTimer >= spawnTimerMax)
            {
                this.Enemy.UpdateState();
            }
        }

        public override void Stun(int stunTime)
        {
        }
    }
}
