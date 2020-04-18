using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class DeadLikelikeState : LikelikeEssentials, IEnemyState
    {
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadLikelikeState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.IsDead = true;
            this.Sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.Bounds = new Rectangle(this.Enemy.Physics.Bounds.Location, Point.Zero);
            deathTimerMax = GameData.Instance.EnemyMiscConstants.DeathTimerMaximum;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
        }

        public override void Update()
        {
            this.deathTimer++;
            this.Sprite.Update();
            if (deathTimer >= deathTimerMax)
            {
                this.Enemy.Expired = true;
                LoZGame.Instance.Drops.AttemptDrop(this.Enemy.Physics.Location);
            }
        }
    }
}
