namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class BlockEnemyIdleState : BlockEnemyEssentials, IEnemyState
    {
        public BlockEnemyIdleState(IEnemy enemy)
        {
            Enemy = enemy;
            Enemy.CurrentState = this;
            DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
        }
    }
}
