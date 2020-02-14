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
        private enum ItemType {Bomb, SilverArrow, Triforce, Boomerang, MagicBoomerang, Arrow, RedCandle, BlueCandle};
        private ItemType item;
        private Dictionary<int, IUsableItem> itemList;
        private int scale;
        private int itemId;
        private List<int> deletable;

        public InventoryManager()
        {
            itemList = new Dictionary<int, IUsableItem>();
            this.scale = (int)ItemSpriteFactory.Instance.Scale;
            itemId = 0;
            deletable = new List<int>();
        }

        public int Arrow
        {
            get { return (int)ItemType.Arrow; }
        }
        public int SilverArrow
        {
            get { return (int)ItemType.SilverArrow; }
        }
        public int Boomerang
        {
            get { return (int)ItemType.Boomerang; }
        }
        public int MagicBoomerang
        {
            get { return (int)ItemType.MagicBoomerang; }
        }
        public int BlueCandle
        {
            get { return (int)ItemType.BlueCandle; }
        }
        public int RedCandle
        {
            get { return (int)ItemType.RedCandle; }
        }
        public int Bomb
        {
            get { return (int)ItemType.Bomb; }
        }
        public int Triforce
        {
            get { return (int)ItemType.Triforce; }
        }


        public void addItem(int item, Vector2 loc, string direction)
        {
            itemId++;
            this.item = (ItemType)item;
            switch (this.item)
            {
                case (ItemType.Bomb):
                    this.itemList.Add(itemId, (IUsableItem)ItemSpriteFactory.Instance.Bomb(loc, direction, scale, itemId));
                    break;
                case (ItemType.Triforce):
                    this.itemList.Add(itemId, (IUsableItem)ItemSpriteFactory.Instance.Triforce(loc, scale, itemId));
                    break;
                case (ItemType.Arrow):
                    this.itemList.Add(itemId, (IUsableItem)ItemSpriteFactory.Instance.Arrow(loc, direction, scale, itemId));
                    break;
                case (ItemType.SilverArrow):
                    this.itemList.Add(itemId, (IUsableItem)ItemSpriteFactory.Instance.SilverArrow(loc, direction, scale, itemId));
                    break;
                case (ItemType.RedCandle):
                    this.itemList.Add(itemId, (IUsableItem)ItemSpriteFactory.Instance.RedCandle(loc, direction, scale, itemId));
                    break;
                case (ItemType.BlueCandle):
                    this.itemList.Add(itemId, (IUsableItem)ItemSpriteFactory.Instance.BlueCandle(loc, direction, scale, itemId));
                    break;
                default:
                    break;

            }
        }

        public void addItem(int item, Link player)
        {
            this.item = (ItemType)item;
            itemId++;
            switch (this.item)
            {
                case (ItemType.Boomerang):
                    this.itemList.Add(itemId, (IUsableItem)ItemSpriteFactory.Instance.Boomerang(player, scale, itemId));
                    break;
                case (ItemType.MagicBoomerang):
                    this.itemList.Add(itemId, (IUsableItem)ItemSpriteFactory.Instance.MagicBoomerang(player, scale, itemId));
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
