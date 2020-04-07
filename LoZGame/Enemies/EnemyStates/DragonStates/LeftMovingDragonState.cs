namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingDragonState : IEnemyState
    {
        private readonly Dragon dragon;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private int directionChange;
        private RandomStateGenerator randomStateGenerator;

        public LeftMovingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.directionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
            this.dragon.CurrentState = this;
            randomStateGenerator = new RandomStateGenerator(this.dragon, 0, 4);
            this.dragon.Physics.MovementVelocity = new Vector2(-1 * this.dragon.MoveSpeed, 0);
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
        }

        public void Draw()
        {
            this.sprite.Draw(this.dragon.Physics.Location, this.dragon.CurrentTint, this.dragon.Physics.Depth);
        }
    }
}