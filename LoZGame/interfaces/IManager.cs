using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    /// <summary>
    /// Interface for manager classes.
    /// </summary>
    interface IManager
    {
        /// <summary>
        /// Updates all objects in the managers list.
        /// </summary>
        void Update();

        /// <summary>
        /// Draws all objects in the managers list.
        /// </summary>
        void Draw();

        /// <summary>
        /// Clears the managers list.
        /// </summary>
        void Clear();

    }
}
