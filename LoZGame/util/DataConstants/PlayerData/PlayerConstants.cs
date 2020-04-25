namespace LoZClone
{
    public struct PlayerConstants
    {
        private const float PlayerSpd = 3.5f;
        private const int AnimationSpd = 5;
        private const float PlayerGreenRes = 1;
        private const float PlayerRedRes = 2;
        private const float PlayerBlueRes = 4;
        private const int StartingHP = 20;
        private const int LockoutWait = 15;
        private const int MaxFrames = 2;
        private const int Mss = 16;

        public float PlayerSpeed => PlayerSpd;

        public int AnimationSpeed => AnimationSpd;

        public float PlayerGreenResistance => PlayerGreenRes;

        public float PlayerRedResistance => PlayerRedRes;
        
        public float PlayerBlueResistance => PlayerBlueRes;

        public int StartingHealth => StartingHP;

        public int LockoutWaitTime => LockoutWait;

        public int MaximumFrames => MaxFrames;

        public int Mass => Mss;
    }
}