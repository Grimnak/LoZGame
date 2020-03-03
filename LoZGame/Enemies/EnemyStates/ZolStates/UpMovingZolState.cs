namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingZolState : IEnemyState
    {
        private readonly Zol zol;
        private readonly ISprite sprite;

        public UpMovingZolState(Zol zol)
        {
            this.zol = zol;
            zol.Physics.Velocity = new Vector2(0, -1);
            this.sprite = EnemySpriteFactory.Instance.CreateZolSprite();
            this.zol.CurrentState = this;
        }

        public void MoveLeft()
        {
            this.zol.CurrentState = new LeftMovingZolState(this.zol);
        }

        public void MoveRight()
        {
            this.zol.CurrentState = new RightMovingZolState(this.zol);
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
            this.zol.CurrentState = new DownMovingZolState(this.zol);
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

        public void TakeDamage(int damageAmount)
        {
            this.zol.Health.DamageHealth(damageAmount);
        }

        public void Die()
        {
            this.zol.CurrentState = new DeadZolState(this.zol);
        }

        public void Update()
        {
            if (this.zol.ShouldMove)
            {
                this.zol.Physics.Move();
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.zol.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}