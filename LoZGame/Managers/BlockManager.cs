namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class BlockManager
    {
        private List<IBlockSprite> blockList;
        public IBlockSprite CurrentBlock;
        private int currentIndex;
        private int maxIndex;
        public Vector2 Location;

        private static readonly BlockManager instance = new BlockManager();

        public static BlockManager Instance
        {
            get
            {
                return instance;
            }
        }


        private BlockManager()
        {
            this.currentIndex = 0;
            this.maxIndex = 0;
        }

        public void LoadSprites(int xloc, int yloc)
        {
            this.blockList = BlockSpriteFactory.Instance.GetAll(xloc, yloc);
            this.CurrentBlock = this.blockList[this.currentIndex];
            this.Location.X = xloc;
            this.Location.Y = yloc;
            foreach (IBlockSprite sprite in this.blockList)
            {
                this.maxIndex++;
            }
        }

        public void CycleLeft()
        {
            this.currentIndex--;
            if (this.currentIndex < 0)
            {
                this.currentIndex = this.maxIndex - 1;
            }

            this.CurrentBlock = this.blockList[this.currentIndex];
        }

        public void cycleRight()
        {
            this.currentIndex++;
            if (this.currentIndex >= this.maxIndex)
            {
                this.currentIndex = 0;
            }

            this.CurrentBlock = this.blockList[this.currentIndex];
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set { this.currentIndex = value; }
        }
    }
}