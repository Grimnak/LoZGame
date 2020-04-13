namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingDodongoState : DodongoEssentals, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly ISprite sprite;
        private RandomStateGenerator randomStateGenerator;

        public AttackingDodongoState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.MoveSpeed = GameData.Instance.EnemySpeedConstants.DodongoAttackSpeed;
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange * 2;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            GetMoveSpeed();
        }

        private void GetMoveSpeed()
        {
            switch (this.Enemy.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    this.Enemy.Physics.MovementVelocity = new Vector2(0, -this.Enemy.MoveSpeed);
                    break;
                case Physics.Direction.South:
                    this.Enemy.Physics.MovementVelocity = new Vector2(0, this.Enemy.MoveSpeed);
                    break;
                case Physics.Direction.East:
                    this.Enemy.Physics.MovementVelocity = new Vector2(this.Enemy.MoveSpeed, 0);
                    break;
                case Physics.Direction.West:
                    this.Enemy.Physics.MovementVelocity = new Vector2(-this.Enemy.MoveSpeed, 0);
                    break;
                default:
                    this.Enemy.UpdateState();
                    break;
            }
        }
    }
}