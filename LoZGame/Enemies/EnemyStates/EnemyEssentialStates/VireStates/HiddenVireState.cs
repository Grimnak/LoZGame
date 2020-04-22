using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class HiddenVireState : EnemyStateEssentials, IEnemyState
    {
        public HiddenVireState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.CurrentState = this;
        }

        public override void Update()
        {
        }

        public override void Draw()
        {
        }
    }
}
