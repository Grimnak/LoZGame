namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class DropManager
    {

        public DropManager()
        {
        }

        private bool CanDropItem()
        {
            return LoZGame.Instance.Random.Next(0, 100) <= DropChance;
        }

        /// <summary>
        /// Determines the drop based on the drop type in the droptable (item1) and the weight of that item type (item2).
        /// </summary>
        /// <param name="dropTable">The drop table to sample and choose an item from.</param>
        /// <returns>A tuple containing the item that dropped, its weight, the minimum amount of that item that can drop, and the maximum amount of that item that can drop.</returns>
        private Tuple<DropType, int, int, int> DetermineDrop(List<Tuple<DropType, int, int, int>> dropTable)
        {
            int totalWeight = 0;
            foreach (Tuple<DropType, int, int, int> drop in dropTable)
            {
                totalWeight += drop.Item2;
            }
            int randomWeight = LoZGame.Instance.Random.Next(0, totalWeight);
            int checkedWeight = 0;
            foreach (Tuple<DropType, int, int, int> drop in dropTable)
            {
                if (randomWeight < checkedWeight + drop.Item2)
                {
                    return drop;
                }
                else
                {
                    checkedWeight += drop.Item2;
                }
            }
            return dropTable[dropTable.Count - 1];
        }
    }
}
