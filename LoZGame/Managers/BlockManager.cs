namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class BlockManager
    {
        private List<IBlock> blocks;

        public List<IBlock> BlockList { get { return blocks; } }

        public BlockManager()
        {
            this.blocks = new List<IBlock>();
        }

        public void Add(IBlock block)
        {
            blocks.Add(block);
        }

        public void Clear()
        {
            blocks.Clear();
        }

        public void Update()
        {
            foreach (IBlock block in blocks)
            {
                block.Update();
            }
        }

        public void Draw()
        {
            foreach (IBlock block in blocks)
            {
                block.Draw();
            }
        }
    }
}