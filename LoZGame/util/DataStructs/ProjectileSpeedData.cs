namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct ProjectileSpeedData
    {
        private const int LinkArrowSpd = 5;
        private const int LinkSilverArrowSpd = 10;
        private const int LinkBoomerangSpd = 5;
        private const int LinkMagicBoomerangSpd = 7;
        private const int SwordBeamSpd = 5;
        private const float SwordBeamExplosionSpd = 2.5f;
        private const int WoodSwordSpd = 5;
      //  private const int WhiteSwordSpd = 5;
      //  private const int MagicSwordSpd = 5;
        private const int CandleSpd = 5;
        private const int FireballSpd = 4;
        private const int EnemyBoomerangSpd = 5;
        private const int EnemyArrowSpd = 5;

        public int LinkArrowSpeed => LinkArrowSpd;

        public int LinkSilverArrowSpeed => LinkSilverArrowSpd;

        public int LinkBoomerangSpeed => LinkBoomerangSpd;

        public int LinkMagicBoomerangSpeed => LinkMagicBoomerangSpd;

        public int SwordBeamSpeed => SwordBeamSpd;

        public float SwordBeamExplosionSpeed => SwordBeamExplosionSpd;

        public int WoodSwordSpeed => WoodSwordSpd;

    //    public int WhiteSwordSpeed => WhiteSwordSpd;

    //    public int MagicSwordSpeed => MagicSwordSpd;

        public int CandleSpeed => CandleSpd;

        public int FireballSpeed => FireballSpd;

        public int EnemyBoomerangSpeed => EnemyBoomerangSpd;

        public int EnemyMagicBoomerangSpeed => EnemyMagicBoomerangSpeed;
    }
}