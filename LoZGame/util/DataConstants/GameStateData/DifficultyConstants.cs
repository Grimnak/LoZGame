namespace LoZClone
{
    public struct DifficultyConstants
    {
        private const float smallMoveMod = 0.5f;
        private const float largeMoveMod = 1.0f;
        private const float accelMod = 0.5f;
        private const int damageMod = 2;
        private const int smallWeightMod = 1;
        private const int largeWeightMod = 3;
        private const int smallPrefMod = 2;
        private const int largePrefMod = 4;
        private const int smallHealthMod = 2;
        private const int largeHealthMod = 4;
        private const int healthChance = 5;

        public float SmallMoveMod => smallMoveMod;

        public float LargeMoveMod => largeMoveMod;

        public float accelMoveMod => accelMod;

        public int DamageMod => damageMod;

        public int SmallWeightMod => smallWeightMod;

        public int LargeWeightMod => largeWeightMod;

        public int SmallPreferenceMod => smallPrefMod;

        public int LargePreferenceMod => largePrefMod;

        public int SmallHealthMod => smallHealthMod;

        public int LargeHealthMod => largeHealthMod;

        public int HealthChance => healthChance;
    }
}
