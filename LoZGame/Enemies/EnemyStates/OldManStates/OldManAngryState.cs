namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class OldManAngryState : OldManEssentials, IEnemyState
    {
        public OldManAngryState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.CurrentState = this;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
        }
    }
}
