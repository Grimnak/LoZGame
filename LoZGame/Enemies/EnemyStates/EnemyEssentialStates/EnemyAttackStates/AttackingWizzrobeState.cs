namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingWizzrobeState : EnemyStateEssentials, IEnemyState
    {
        public AttackingWizzrobeState(IEnemy enemy)
        {
            Console.WriteLine("Wizzrobe entered Attack state facing " + enemy.Physics.CurrentDirection);
            Enemy = enemy;
            DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange * 2;
            FacePlayer();
            Sprite = Enemy.CreateCorrectSprite();
            LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new SonicBeamProjectile(Enemy.Physics));
            Console.WriteLine("Wizzrobe shot projectile that is facing " + enemy.Physics.CurrentDirection);
        }
    }
}