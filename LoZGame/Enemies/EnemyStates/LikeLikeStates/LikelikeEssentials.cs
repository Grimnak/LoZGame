namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LikelikeEssentials : EnemyStateEssentials, IEnemyState
    {
        public void MoveLeft()
        {
            this.Enemy.CurrentState = new LeftMovingLikelikeState(this.Enemy);
        }

        public void MoveRight()
        {
            this.Enemy.CurrentState = new RightMovingLikelikeState(this.Enemy);
        }

        public void MoveUp()
        {
            this.Enemy.CurrentState = new UpMovingLikelikeState(this.Enemy);
        }

        public void MoveDown()
        {
            this.Enemy.CurrentState = new DownMovingLikeLikeState(this.Enemy);
        }

        public void MoveUpLeft()
        {
        }

        public void MoveUpRight()
        {
        }

        public void MoveDownLeft()
        {
        }

        public void MoveDownRight()
        {
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.Enemy.CurrentState = new DeadLikelikeState(this.Enemy);
        }

        public virtual void Stun(int stunTime)
        {
        }

        public override void Spawn()
        {
            this.Enemy.CurrentState = new SpawnLikelikeState(this.Enemy);
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GoriyaFavorCardinalValue);
            }
            base.Update();
        }
    }
}