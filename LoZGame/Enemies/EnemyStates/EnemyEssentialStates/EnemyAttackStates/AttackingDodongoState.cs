namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingDodongoState : EnemyStateEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly ISprite sprite;
        private RandomStateGenerator randomStateGenerator;
        private float attackSpeed;

        public AttackingDodongoState(IEnemy enemy)
        {
            Enemy = enemy;
            DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange * 2;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            attackSpeed = GameData.Instance.EnemySpeedConstants.DodongoAttackSpeed;
            attackSpeed += LoZGame.Instance.Difficulty > 0 ? LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargeMoveMod : 0;
            GetMoveSpeed();
        }

        private void GetMoveSpeed()
        {
            switch (Enemy.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    Enemy.Physics.MovementVelocity = new Vector2(0, -attackSpeed);
                    break;
                case Physics.Direction.South:
                    Enemy.Physics.MovementVelocity = new Vector2(0, attackSpeed);
                    break;
                case Physics.Direction.East:
                    Enemy.Physics.MovementVelocity = new Vector2(attackSpeed, 0);
                    break;
                case Physics.Direction.West:
                    Enemy.Physics.MovementVelocity = new Vector2(-attackSpeed, 0);
                    break;
                default:
                    Enemy.UpdateState();
                    break;
            }
        }
    }
}