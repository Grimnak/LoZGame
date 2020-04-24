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
            Enemy = enemy;
            Sprite = null;
            Enemy.CurrentState = this;
            Enemy.IsTransparent = true;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
        }

        public override void Update()
        {
        }

        public override void Draw()
        {
        }
    }
}
