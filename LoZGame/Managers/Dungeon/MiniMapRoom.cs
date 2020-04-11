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
        private static readonly int BorderOffset = 4;
        private static readonly int DoorSize = 12;

        private static readonly Color MapColor = Color.Brown;

        private static readonly float MapLayer = 1.0f;
        private static readonly float BackgroundLayer = 0.9f;

        private bool visited;
        private Vector2 location;
        List<MiniMap.DoorLocation> doors;

        private Texture2D MapSprite;
        private Rectangle MapSourceRectangle;

        public Point Location => new Point((int)location.X, (int)location.Y);

        public MiniMapRoom(int x, int y, List<MiniMap.DoorLocation> doors)
        {
            this.doors = doors;
            this.visited = false;
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
                // defines location to draw map
                Rectangle drawLocation = new Rectangle(new Point(startLoc.X + ((int)this.location.X * roomSize.X), startLoc.Y + ((int)this.location.Y * roomSize.Y)), new Point(roomSize.X, roomSize.Y));
                
                // draw doors
                this.MapSprite.SetData<Color>(new Color[] { MapColor});
                DrawDoors(drawLocation);

                // door processing
                drawLocation = new Rectangle(new Point(drawLocation.X + BorderOffset, drawLocation.Y + BorderOffset), new Point(roomSize.X - (BorderOffset), roomSize.Y - (BorderOffset)));
                LoZGame.Instance.SpriteBatch.Draw(this.MapSprite, drawLocation, this.MapSourceRectangle, MapColor, 0.0f, Vector2.Zero, SpriteEffects.None, MapLayer);

            }
        }

        private void DrawDoors(Rectangle drawLocation)
        {
            Point roomCenter = drawLocation.Center;
            foreach (MiniMap.DoorLocation loc in doors)
            {
                Rectangle doorLocation;
                switch (loc)
                {
                    case MiniMap.DoorLocation.North:
                        doorLocation = new Rectangle(roomCenter.X - (DoorSize / 2), drawLocation.Top, DoorSize, BorderOffset);
                        break;
                    case MiniMap.DoorLocation.South:
                        doorLocation = new Rectangle(roomCenter.X - (DoorSize / 2), drawLocation.Bottom, DoorSize, BorderOffset);
                        break;
                    case MiniMap.DoorLocation.East:
                        doorLocation = new Rectangle(drawLocation.Right, roomCenter.Y - (DoorSize / 2), BorderOffset, DoorSize);
                        break;
                    default:
                        doorLocation = new Rectangle(drawLocation.Left, roomCenter.Y - (DoorSize / 2), BorderOffset, DoorSize);
                        break;
                }
                LoZGame.Instance.SpriteBatch.Draw(this.MapSprite, doorLocation, this.MapSourceRectangle, MapColor, 0.0f, Vector2.Zero, SpriteEffects.None, MapLayer);
            }
        }
    }
}
