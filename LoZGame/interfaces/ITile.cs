using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZGame.Interfaces
{
    interface ITile
    {
        Vector2 Location { get; set; }

        string Name { get; set; }

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}
