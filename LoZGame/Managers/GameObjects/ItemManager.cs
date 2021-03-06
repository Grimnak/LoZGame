﻿namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class ItemManager : IManager
    {
        private Dictionary<int, IItem> itemList;
        private int itemListSize;
        private int itemID;
        private readonly List<int> deletable;

        private List<IItem> items;

        public List<IItem> ItemList { get { return items; } }

        public ItemManager()
        {
            itemList = new Dictionary<int, IItem>();
            items = new List<IItem>();
            itemListSize = 0;
            deletable = new List<int>();
        }

        public void Add(IItem item)
        {
            if (!item.Expired)
            {
                itemListSize++;
                itemList.Add(itemID, item);
                itemID++;
            }
        }

        public void RemoveItem(int instance)
        {
            itemList.Remove(instance);
            itemListSize--;
        }

        public void Update()
        {
            foreach (KeyValuePair<int, IItem> item in itemList)
            {
                if (item.Value.Expired)
                {
                    deletable.Add(item.Key);
                }
            }

            foreach (int index in deletable)
            {
                RemoveItem(index);
            }

            deletable.Clear();

            items.Clear();

            foreach (KeyValuePair<int, IItem> item in itemList)
            {
                items.Add(item.Value);
                item.Value.Update();
            }
        }

        public void Draw()
        {
            foreach (KeyValuePair<int, IItem> item in itemList)
            {
                item.Value.Draw(Color.White);
            }
        }

        public void Clear()
        {
            itemList = new Dictionary<int, IItem>();
        }
    }
}