namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class BlockManager
    {
        private List<IBlock> blockList;
        public Vector2 Location;

        public BlockManager()
        {
            this.blockList = new List<IBlock>();
        }

        public void Add(IBlock block)
        {
            blockList.Add(block);
        }

        public void Clear()
        {
            blockList.Clear();
        }

        public void Update()
        {
            foreach (IBlock block in blockList)
            {
                block.Update();
            }
        }

        public void Draw()
        {
            foreach (IBlock block in blockList)
            {
                block.Draw();
            }
        }
    }
}