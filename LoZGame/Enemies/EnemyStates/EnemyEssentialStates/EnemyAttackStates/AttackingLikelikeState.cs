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
            Enemy = enemy;
            Sprite = enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            Enemy.Physics.MovementVelocity = Vector2.Zero;
        }
    }
}
