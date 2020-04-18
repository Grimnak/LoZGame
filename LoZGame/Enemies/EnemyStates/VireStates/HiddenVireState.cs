using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class HiddenVireState : VireEssentials, IEnemyState
    {
        public HiddenVireState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = null;
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.Bounds = new Rectangle(this.Enemy.Physics.Bounds.Location, Point.Zero);
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
