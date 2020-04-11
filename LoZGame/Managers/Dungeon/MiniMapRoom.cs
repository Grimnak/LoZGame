using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class MiniMapRoom
    {
        private static readonly Color BackgroundColor = Color.SandyBrown;
        private static readonly Color RoomColor = Color.SaddleBrown;
        private ISprite sprite;
        private bool exists;
        private bool visited;
        private Vector2 location;

        public MiniMapRoom(int x, int y, List<MiniMap.DoorLocation> doors)
        {
            this.visited = false;
            this.location = new Vector2(x,y);
            CreateSprite();
        }

        private void CreateSprite()
        {
            Texture2D roomSprite = new Texture2D(LoZGame.Instance.GraphicsDevice, 5, 5, false, SurfaceFormat.Color);
        }

        public void Explore()
        {
            this.visited = true;
        }

        public void Draw(Point startLoc, Point roomSize)
        {
            if (this.visited)
            {
                this.sprite.Draw(this.location, LoZGame.Instance.DefaultTint, 1.0f);
            }
        }
    }
}
