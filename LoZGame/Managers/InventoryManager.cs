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
        private List<IItemSprite> itemList;
        private int scale;

        public InventoryManager()
        {
            itemList = new List<IItemSprite>();
            this.scale = (int)ItemSpriteFactory.Instance.Scale;
        }


        public void addItem(ItemType item, Vector2 loc, string direction)
        {
            switch (item)
            {
                case (ItemType.Bomb):
                    this.itemList.Add(ItemSpriteFactory.Instance.Bomb(loc, direction, scale));
                    break;
                case (ItemType.Triforce):
                    this.itemList.Add(ItemSpriteFactory.Instance.Triforce(loc, direction, scale));
                    break;
                case (ItemType.HeartContainer):
                    this.itemList.Add(ItemSpriteFactory.Instance.HeartContainer(loc, direction, scale));
                    break;
                case (ItemType.Arrow):
                    this.itemList.Add(ItemSpriteFactory.Instance.Arrow(loc, direction, scale));
                    break;
                case (ItemType.Boomerang):
                    this.itemList.Add(ItemSpriteFactory.Instance.Boomerang(loc, direction, scale));
                    break;
                case (ItemType.MagicBoomerang):
                    this.itemList.Add(ItemSpriteFactory.Instance.MagicBoomerang(loc, direction, scale));
                    break;
                case (ItemType.RedCandle):
                    this.itemList.Add(ItemSpriteFactory.Instance.BlueCandle(loc, direction scale));
                    break;
                default:
                    break;

            }
        }

        public void Update()
        {
            foreach (IItemSprite item in this.itemList)
            {
                item.Update();
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (IItemSprite item in this.itemList)
            {
                item.Draw(spritebatch);
            }
        }

        public void Clear()
        {
            this.itemList = new List<IItemSprite>();
        }
    }
}
