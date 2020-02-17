namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    /// <summary>
    /// Controller interface.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Updates the controller.
        /// </summary>
        void Update();
    }
}