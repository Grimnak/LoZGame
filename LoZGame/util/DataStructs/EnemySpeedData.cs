namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct EnemySpeedData
    {
        private const int stalfosSpd = 1;
        private const float minKeeseSpd = 1.5f;
        private const float maxKeeseSpd = 5.0f;
        private const int ropeSpd = 1;
        private const float gelSpd = 2.5f;
        private const int zolSpd = 4;
        private const int spikeCrossSpd = 3;
        private const int wallMasterSpd = 1;
        private const int wallMasterAttackSpd = -1;
        private const int dragonSpd = 1;
        private const int dodongoSpd = 1;
        private const int goriyaSpd = 1;
        private const int oldManSpd = 1;
        private const int merchantSpd = 1;

        private const int directionChange = 40;
        private const int deathTimerMax = 30;

        public int StalfosSpeed => stalfosSpd;

        public int RopeSpeed => ropeSpd;

        public float MinKeeseSpeed => minKeeseSpd;

        public float MaxKeeseSpeed => maxKeeseSpd;


        public float GelSpeed => gelSpd;

        public int ZolSpeed => zolSpd;

        public int SpikeCrossSpeed => spikeCrossSpd;

        public int WallMasterSpeed => wallMasterSpd;

        public int WallMasterAttackSpeed => wallMasterAttackSpd;

        public int DragonSpeed => dragonSpd;

        public int DodongoSpeed => dodongoSpd;

        public int GoriyaSpeed => goriyaSpd;

        public int OldManSpeed => oldManSpd;

        public int MerchantSpeed => merchantSpd;

        public int DirectionChange => directionChange;

        public int DeathTimerMax => deathTimerMax;

    }
}