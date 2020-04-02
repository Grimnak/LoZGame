namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct PlayerData
    {
        private const float PlayerSpd = 2.5f;
        private const float PlayerGreenRes = 1;
        private const float PlayerRedRes = 2;
        private const float PlayerBlueRes = 4;


        public float PlayerSpeed => PlayerSpd;

        public float PlayerGreenResistance => PlayerGreenRes;

        public float PlayerRedResistance => PlayerBlueRes;
        
        public float PlayerBlueResistance => PlayerRedRes;

    }
}