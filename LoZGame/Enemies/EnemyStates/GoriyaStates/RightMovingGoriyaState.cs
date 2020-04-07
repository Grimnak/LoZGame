namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingGoriyaState : IEnemyState
    {
        private readonly Goriya goriya;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private int directionChange;
        private RandomStateGenerator randomStateGenerator;

        public RightMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            this.directionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.sprite = EnemySpriteFactory.Instance.CreateRightMovingGoriyaSprite();
            this.goriya.CurrentState = this;
            this.goriya.Physics.CurrentDirection = Physics.Direction.East;
            randomStateGenerator = new RandomStateGenerator(this.goriya, 1, 6);
            this.goriya.Physics.MovementVelocity = new Vector2(this.goriya.MoveSpeed, 0);
        }

        public void MoveLeft()
        {
            this.goriya.CurrentState = new LeftMovingGoriyaState(this.goriya);
        }

        public void MoveRight()
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

        public void Stop()
        {
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
            this.goriya.CurrentState = new AttackingGoriyaState(this.goriya);
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
            if (this.goriya.Cooldown > 0)
            {
                this.goriya.Cooldown--;
            }
            this.lifeTime++;
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                this.lifeTime = 0;
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.goriya.Physics.Location, this.goriya.CurrentTint, this.goriya.Physics.Depth);
        }
    }
}