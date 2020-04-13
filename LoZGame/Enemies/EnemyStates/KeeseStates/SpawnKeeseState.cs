using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class SpawnKeeseState : KeeseEssentials, IEnemyState
    {
        public SpawnKeeseState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = EnemySpriteFactory.Instance.EnemySpawn();
            Console.WriteLine("Spawned!");
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
        }

        public override void Update()
        {
            this.Enemy.UpdateState();
        }
    }
}
