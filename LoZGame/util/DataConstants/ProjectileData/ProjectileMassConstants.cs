namespace LoZClone
{
    public struct ProjectileMassConstants
    {
        private const int ArrowMss = 4;
        private const int BoomerangMss = 8;
        private const int FlameMss = 16;
        private const int FireballMss = 12;
        private const int ExplosionMss = 24;
        private const int SwordBeamMss = 8;
        private const int WoodSwordMss = 64;
        private const int MagicSwordMss = 96;
        private const int WhiteSwordMss = 80;
        private const int SilverArrowMss = 4;

        public int ArrowMass => ArrowMss;

        public int SilverArrowMass => SilverArrowMss;

        public int FlameMass => FlameMss;

        public int FireballMass => FireballMss;

        public int ExplosionMass => ExplosionMss;

        public int SwordBeamMass => SwordBeamMss;

        public int WoodSwordMass => WoodSwordMss;

        public int WhiteSwordMass => WhiteSwordMss;

        public int MagicSwordMass => MagicSwordMss;

        public int BoomerangMass => BoomerangMss;
    }
}