namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class BlockEnemyIdleState : BlockEnemyEssentials, IEnemyState
    {
        public BlockEnemyIdleState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.CurrentState = this;
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
        }
    }
}
