namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct EnemyMassData
    {
        private const int stalfosMass = 14;
        private const int goriyaMass = 16;
        private const int ropeMass = 8;
        private const int keeseMass = 8;
        private const int zolMass = 12;
        private const int gelMass = 8;
        private const int dragonMass = 24;
        private const int dodongoMass = 12;
        private const int spikeCrossMass = 16;
        private const int wallMasterMass = 14;
        private const int fireSnakeMass = 20;

        public int StalfosMass { get { return stalfosMass; } }
        
        public int GoriyaMass { get { return goriyaMass; } }
        
        public int KeeseMass { get { return keeseMass; } }
        
        public int RopeMass { get { return ropeMass; } }
        
        public int GelMass { get { return gelMass; } }
        
        public int ZolMass { get { return zolMass; } }
        
        public int DragonMass { get { return dragonMass; } }
        
        public int DodongoMass { get { return dodongoMass; } }
        
        public int SpikeCrossMass { get { return spikeCrossMass; } }

        public int WallMasterMass { get { return wallMasterMass; } }

        public int FireSnakeMass => fireSnakeMass;
    }
}