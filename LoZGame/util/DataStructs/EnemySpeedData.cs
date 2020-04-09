namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct EnemySpeedData
    {
        private const float stalfosSpd = 2;
        private const float minKeeseSpd = 1.5f;
        private const float maxKeeseSpd = 5.0f;
        private const float keeseAccel = .025f;
        private const float keeseAccelMax = 5.0f;
        private const float ropeSpd = 2.5f;
        private const float gelSpd = 3f;
        private const float zolSpd = 4;
        private const float spikeCrossSpd = 3;
        private const float wallMasterSpd = 2;
        private const float wallMasterAttackSpd = -1;
        private const float dragonSpd = 1.5f;
        private const float dodongoSpd = 2;
        private const float goriyaSpd = 1;
        private const float oldManSpd = 0;
        private const float merchantSpd = 0;

        private const int directionChange = 40;
        private const int deathTimerMax = 30;
        private const int keeseIdleMax = 5;
        private const int zolMaxWait = 12;

        public float StalfosSpeed => stalfosSpd;

        public float RopeSpeed => ropeSpd;

        public float MinKeeseSpeed => minKeeseSpd;

        public float MaxKeeseSpeed => maxKeeseSpd;

        public float KeeseAccel => keeseAccel;

        public float MaxKeeseAccel => keeseAccelMax;

        public float GelSpeed => gelSpd;

        public float ZolSpeed => zolSpd;

        public float SpikeCrossSpeed => spikeCrossSpd;

        public float WallMasterSpeed => wallMasterSpd;

        public float WallMasterAttackSpeed => wallMasterAttackSpd;

        public float DragonSpeed => dragonSpd;

        public float DodongoSpeed => dodongoSpd;

        public float GoriyaSpeed => goriyaSpd;

        public float OldManSpeed => oldManSpd;

        public float MerchantSpeed => merchantSpd;

        public int DirectionChange => directionChange;

        public int DeathTimerMax => deathTimerMax;

        public int KeeseIdleMax => keeseIdleMax;

        public int ZolMaxWait => zolMaxWait;

    }
}