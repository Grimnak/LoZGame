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
            this.scale = (int)ItemSpriteFactory.Instance.scale;
        }


        public void addItem(ItemType item, Vector2 loc, Texture2D texture)
        {
            switch (item)
            {
                case (ItemType.Bomb):
                    this.itemList.Add(ItemSpriteFactory.Instance.Bomb(texture, loc, scale));
                    break;
                case (ItemType.Triforce):
                    this.itemList.Add(ItemSpriteFactory.Instance.Triforce());
                    break;
                case (ItemType.HeartContainer):
                    this.itemList.Add(ItemSpriteFactory.Instance.HeartContainer());
                    break;
                case (ItemType.Arrow):
                    this.itemList.Add(ItemSpriteFactory.Instance.Arrow());
                    break;
                case (ItemType.Boomerang):
                    this.itemList.Add(ItemSpriteFactory.Instance.Boomerang());
                    break;
                case (ItemType.MagicBoomerang):
                    this.itemList.Add(ItemSpriteFactory.Instance.MagicBoomerang());
                    break;
                case (ItemType.RedCandle):
                    this.itemList.Add(ItemSpriteFactory.Instance.RedCandle());
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
