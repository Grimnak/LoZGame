using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace LoZClone
{
    public class DungeonMapSprite : ISprite
    {
        private SpriteData data;

        public DungeonMapSprite(SpriteData data)
        {
            this.data = data;
        }

        public int TotalFrames => throw new NotImplementedException();

        public int CurrentFrame { get; set; }
        public int FrameDelay { get; set; }

        public void Draw(Vector2 location, Color spriteTint, float depth)
        {

        }

        public void Draw(Vector2 location, Color tint, float rotation, SpriteEffects effect, float depth)
        {

        }

        public void NextFrame()
        {
        }

        public void SetFrame(int frame)
        {
        }

        public void Update()
        {

        }
    }
}
