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
        private static readonly int BorderOffset = 2;

        private static readonly Color MapColor = Color.SandyBrown;
        private static readonly Color BackGroundColor = Color.SaddleBrown;

        private static readonly float MapLayer = 0.994f;
        private static readonly float ItemLayer = 0.995f;

        private bool visited;
        private Vector2 location;

        private Texture2D MapSprite;
        private Rectangle MapSourceRectangle;

        public MiniMapRoom(int x, int y, List<MiniMap.DoorLocation> doors)
        {
            this.visited = true;
            this.location = new Vector2(x, y); 
            this.MapSprite = new Texture2D(LoZGame.Instance.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            this.MapSourceRectangle = new Rectangle(0, 0, 1, 1);
        }

        public void Explore()
        {
            this.visited = true;
        }

        public void Draw(Point startLoc, Point roomSize)
        {
            if (this.visited)
            {
                Rectangle drawLocation = new Rectangle(new Point(startLoc.X + ((int)this.location.X * roomSize.X), startLoc.Y + ((int)this.location.Y * roomSize.Y)), new Point(roomSize.X, roomSize.Y));

                // Draws Background
                this.MapSprite.SetData<Color>(new Color[] { BackGroundColor });
                LoZGame.Instance.SpriteBatch.Draw(this.MapSprite, drawLocation, this.MapSourceRectangle, BackGroundColor, 0.0f, Vector2.Zero, SpriteEffects.None, 0);

                // Draw Room TODO: add door processing
                drawLocation = new Rectangle(new Point(drawLocation.X + BorderOffset, drawLocation.Y + BorderOffset), new Point(roomSize.X - (BorderOffset * 2), roomSize.Y - (BorderOffset * 2)));
                this.MapSprite.SetData<Color>(new Color[] { MapColor });
                LoZGame.Instance.SpriteBatch.Draw(this.MapSprite, drawLocation, this.MapSourceRectangle, MapColor, 0.0f, Vector2.Zero, SpriteEffects.None, 0);
            }
        }
    }
}
