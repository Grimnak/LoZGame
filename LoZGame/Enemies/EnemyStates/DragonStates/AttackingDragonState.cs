namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingEnemyState : IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private readonly int directionChange;
        private RandomStateGenerator randomStateGenerator;

        public AttackingEnemyState(IEnemy enemy)
        {
            this.dragon = dragon;
            this.sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
            this.dragon.CurrentState = this;
            this.directionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            randomStateGenerator = new RandomStateGenerator(this.dragon, 0, 4);
            this.dragon.ShootFireballs();
        }

        public void MoveUp()
        {
            this.enemy.CurrentState = new UpMovingEnemyState(this)
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
            this.dragon.CurrentState = new LeftMovingDragonState(this.dragon);
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