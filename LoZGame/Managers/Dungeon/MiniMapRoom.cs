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
        private const int BlinkRate = 30;
        private const int DotSize = 8;
        private int lifetime;
        private static readonly int BorderOffset = 4;
        private int DoorSize;

        private Color MapColor;

        private static readonly float DotLayer = 1.0f;
        private static readonly float MapLayer = 0.9999f;
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

        private void Draw(Point startLoc, Point roomSize)
        {
            // defines location to draw map
            Rectangle drawLocation = new Rectangle(new Point(startLoc.X + ((int)this.location.X * roomSize.X), startLoc.Y + ((int)this.location.Y * roomSize.Y)), new Point(roomSize.X, roomSize.Y));

            // draw doors
            this.MapSprite.SetData<Color>(new Color[] { MapColor });
            DrawDoors(drawLocation);

            // door processing
            drawLocation = new Rectangle(new Point(drawLocation.X + BorderOffset, drawLocation.Y + BorderOffset), new Point(roomSize.X - BorderOffset, roomSize.Y - BorderOffset));
            LoZGame.Instance.SpriteBatch.Draw(this.MapSprite, drawLocation, this.MapSourceRectangle, MapColor, 0.0f, Vector2.Zero, SpriteEffects.None, MapLayer);
        }

        public void DrawInventory(Point startLoc, Point roomSize, Color color)
        {
            if (this.visited)
            {
                this.DoorSize = 11;
                this.MapColor = color;
                this.Draw(startLoc, roomSize);
            }
        }

        public void DrawMiniMap(Point startLoc, Point roomSize, Color color)
        {
            if (LoZGame.Instance.Players[0].Inventory.HasMap)
            {
                this.DoorSize = 5;
                this.MapColor = color;
                this.Draw(startLoc, roomSize);
            }
        }

        public void DrawDot(Point startLoc, Point roomSize, Color color)
        {
            this.lifetime++;
            if (this.lifetime < BlinkRate)
            {
                this.MapSprite.SetData<Color>(new Color[] { color });
                Rectangle drawLocation = new Rectangle(new Point(startLoc.X + ((int)this.location.X * roomSize.X), startLoc.Y + ((int)this.location.Y * roomSize.Y)), new Point(DotSize));
                drawLocation.X += (roomSize.X / 2) - (DotSize / 2) + 2;
                drawLocation.Y += (roomSize.Y / 2) - (DotSize / 2) + 2;
                LoZGame.Instance.SpriteBatch.Draw(this.MapSprite, drawLocation, this.MapSourceRectangle, color, 0.0f, Vector2.Zero, SpriteEffects.None, DotLayer);
                // add compass functionality here
            }
            if (this.lifetime >= BlinkRate * 2)
            {
                this.lifetime = 0;
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
                        doorLocation = new Rectangle(roomCenter.X - (DoorSize / 2) + 2, drawLocation.Top, DoorSize, BorderOffset);
                        break;
                    case MiniMap.DoorLocation.South:
                        doorLocation = new Rectangle(roomCenter.X - (DoorSize / 2) + 2, drawLocation.Bottom, DoorSize, BorderOffset);
                        break;
                    case MiniMap.DoorLocation.East:
                        doorLocation = new Rectangle(drawLocation.Right, roomCenter.Y - (DoorSize / 2) + 2, BorderOffset, DoorSize);
                        break;
                    default:
                        doorLocation = new Rectangle(drawLocation.Left, roomCenter.Y - (DoorSize / 2) + 2, BorderOffset, DoorSize);
                        break;
                }
                LoZGame.Instance.SpriteBatch.Draw(this.MapSprite, doorLocation, this.MapSourceRectangle, MapColor, 0.0f, Vector2.Zero, SpriteEffects.None, MapLayer);
            }
        }
    }
}
