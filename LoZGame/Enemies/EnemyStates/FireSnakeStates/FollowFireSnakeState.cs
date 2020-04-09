namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FollowFireSnakeState : IEnemyState
    {
        private readonly IEnemy fireSnake;
        private readonly ISprite sprite;

        public FollowFireSnakeState(IEnemy fireSnake)
        {
            this.fireSnake = fireSnake;
            this.sprite = ProjectileSpriteFactory.Instance.Fireball();
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
            this.fireSnake.CurrentState = new StunnedFireSnakeState(this.fireSnake, this, stunTime);
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.fireSnake.Physics.Location, this.fireSnake.CurrentTint, this.fireSnake.Physics.Depth);
        }
    }
}