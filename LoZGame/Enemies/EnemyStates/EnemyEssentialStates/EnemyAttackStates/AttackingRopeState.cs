namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    public class AttackingRopeState : RopeEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly ISprite sprite;
        private RandomStateGenerator randomStateGenerator;
        private List<IPlayer> players;

        public AttackingRopeState(IEnemy enemy)
        {
            this.Enemy = enemy;
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
                    this.Enemy.Physics.MovementVelocity = new Vector2(0, -GameData.Instance.EnemySpeedConstants.RopeAttackSpeed);
                    break;
                case Physics.Direction.South:
                    this.Enemy.Physics.MovementVelocity = new Vector2(0, GameData.Instance.EnemySpeedConstants.RopeAttackSpeed);
                    break;
                case Physics.Direction.East:
                    this.Enemy.Physics.MovementVelocity = new Vector2(GameData.Instance.EnemySpeedConstants.RopeAttackSpeed, 0);
                    break;
                case Physics.Direction.West:
                    this.Enemy.Physics.MovementVelocity = new Vector2(-GameData.Instance.EnemySpeedConstants.RopeAttackSpeed, 0);
                    break;
                default:
                    this.Enemy.UpdateState();
                    break;
            }
        }
    }
}