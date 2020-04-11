namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct EnemyMiscData
    {
        private const int fireSnakeLength = 5;
        private const int ropeLinkPixelBuffer = 5;


        public int FireSnakeLength => fireSnakeLength;

        public int RopeLinkPixelBuffer => ropeLinkPixelBuffer;

        public double SpikeCrossVertBoundary => (BlockSpriteFactory.Instance.TileHeight * 3.5) + (BlockSpriteFactory.Instance.TopOffset / 2) + (LoZGame.Instance.InventoryOffset / 2);

        public double SpikeCrossHorizontalBoundary => (BlockSpriteFactory.Instance.TileWidth * 6) + (BlockSpriteFactory.Instance.HorizontalOffset / 2);
    }
}