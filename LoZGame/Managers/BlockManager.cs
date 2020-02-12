using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class BlockManager
    {
        private List<ISprite> blockList;
        public ISprite currentBlock;
        private int currentIndex;
        private int maxIndex;
        public Vector2 location;

        public BlockManager()
        {
            currentIndex = 0;
            maxIndex = 0;
        }

        public void loadSprites(int xloc, int yloc)
        {
            this.blockList = BlockSpriteFactory.Instance.getAll(xloc, yloc);
            this.currentBlock = this.blockList[this.currentIndex];
            location.X = xloc;
            location.Y = yloc;
            foreach (ISprite sprite in blockList)
            {
                maxIndex++;
            }
        }

        public void cycleLeft()
        {
            this.currentIndex--;
            if (this.currentIndex < 0)
            {
                this.currentIndex = this.maxIndex - 1;
            }
            this.currentBlock = this.blockList[this.currentIndex];
        }

        public void cycleRight()
        {
            this.currentIndex++;
            if (this.currentIndex >= this.maxIndex)
            {
                this.currentIndex = 0;
            }
            this.currentBlock = this.blockList[this.currentIndex];
        }

        public int CurrentIndex{
            get { return currentIndex; }
            set { currentIndex = value; }
        }
	}
}
