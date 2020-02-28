namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class OldBlockManager
    {
        private List<IBlock> blockList;
        public IBlock CurrentBlock;
        private int currentIndex;
        private int maxIndex;
        public Vector2 Location;

        public OldBlockManager()
        {
            this.currentIndex = 0;
            this.maxIndex = 0;
            this.blockList = new List<IBlock>();
        }

        private void LoadBlocks()
        {
        }

        public void LoadSprites(int xloc, int yloc)
        {
            this.LoadBlocks();
            if (this.blockList.Count != 0)
            {
                this.CurrentBlock = this.blockList[this.currentIndex];
                this.Location.X = xloc;
                this.Location.Y = yloc;
                foreach (ISprite sprite in this.blockList)
                {
                    this.maxIndex++;
                }
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