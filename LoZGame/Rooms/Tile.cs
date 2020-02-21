namespace LoZGame.Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LoZGame.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class Tile : ITile
    {
        public Vector2 Location { get; set; }

        public string Name { get; set; }

        public Tile(string x, string y, string name)
        {
            this.Location = new Vector2(float.Parse(x), float.Parse(y));
            this.Name = name;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            /*

            TODO

            spriteBatch.Draw(this.Name, )
            
             */
        }
    }
}
