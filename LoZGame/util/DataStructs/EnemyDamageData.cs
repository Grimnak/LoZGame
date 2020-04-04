namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct EnemyDamageData
    {
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
    }
}