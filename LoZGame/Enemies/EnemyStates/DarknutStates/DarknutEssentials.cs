namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DarknutEssentials : EnemyStateEssentials, IEnemyState
    {
        public void MoveLeft()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.West;
            this.Enemy.CurrentState = new LeftMovingDarknutState(this.Enemy);
        }

        public void MoveRight()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.East;
            this.Enemy.CurrentState = new RightMovingDarknutState(this.Enemy);
        }

        public void MoveUp()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.CurrentState = new UpMovingDarknutState(this.Enemy);
        }

        public void MoveDown()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
            this.Enemy.CurrentState = new DownMovingDarknutState(this.Enemy);
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

        public void Stun(int stunTime)
        {
        }

        public void Die()
        {
            this.Enemy.CurrentState = new DeadDarknutState(this.Enemy);
        }

        public override void Spawn()
        {
            this.Enemy.CurrentState = new SpawnDarknutState(this.Enemy);
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.DarknutFavorCardinalValue);
            }
            base.Update();
        }
    }
}