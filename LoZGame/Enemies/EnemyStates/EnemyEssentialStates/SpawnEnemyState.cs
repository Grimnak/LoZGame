namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpawnEnemyState : EnemyStateEssentials, IEnemyState
    {
        public SpawnEnemyState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.CurrentState = this;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.Physics.MovementVelocity = new Vector2(0, -1 * this.Enemy.MoveSpeed);
        }

        public void Attack()
        {
            this.Enemy.CurrentState = 
        }

        public void Die()
        {
            throw new System.NotImplementedException();
        }

        public void MoveDown()
        {
            throw new System.NotImplementedException();
        }

        public void MoveDownLeft()
        {
            throw new System.NotImplementedException();
        }

        public void MoveDownRight()
        {
            throw new System.NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new System.NotImplementedException();
        }

        public void MoveRight()
        {
            throw new System.NotImplementedException();
        }

        public void MoveUp()
        {
            throw new System.NotImplementedException();
        }

        public void MoveUpLeft()
        {
            throw new System.NotImplementedException();
        }

        public void MoveUpRight()
        {
            throw new System.NotImplementedException();
        }

        public void Spawn()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        public void Stun(int stunTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
