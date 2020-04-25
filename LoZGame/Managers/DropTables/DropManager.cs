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

        private bool CanDropItem(int dropWeight = dropChance)
        {
            return LoZGame.Instance.Random.Next(0, 100) <= dropWeight;
        }

        /// <summary>
        /// Determines the drop based on the drop type in the droptable (item1) and the weight of that item type (item2).
        /// </summary>
        /// <param name="dropTable">The drop table to sample and choose an item from.</param>
        /// <returns>A tuple containing the item that dropped, its weight, the minimum amount of that item that can drop, and the maximum amount of that item that can drop.</returns>
        private Tuple<DropType, int, int, int> DetermineDrop(List<Tuple<DropType, int, int, int>> dropTable)
        {
            // Calculate the total weight of all the items in the drop table and store them into a variable.
            int totalWeight = 0;
            foreach (Tuple<DropType, int, int, int> drop in dropTable)
            {
                totalWeight += drop.Item2;
            }

            // Generate a random number that corresponds to what the drop will be.
            int randomWeight = LoZGame.Instance.Random.Next(0, totalWeight);

            // Determines what the drop will be based off of the random number.
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

            // If no item is determined to drop, just drop the last one in the drop table.
            return dropTable[dropTable.Count - 1];
        }
    }
}
