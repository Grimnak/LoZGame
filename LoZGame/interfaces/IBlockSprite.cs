using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface IBlockSprite
    {
        Vector2 location { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
