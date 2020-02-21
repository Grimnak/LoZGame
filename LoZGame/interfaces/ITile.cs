namespace LoZGame.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    interface ITile
    {
        Vector2 Location { get; set; }

        string Name { get; set; }

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}
