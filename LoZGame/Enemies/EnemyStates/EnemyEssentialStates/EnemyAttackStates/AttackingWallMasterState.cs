namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingWallMasterState : EnemyStateEssentials, IEnemyState
    {
        public AttackingWallMasterState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = EnemySpriteFactory.Instance.CreateAttackingWallMasterSprite();
            Enemy.CurrentState = this;
            Enemy.Physics.MovementVelocity = new Vector2(GameData.Instance.EnemySpeedConstants.WallMasterAttackSpeed, 0);
        }

        public override void Update()
        {
            Sprite.Update();
        }
    }
}