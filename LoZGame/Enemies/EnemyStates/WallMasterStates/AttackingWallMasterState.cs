namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingWallMasterState : WallMasterEssentials, IEnemyState
    {

        public AttackingWallMasterState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = EnemySpriteFactory.Instance.CreateAttackingWallMasterSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(GameData.Instance.EnemySpeedConstants.WallMasterAttackSpeed, 0);
        }

        public override void Update()
        {
            this.Sprite.Update();
        }
    }
}