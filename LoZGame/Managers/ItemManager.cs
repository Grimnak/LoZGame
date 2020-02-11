using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{

	public class ItemManager
	{
		private List<IItemSprite> itemList;
		public IItemSprite currentItem;
		private int currentIndex;
		private int maxIndex;
		public Vector2 location;

		public ItemManager()
		{
			currentIndex = 0;
			maxIndex = 0;
        }

		public void loadSprites(int xloc, int yloc)
        {
			this.itemList = ItemSpriteFactory.Instance.getAll(xloc, yloc);
			this.currentItem = this.itemList[this.currentIndex];
			location.X = xloc;
			location.Y = yloc;
			foreach (IItemSprite sprite in itemList)
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
			this.currentItem = this.itemList[this.currentIndex];
        }

		public void cycleRight()
        {
			this.currentIndex++;
			if (this.currentIndex >= this.maxIndex)
            {
				this.currentIndex = 0;
            }
			this.currentItem = this.itemList[this.currentIndex];
        }
	}
}
