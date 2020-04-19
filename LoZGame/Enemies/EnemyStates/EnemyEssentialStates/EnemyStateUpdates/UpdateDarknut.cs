namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public void UpdateDarknut()
        {;
            DefaultUpdate();
            if (LoZGame.Instance.Difficulty <= 2)
            {
                StandardDarknut();
            }
            else
            {
                HardDarknut();
            }
        }

        private void StandardDarknut()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.DarknutFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
        }

        private void HardDarknut()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.DarknutFavorCardinalValue + (2 * (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.DarknutFavorCardinalValue + (3 * (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
                FacePlayer();
                AttemptSwordBeam();
            }
        }

        private void AttemptSwordBeam()
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