namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public void UpdateGleeock()
        {
            DefaultUpdate();
            if (this.Lifetime == this.DirectionChange)
            {
                AttemptFireBall();
            }
        }

        private void AttemptFireBall()
        {
            int attempt = LoZGame.Instance.Random.Next(0, 100);
            if (attempt <= GameData.Instance.EnemyMiscConstants.ProjectileSuccess)
            {
                IProjectile swordBeam = new SwordBeamProjectile(this.Enemy.Physics);
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(swordBeam);
            }
        }
    }
}