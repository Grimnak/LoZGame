using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class ProjectileManager
    {
        private enum ProjectileType {Bomb, SilverArrow, Triforce, Boomerang, MagicBoomerang, Arrow, RedCandle, BlueCandle};
        private ProjectileType item;
        private Dictionary<int, IProjectile> itemList;
        private int scale;
        private int itemId;
        private List<int> deletable;

        public ProjectileManager()
        {
            itemList = new Dictionary<int, IProjectile>();
            this.scale = (int)ItemSpriteFactory.Instance.Scale;
            itemId = 0;
            deletable = new List<int>();
        }

        public int Arrow
        {
            get { return (int)ProjectileType.Arrow; }
        }
        public int SilverArrow
        {
            get { return (int)ProjectileType.SilverArrow; }
        }
        public int Boomerang
        {
            get { return (int)ProjectileType.Boomerang; }
        }
        public int MagicBoomerang
        {
            get { return (int)ProjectileType.MagicBoomerang; }
        }
        public int BlueCandle
        {
            get { return (int)ProjectileType.BlueCandle; }
        }
        public int RedCandle
        {
            get { return (int)ProjectileType.RedCandle; }
        }
        public int Bomb
        {
            get { return (int)ProjectileType.Bomb; }
        }
        public int Triforce
        {
            get { return (int)ProjectileType.Triforce; }
        }


        public void addItem(int item, Vector2 loc, string direction)
        {
            itemId++;
            this.item = (ProjectileType)item;
            switch (this.item)
            {
                case (ProjectileType.Bomb):
                    this.itemList.Add(itemId, ProjectileSpriteFactory.Instance.Bomb(loc, direction, scale, itemId));
                    break;
                case (ProjectileType.Triforce):
                    this.itemList.Add(itemId, ProjectileSpriteFactory.Instance.Triforce(loc, scale, itemId));
                    break;
                case (ProjectileType.Arrow):
                    this.itemList.Add(itemId, ProjectileSpriteFactory.Instance.Arrow(loc, direction, scale, itemId));
                    break;
                case (ProjectileType.SilverArrow):
                    this.itemList.Add(itemId, ProjectileSpriteFactory.Instance.SilverArrow(loc, direction, scale, itemId));
                    break;
                case (ProjectileType.RedCandle):
                    this.itemList.Add(itemId, ProjectileSpriteFactory.Instance.RedCandle(loc, direction, scale, itemId));
                    break;
                case (ProjectileType.BlueCandle):
                    this.itemList.Add(itemId, ProjectileSpriteFactory.Instance.BlueCandle(loc, direction, scale, itemId));
                    break;
                default:
                    break;

            }
        }

        public void addItem(int item, Link player)
        {
            this.item = (ProjectileType)item;
            itemId++;
            switch (this.item)
            {
                case (ProjectileType.Boomerang):
                    this.itemList.Add(itemId, ProjectileSpriteFactory.Instance.Boomerang(player, scale, itemId));
                    break;
                case (ProjectileType.MagicBoomerang):
                    this.itemList.Add(itemId, ProjectileSpriteFactory.Instance.MagicBoomerang(player, scale, itemId));
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
            foreach (KeyValuePair<int, IProjectile> item in this.itemList)
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
            deletable.Clear();
            foreach (KeyValuePair<int, IProjectile> item in this.itemList)
            {
                item.Value.Update();
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (KeyValuePair<int, IProjectile> item in this.itemList)
            {
                item.Value.Draw(spritebatch);
            }
        }

        public void Clear()
        {
            this.itemList = new Dictionary<int, IProjectile>();
        }
    }
}
