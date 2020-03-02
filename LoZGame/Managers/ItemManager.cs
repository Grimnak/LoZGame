namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class ItemManager
    {
        private List<IItem> itemList;
        public IItem CurrentItem;
        private int currentIndex;
        private int maxIndex;
        public ItemManager()
        {
            this.currentIndex = 0;
            this.maxIndex = 0;
        }

        public void LoadSprites(int xloc, int yloc)
        {
            this.itemList = ItemSpriteFactory.Instance.getAll(xloc, yloc);
            this.CurrentItem = this.itemList[this.currentIndex];
            foreach (IItem sprite in this.itemList)
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

            this.CurrentItem = this.itemList[this.currentIndex];
        }

        public void CycleRight()
        {
            this.currentIndex++;
            if (this.currentIndex >= this.maxIndex)
            {
                this.currentIndex = 0;
            }

            this.CurrentItem = this.itemList[this.currentIndex];
        }

        public void Update()
        {
            this.CurrentItem.Update();
        }

        public void Draw()
        {
            this.CurrentItem.Draw();
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set { this.currentIndex = value; }
        }
    }
}