namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct ProjectileMassData
    {
        private const int arrowMass = 4;
        private const int boomerangMass = 8;
        private const int flameMass = 16;
        private const int fireballMass = 12;
        private const int explosionMass = 24;
        private const int swordBeamMass = 8;
        private const int woodSwordMass = 16;
        private const int magicSwordMass = 32;
        private const int whiteSwordMass = 24;
        private const int silverArrowMass = 8;

        public int ArrowMass => arrowMass;

        public int SilverArrowMass => silverArrowMass;

        public int FlameMass => flameMass;

        public int FireballMass => fireballMass;

        public int ExplosionMass => explosionMass;

        public int SwordBeamMass => swordBeamMass;

        public int WoodSwordMass => woodSwordMass;

        public int WhiteSwordMass => whiteSwordMass;

        public int MagicSwordMass => magicSwordMass;

        public int BoomerangMass => boomerangMass;

    }
}