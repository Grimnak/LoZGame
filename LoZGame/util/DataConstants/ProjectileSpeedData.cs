namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct ProjectileSpeedData
    {
        private const float LinkArrowSpd = 7;
        private const float LinkSilverArrowSpd = 12;
        private const float LinkBoomerangSpd = 6;
        private const float LinkMagicBoomerangSpd = 8;
        private const float SwordBeamSpd = 6.5f;
        private const float SwordBeamExplosionSpd = 3.25f;
        private const int WoodSwordSpd = 5;
      //  private const int WhiteSwordSpd = 5;
      //  private const int MagicSwordSpd = 5;
        private const float CandleSpd = 7;
        private const float FireballSpd = 5;
        private const float EnemyBoomerangSpd = 7;
        private const float EnemyArrowSpd = 7;

        public float LinkArrowSpeed => LinkArrowSpd;

        public float LinkSilverArrowSpeed => LinkSilverArrowSpd;

        public float LinkBoomerangSpeed => LinkBoomerangSpd;

        public float LinkMagicBoomerangSpeed => LinkMagicBoomerangSpd;

        public float SwordBeamSpeed => SwordBeamSpd;

        public float SwordBeamExplosionSpeed => SwordBeamExplosionSpd;

        public int WoodSwordSpeed => WoodSwordSpd;

    //    public int WhiteSwordSpeed => WhiteSwordSpd;

    //    public int MagicSwordSpeed => MagicSwordSpd;

        public float CandleSpeed => CandleSpd;

        public float FireballSpeed => FireballSpd;

        public float EnemyBoomerangSpeed => EnemyBoomerangSpd;

        public int EnemyMagicBoomerangSpeed => EnemyMagicBoomerangSpeed;
    }
}