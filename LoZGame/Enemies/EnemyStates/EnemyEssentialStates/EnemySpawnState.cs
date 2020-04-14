namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class EnemySpawnState : EnemyStateEssentials, IEnemyState
    {
        private int spawnTimer = 0;
        private int spawnTimerMax;

        public EnemySpawnState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.CurrentState = this;
            this.Sprite = EnemySpriteFactory.Instance.CreateEnemySpawn();
            //this.Enemy.Physics.MovementVelocity = Vector2.Zero;
            this.spawnTimerMax = GameData.Instance.EnemySpeedData.SpawnTimerMax;
        }

        public override void Update()
        {
            this.spawnTimer++;
            this.Sprite.Update();
            if (spawnTimer >= spawnTimerMax)
            {
                this.Enemy.UpdateState();
            }

        }

        public void Attack()
        {
            if (this.Enemy is Keese)
            {
                (this.Enemy as Keese).CurrentState.Attack();
            }
        }

        public void Die()
        {
            if (this.Enemy is Keese)
            {
                (this.Enemy as Keese).CurrentState.Die();
            }
        }

        public void MoveDown()
        {
            if (this.Enemy is Keese)
            {
                (this.Enemy as Keese).CurrentState.MoveDown();
            }
        }

        public void MoveDownLeft()
        {
            if (this.Enemy is Keese)
            {
                (this.Enemy as Keese).CurrentState.MoveDownLeft();
            }
        }

        public void MoveDownRight()
        {
            if (this.Enemy is Keese)
            {
                (this.Enemy as Keese).CurrentState.MoveDownRight();
            }
        }

        public void MoveLeft()
        {
            if (this.Enemy is Keese)
            {
                (this.Enemy as Keese).CurrentState.MoveLeft();
            }
        }

        public void MoveRight()
        {
            if (this.Enemy is Keese)
            {
                (this.Enemy as Keese).CurrentState.MoveRight();
            }
        }

        public void MoveUp()
        {
            if (this.Enemy is Keese)
            {
                (this.Enemy as Keese).CurrentState.MoveUp();
            }
        }

        public void MoveUpLeft()
        {
            if (this.Enemy is Keese)
            {
                (this.Enemy as Keese).CurrentState.MoveLeft();
            }
        }

        public void MoveUpRight()
        {
            if (this.Enemy is Keese)
            {
                (this.Enemy as Keese).CurrentState.MoveUpRight();
            }
        }

        public void Stop()
        {
        }

        public void Stun(int stunTime)
        {
        }
    }
}
