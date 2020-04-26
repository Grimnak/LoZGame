namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingWizzrobeState : EnemyStateEssentials, IEnemyState
    {
        public AttackingWizzrobeState(IEnemy enemy)
        {
            Enemy = enemy;
            DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange * 2;
            FacePlayer();
            Sprite = Enemy.CreateCorrectSprite();
            LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new SonicBeamProjectile(Enemy.Physics));
        }
    }
}