namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct EnemyMiscData
    {
        private const int fireSnakeLength = 5;

        private const int minDirectionChange = 60;
        private const int maxDirectionChange = 180;

        public int FireSnakeLength => fireSnakeLength;

        public int MinDirectionChange => minDirectionChange;

        public int MaxDirectionChange => maxDirectionChange;
    }
}