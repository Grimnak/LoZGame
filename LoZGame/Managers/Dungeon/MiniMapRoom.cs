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
        private readonly Color BackgroundColor = Color.SandyBrown;
        private readonly Color RoomColor = Color.SaddleBrown;
        private Rectangle sourceRectangle = new Rectangle(Point.Zero, new Point(1));
        private Texture2D sprite;
        private bool exists;
        private bool visited;
        private Vector2 location;

        public MiniMapRoom(int x, int y, List<MiniMap.DoorLocation> doors)
        {
            this.visited = true;
            this.location = new Vector2(x,y);
            CreateSprite();
        }

        private void CreateSprite()
        {
            this.sprite = new Texture2D(LoZGame.Instance.GraphicsDevice, 5, 5, false, SurfaceFormat.Color);
        }

        public void Explore()
        {
            this.visited = true;
        }

        public void Draw(Point startLoc, Point roomSize)
        {
            if (this.visited)
            {
                //Rectangle drawLocation = new Rectangle(new Point(startLoc.X + ((int)this.location.X * roomSize.X), startLoc.Y + ((int)this.location.Y * roomSize.Y)), new Point(roomSize.X, roomSize.Y));
                Rectangle drawLocation = new Rectangle(400, 200, 50, 50);
                LoZGame.Instance.SpriteBatch.Draw(this.sprite, drawLocation, this.sourceRectangle, this.RoomColor, 0.0f, Vector2.Zero, SpriteEffects.None, 1.0f);
            }
        }
    }
}
