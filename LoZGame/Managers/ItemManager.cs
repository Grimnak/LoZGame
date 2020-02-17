namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    public class ItemManager
    {
        private List<IItemSprite> itemList;
        public IItemSprite currentItem;
        private int currentIndex;
        private int maxIndex;
        public Vector2 location;

        public ItemManager()
        {
            this.currentIndex = 0;
            this.maxIndex = 0;
        }

        public void loadSprites(int xloc, int yloc)
        {
            this.itemList = ItemSpriteFactory.Instance.getAll(xloc, yloc);
            this.currentItem = this.itemList[this.currentIndex];
            this.location.X = xloc;
            this.location.Y = yloc;
            foreach (IItemSprite sprite in this.itemList)
            {
                this.maxIndex++;
            }
        }

        public void cycleLeft()
        {
            this.location = this.currentItem.location;
            this.currentIndex--;

            if (this.currentIndex < 0)
            {
                this.currentIndex = this.maxIndex - 1;
            }

            this.currentItem = this.itemList[this.currentIndex];
            this.currentItem.location = this.location;
        }

        public void cycleRight()
        {
            this.location = this.currentItem.location;
            this.currentIndex++;
            if (this.currentIndex >= this.maxIndex)
            {
                this.currentIndex = 0;
            }

            this.currentItem = this.itemList[this.currentIndex];
            this.currentItem.location = this.location;
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set { this.currentIndex = value; }
        }
    }
}
