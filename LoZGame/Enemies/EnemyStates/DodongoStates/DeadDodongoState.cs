namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadDodongoState : IEnemyState
    {
        private readonly IEnemy dodongo;
        private readonly ISprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadDodongoState(IEnemy dodongo)
        {
            this.dodongo = dodongo;
            this.dodongo.CurrentState = this;
            this.dodongo.Physics.Bounds = new Rectangle(dodongo.Physics.Bounds.Location, Point.Zero);
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            LoZGame.Instance.Drops.AttemptDrop(this.dodongo.Physics.Location);
            deathTimerMax = GameData.Instance.EnemySpeedData.DeathTimerMax;
            this.dodongo.Physics.MovementVelocity = Vector2.Zero;
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
                this.dodongo.Expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.dodongo.Physics.Location, this.dodongo.CurrentTint, this.dodongo.Physics.Depth);
        }
    }
}
