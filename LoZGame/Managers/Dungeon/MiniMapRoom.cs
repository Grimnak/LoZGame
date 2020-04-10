using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class MiniMapRoom
    {
        private ISprite sprite;
        private bool exists;
        private bool visited;
        private Vector2 location;

        public MiniMapRoom(bool exists, ISprite sprite, int y, int x)
        {
            this.exists = exists;
            this.sprite = sprite;
            this.visited = false;

            this.location = new Vector2(x,y);
        }

        public void Explore()
        {
            this.visited = true;
        }


        public void Draw()
        {
            if (this.visited)
            {
                this.sprite.Draw(this.location, LoZGame.Instance.DefaultTint, 1.0f);
            }
        }


    }
}
