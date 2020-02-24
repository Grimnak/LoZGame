namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class ItemManager
    {
        private List<IItemSprite> itemList;
        public IItemSprite CurrentItem;
        private int currentIndex;
        private int maxIndex;
        public Vector2 Location;


        private static readonly ItemManager instance = new ItemManager();

        public static ItemManager Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemManager()
        {
            this.currentIndex = 0;
            this.maxIndex = 0;
        }

        public void LoadSprites(int xloc, int yloc)
        {
            this.itemList = ItemSpriteFactory.Instance.getAll(xloc, yloc);
            this.CurrentItem = this.itemList[this.currentIndex];
            this.Location.X = xloc;
            this.Location.Y = yloc;
            foreach (IItemSprite sprite in this.itemList)
            {
                this.maxIndex++;
            }
        }

        public void CycleLeft()
        {
            this.Location = this.CurrentItem.Location;
            this.currentIndex--;

            if (this.currentIndex < 0)
            {
                this.currentIndex = this.maxIndex - 1;
            }

            this.CurrentItem = this.itemList[this.currentIndex];
            // this.currentItem.location = this.location;
        }

        public void CycleRight()
        {
            this.Location = this.CurrentItem.Location;
            this.currentIndex++;
            if (this.currentIndex >= this.maxIndex)
            {
                this.currentIndex = 0;
            }

            this.CurrentItem = this.itemList[this.currentIndex];
            // this.currentItem.location = this.location;
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set { this.currentIndex = value; }
        }
    }
}