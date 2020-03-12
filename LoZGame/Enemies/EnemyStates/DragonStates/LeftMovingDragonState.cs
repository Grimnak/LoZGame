namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingDragonState : IEnemyState
    {
        private readonly Dragon dragon;
        private readonly ISprite sprite;

        public LeftMovingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
            this.dragon.CurrentState = this;
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            this.dragon.CurrentState = new RightMovingDragonState(this.dragon);
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

        public void Stop()
        {
            this.dragon.CurrentState = new IdleDragonState(this.dragon);
        }

        public void Attack()
        {
            this.dragon.CurrentState = new AttackingDragonState(this.dragon);
        }

        public void Die()
        {
            this.dragon.CurrentState = new DeadDragonState(this.dragon);
        }

        public void Update()
        {
            this.dragon.Physics.Location = new Vector2(this.dragon.Physics.Location.X - this.dragon.MoveSpeed, this.dragon.Physics.Location.Y);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.dragon.Physics.Location, this.dragon.CurrentTint);
        }
    }
}