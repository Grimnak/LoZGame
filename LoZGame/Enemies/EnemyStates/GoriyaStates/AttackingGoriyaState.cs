namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingGoriyaState : IEnemyState
    {
        private readonly Goriya goriya;
        private readonly ISprite sprite;
        private readonly IProjectile boomerangSprite;
        private int lifeTime = 0;
        private readonly int directionChange = 120;
        private RandomStateGenerator randomStateGenerator;
        private bool boomerangThrown;

        public AttackingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            this.boomerangThrown = false;
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
            this.goriya.Physics.MovementVelocity = Vector2.Zero;
            randomStateGenerator = new RandomStateGenerator(this.goriya, 1, 6);
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
            this.boomerangThrown = false;
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.goriya.CurrentState = new DeadGoriyaState(this.goriya);
        }

        public void Stun(int stunTime)
        {
            this.goriya.CurrentState = new StunnedGoriyaState(this.goriya, this, stunTime);
        }

        public void Update()
        {
            if (!boomerangThrown)
            {
                boomerangThrown = true;
                this.goriya.EntityManager.EnemyProjectileManager.Add(LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Boomerang, this.goriya, this.goriya.Direction);
            }
            this.lifeTime++;
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                this.lifeTime = 0;
                this.boomerangThrown = false;
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.goriya.Physics.Location, this.goriya.CurrentTint, this.goriya.Physics.Depth);
        }
    }
}