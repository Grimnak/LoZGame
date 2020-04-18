using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class UpMovingLikelikeState : LikelikeEssentials, IEnemyState
    {
        public UpMovingLikelikeState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(0, -1 * this.Enemy.MoveSpeed);
        }
    }
}
