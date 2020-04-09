namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingDodongoState : IEnemyState
    {
        private readonly IEnemy dodongo;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private int directionChange;
        private RandomStateGenerator randomStateGenerator;

        public LeftMovingDodongoState(IEnemy dodongo)
        {
            this.dodongo = dodongo;
            this.dodongo.Physics.CurrentDirection = Physics.Direction.West;
            this.directionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingDodongoSprite();
            this.dodongo.CurrentState = this;
            randomStateGenerator = new RandomStateGenerator(this.dodongo, 2, 6);
            this.dodongo.Physics.MovementVelocity = new Vector2(-1 * this.dodongo.MoveSpeed, 0);
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            this.dodongo.CurrentState = new RightMovingDodongoState(this.dodongo);
        }

        public void MoveUp()
        {
            this.dodongo.CurrentState = new UpMovingDodongoState(this.dodongo);
        }

        public void MoveDown()
        {
            this.dodongo.CurrentState = new DownMovingDodongoState(this.dodongo);
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
            this.dodongo.CurrentState = new AttackingDodongoState(this.dodongo, this);
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.dodongo.CurrentState = new DeadDodongoState(this.dodongo);
        }

        public void Stun(int stunTime)
        {
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                this.lifeTime = 0;
            }
            this.sprite.Update();
            if (this.sprite.CurrentFrame >= 2)
            {
                this.sprite.SetFrame(0);
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.dodongo.Physics.Location, this.dodongo.CurrentTint, this.dodongo.Physics.Depth);
        }
    }
}