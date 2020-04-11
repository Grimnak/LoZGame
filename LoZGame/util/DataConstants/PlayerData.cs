namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct PlayerData
    {
        private const float playerSpd = 3.5f;
        private const int animationSpd = 5;
        private const float playerGreenRes = 1;
        private const float PlayerRedRes = 2;
        private const float playerBlueRes = 4;
        private const int startingHP = 12;
        private const int lockoutWaitTime = 15;
        private const int maxFrames = 2;
        private const int mass = 16;

        public float PlayerSpeed => playerSpd;

        public int AnimationSpeed => animationSpd;

        public float PlayerGreenResistance => playerGreenRes;

        public float PlayerRedResistance => playerBlueRes;
        
        public float PlayerBlueResistance => PlayerRedRes;

        public int StartingHealth => startingHP;

        public int LockoutWaitTime => lockoutWaitTime;

        public int MaxFrames => maxFrames;

        public int Mass => mass;
    }
}