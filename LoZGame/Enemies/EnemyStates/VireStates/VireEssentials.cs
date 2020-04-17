namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class VireEssentials : EnemyStateEssentials, IEnemyState
    {
        public void MoveLeft()
        {
            // jump left
        }

        public void MoveRight()
        {
            // jump right
        }

        public void MoveUp()
        {
            this.Enemy.CurrentState = new UpMovingVireState(this.Enemy);
        }

        public void MoveDown()
        {
            this.Enemy.CurrentState = new DownMovingVireState(this.Enemy);
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
            this.Enemy.CurrentState = new DeadVireState(this.Enemy);
            this.SpawnVireKeese(this.Enemy.Physics.Location);
        }

        public virtual void Stun(int stunTime)
        {
        }

        public override void Spawn()
        {
            this.Enemy.CurrentState = new SpawnVireState(this.Enemy);
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(3);
            }
            base.Update();
        }

        public void SpawnVireKeese(Vector2 location)
        {
            LoZGame.Instance.GameObjects.Enemies.EnemyList.Add(new VireKeese(location));
        }
    }
}