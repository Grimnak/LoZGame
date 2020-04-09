namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FollowFireSnakeState : IEnemyState
    {
        private static int TimeBetweenFollows = LoZGame.Instance.UpdateSpeed;
        private readonly IEnemy fireSnake;
        private readonly IEnemy parent;
        private readonly ISprite sprite;
        private int timeSinceLastFollow;

        public FollowFireSnakeState(IEnemy fireSnake, IEnemy parent)
        {
            this.fireSnake = fireSnake;
            this.parent = parent;
            this.sprite = ProjectileSpriteFactory.Instance.Fireball();
            this.timeSinceLastFollow = 0;
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
            this.fireSnake.CurrentState = new DeadFireSnakeState(this.fireSnake);
        }

        public void Stun(int stunTime)
        {
            this.fireSnake.CurrentState = new StunnedFireSnakeState(this.fireSnake, this, stunTime);
        }

        public void Update()
        {
            timeSinceLastFollow++;
            if (timeSinceLastFollow <= TimeBetweenFollows)
            {
                this.fireSnake.Physics.MovementVelocity = this.parent.Physics.MovementVelocity;
                timeSinceLastFollow = 0;
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.fireSnake.Physics.Location, this.fireSnake.CurrentTint, this.fireSnake.Physics.Depth);
        }
    }
}