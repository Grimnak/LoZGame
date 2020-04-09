namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct DefaultData
    {
        // Damage Values
        private const int stalfosDmg = 2;
        private const int keeseDmg = 2;
        private const int ropeDmg = 2;
        private const int gelDmg = 2;
        private const int zolDmg = 4;
        private const int spikeCrossDmg = 4;
        private const int wallMasterDmg = 1;
        private const int dragonDmg = 4;
        private const int dodongoDmg = 4;
        private const int goriyaDmg = 4;
        private const int oldManDmg = 0;
        private const int merchantDmg = 0;

        // Health Values
        private const int stalfosHP = 8;
        private const int keeseHP = 2;
        private const int ropeHP = 2;
        private const int gelHP = 2;
        private const int zolHP = 8;
        private const int spikeCrossHP = 1;
        private const int wallMasterHP = 12;
        private const int dragonHP = 32;
        private const int dodongoHP = 32;
        private const int goriyaHP = 12;
        private const int oldManHP = 1;
        private const int merchantHP = 1;

        // Damage Accessors
        public int StalfosDamage => stalfosDmg;

        public int RopeDamage => ropeDmg;

        public int KeeseDamage => keeseDmg;

        public int GelDamage => gelDmg;

        public int ZolDamage => zolDmg;

        public int SpikeCrossDamage => spikeCrossDmg;

        public int WallMasterDamage => wallMasterDmg;

        public int DragonDamage => dragonDmg;

        public int DodongoDamage => dodongoDmg;

        public int GoriyaDamage => goriyaDmg;

        public int OldManDamage => oldManDmg;

        public int MerchantDamage => merchantDmg;

        // Health Accessors
        public int StalfosHealth => stalfosHP;

        public int RopeHealth => ropeHP;

        public int KeeseHealth => keeseHP;

        public int GelHealth => gelHP;

        public int ZolHealth => zolHP;

        public int SpikeCrossHealth => spikeCrossHP;

        public int WallMasterHealth => wallMasterHP;

        public int DragonHealth => dragonHP;

        public int DodongoHealth => dodongoHP;

        public int GoriyaHealth => goriyaHP;

        public int OldManHealth => oldManHP;

        public int MerchantHealth => merchantHP;
    }
}