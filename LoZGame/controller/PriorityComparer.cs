namespace LoZGame
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Compares priorities of commands.
    /// </summary>
    public class PriorityComparer : IComparer<KeyValuePair<Keys, ICommand>>
    {
        /// <inheritdoc/>
        public int Compare(KeyValuePair<Keys, ICommand> x, KeyValuePair<Keys, ICommand> y)
        {
            if (x.Value.Priority > y.Value.Priority)
            {
                return -1;
            }
            else if (x.Value.Priority < y.Value.Priority)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}