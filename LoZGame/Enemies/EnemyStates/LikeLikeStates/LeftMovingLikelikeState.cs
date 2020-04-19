using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class LeftMovingLikelikeState : LikelikeEssentials, IEnemyState
    {
        public LeftMovingLikelikeState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(-1 * this.Enemy.MoveSpeed, 0);
        }
    }
}
