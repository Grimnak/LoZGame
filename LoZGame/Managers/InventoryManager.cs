using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class InventoryManager
    {
        public enum ItemType {Bomb, HeartContainer, Triforce, Boomerang, MagicBoomerang, Arrow, RedCandle};
        private Dictionary<int, IUsableItem> itemList;
        private int scale;
        private int currentItem;
        private List<int> deletable;

        public InventoryManager()
        {
            itemList = new Dictionary<int, IUsableItem>();
            this.scale = (int)ItemSpriteFactory.Instance.Scale;
            currentItem = 0;
            deletable = new List<int>();
        }


        public void addItem(ItemType item, Vector2 loc, string direction)
        {
            currentItem++;
            switch (item)
            {
                case (ItemType.Bomb):
                    this.itemList.Add(currentItem, (IUsableItem)ItemSpriteFactory.Instance.Bomb(loc, direction, scale, currentItem));
                    break;
                case (ItemType.Triforce):
                    this.itemList.Add(currentItem, (IUsableItem)ItemSpriteFactory.Instance.Triforce(loc, scale, currentItem));
                    break;
                case (ItemType.Arrow):
                    this.itemList.Add(currentItem, (IUsableItem)ItemSpriteFactory.Instance.Arrow(loc, direction, scale, currentItem));
                    break;
                case (ItemType.Boomerang):
                    this.itemList.Add(currentItem, (IUsableItem)ItemSpriteFactory.Instance.Boomerang(loc, direction, scale, currentItem));
                    break;
                case (ItemType.MagicBoomerang):
                    this.itemList.Add(currentItem, (IUsableItem)ItemSpriteFactory.Instance.MagicBoomerang(loc, direction, scale, currentItem));
                    break;
                case (ItemType.RedCandle):
                    this.itemList.Add(currentItem, (IUsableItem)ItemSpriteFactory.Instance.BlueCandle(loc, direction, scale));
                    break;
                default:
                    break;

            }
        }

        public void removeItem(int instance)
        {
            itemList.Remove(instance);
        }

        public void Update()
        {
            foreach (KeyValuePair<int, IUsableItem> item in this.itemList)
            {
                if (item.Value.IsExpired)
                {
                    deletable.Add(item.Value.Instance);
                }
            }
            foreach (int index in deletable)
            {
                this.removeItem(index);
            }
            foreach (KeyValuePair<int, IUsableItem> item in this.itemList)
            {
                item.Value.Update();
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (KeyValuePair<int, IUsableItem> item in this.itemList)
            {
                item.Value.Draw(spritebatch);
            }
        }

        public void Clear()
        {
            this.itemList = new Dictionary<int, IUsableItem>();
        }
    }
}
