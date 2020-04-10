namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public ISprite Sprite { get; set; }

        public int DirectionChange { get; set; }

        public int Lifetime { get; set; }

        public IEnemy Enemy { get; set; }

        public virtual void MoveLeft()
        {
            this.Enemy.CurrentState = new LeftMovingEnemyState(this.Enemy);
        }

        public virtual void MoveRight()
        {
            this.Enemy.CurrentState = new RightMovingEnemyState(this.Enemy);
        }

        public virtual void MoveUp()
        {
            this.Enemy.CurrentState = new UpMovingEnemyState(this.Enemy);
        }

        public virtual void MoveDown()
        {
            this.Enemy.CurrentState = new DownMovingEnemyState(this.Enemy);
        }

        public virtual void MoveUpLeft()
        {
            this.Enemy.CurrentState = new UpLeftMovingEnemyState(this.Enemy);
        }

        public virtual void MoveUpRight()
        {
            this.Enemy.CurrentState = new UpRightMovingEnemyState(this.Enemy);
        }

        public virtual void Attack()
        {
            this.Enemy.CurrentState = new AttackingEnemyState(this.Enemy);
        }

        public virtual void MoveDownLeft()
        {
            this.Enemy.CurrentState = new DownLeftMovingEnemyState(this.Enemy);
        }

        public virtual void MoveDownRight()
        {
            this.Enemy.CurrentState = new DownRightMovingEnemyState(this.Enemy);
        }

        public virtual void Die()
        {
            this.Enemy.CurrentState = new DeadEnemyState(this.Enemy);
        }

        public virtual void Stop()
        {
            this.Enemy.CurrentState = new IdleEnemyState(this.Enemy);
        }

        public virtual void Stun(int stunTime)
        {
            this.Die();
        }

        public virtual void Update()
        {
            this.Lifetime++;
            if (this.Lifetime > this.DirectionChange)
            {
                this.Enemy.RandomStateGenerator.Update();
                this.Lifetime = 0;
            }
            this.Sprite.Update();
        }

        public virtual void Draw()
        {
            this.Sprite.Draw(this.dragon.Physics.Location, this.dragon.CurrentTint, this.dragon.Physics.Depth);
        }

    }
}
