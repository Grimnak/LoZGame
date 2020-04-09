namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingDodongoState : IEnemyState
    {
        private readonly IEnemy dodongo;
        private ISprite sprite;
        private readonly IEnemyState oldState;
        private RandomStateGenerator randomStateGenerator;
        private Vector2 oldVelocity;
        private int attackDuration;

        public AttackingDodongoState(IEnemy dodongo, IEnemyState oldState)
        {
            this.dodongo = dodongo;
            this.oldState = oldState;
            this.oldVelocity = this.dodongo.Physics.MovementVelocity;
            this.CreateCorrectSprite();
            this.sprite.SetFrame(GameData.Instance.EnemySpeedData.DodongoMaxFrame);
            this.sprite.CurrentFrame = 0;
            attackDuration = GameData.Instance.EnemySpeedData.DirectionChange;
            this.dodongo.CurrentState = this;
            this.dodongo.Physics.MovementVelocity = new Vector2(0, this.dodongo.MoveSpeed);
            randomStateGenerator = new RandomStateGenerator(this.dodongo, 2, 6);
            this.dodongo.Physics.MovementVelocity = Vector2.Zero;
        }

        private void CreateCorrectSprite()
        {
            switch (this.dodongo.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    this.sprite = EnemySpriteFactory.Instance.CreateUpMovingDodongoSprite();
                    break;
                case Physics.Direction.South:
                    this.sprite = EnemySpriteFactory.Instance.CreateDownMovingDodongoSprite();
                    break;
                case Physics.Direction.East:
                    this.sprite = EnemySpriteFactory.Instance.CreateRightMovingDodongoSprite();
                    break;
                case Physics.Direction.West:
                    this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingDodongoSprite();
                    break;
                default:
                    break;
            }
        }

        public void MoveLeft()
        {
            this.dodongo.CurrentState = new LeftMovingDodongoState(this.dodongo);
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
            if (sprite.CurrentFrame < GameData.Instance.EnemySpeedData.DodongoMaxFrame - 1)
            {
                sprite.Update();
            }
           else
            {
                attackDuration--;
                if (attackDuration <= 0)
                {
                    this.dodongo.TakeDamage(GameData.Instance.ProjectileDamageData.BombDodongoDamage);
                    randomStateGenerator.Update();
                    this.dodongo.Physics.MovementVelocity = oldVelocity;
                }
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.dodongo.Physics.Location, this.dodongo.CurrentTint, this.dodongo.Physics.Depth);
        }
    }
}