using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public interface IDoorState
    {
        void Close(); // for entering a special room

        void Open(); // for locked doors and special doors 

        void Bombed(); // for hidden doors

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}
