namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingGoriyaState : IGoriyaState
    {
        private readonly Goriya goriya;
        private readonly IEnemySprite sprite;
        private readonly IProjectile boomerangSprite;

        public AttackingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            switch (goriya.Direction)
            {
                case "Left":
                    this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingGoriyaSprite();
                    break;

                case "Right":
                    this.sprite = EnemySpriteFactory.Instance.CreateRightMovingGoriyaSprite();
                    break;

                case "Up":
                    this.sprite = EnemySpriteFactory.Instance.CreateUpMovingGoriyaSprite();
                    break;

                case "Down":
                    this.sprite = EnemySpriteFactory.Instance.CreateDownMovingGoriyaSprite();
                    break;

                default:
                    break;
            }
        }

        public void MoveLeft()
        {
            this.goriya.CurrentState = new LeftMovingGoriyaState(this.goriya);
        }

        public void MoveRight()
        {
            this.goriya.CurrentState = new RightMovingGoriyaState(this.goriya);
        }

        public void MoveUp()
        {
            this.goriya.CurrentState = new UpMovingGoriyaState(this.goriya);
        }

        public void MoveDown()
        {
            this.goriya.CurrentState = new DownMovingGoriyaState(this.goriya);
        }

        public void Attack()
        {
            // Blank b/c already attacking
        }

        public void TakeDamage()
        {
            this.goriya.Health--;
            if (this.goriya.Health == 0)
            {
                this.goriya.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.goriya.CurrentState = new DeadGoriyaState(this.goriya);
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.goriya.CurrentLocation, Color.White);
        }
    }
}