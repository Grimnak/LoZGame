namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadZolState : IEnemyState
    {
        private readonly Zol zol;
        private readonly ISprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadZolState(Zol zol)
        {
            this.zol = zol;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.zol.CurrentState = this;
            this.zol.Physics.Bounds = new Rectangle(zol.Physics.Bounds.Location, Point.Zero);
            LoZGame.Instance.Drops.AttemptDrop(this.zol.Physics.Location);
            this.zol.Physics.MovementVelocity = Vector2.Zero;
            deathTimerMax = zol.EnemySpeedData.DeathTimerMax;
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
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
        }

        public void Stun(int stunTime)
        {
        }

        public void Update()
        {
            this.deathTimer++;
            this.sprite.Update();
            if (deathTimer >= deathTimerMax)
            {
                this.zol.Expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.zol.Physics.Location, LoZGame.Instance.DungeonTint, this.zol.Physics.Depth);
        }
    }
}