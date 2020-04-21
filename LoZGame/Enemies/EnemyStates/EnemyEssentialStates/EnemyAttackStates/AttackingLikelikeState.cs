using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class AttackingLikelikeState : EnemyStateEssentials, IEnemyState
    {
        public AttackingLikelikeState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
        }
    }
}
