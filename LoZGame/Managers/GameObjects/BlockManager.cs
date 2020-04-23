namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class BlockManager : IManager
    {
        private List<IBlock> blocks;

        public List<IBlock> BlockList { get { return blocks; } }

        public BlockManager()
        {
            blocks = new List<IBlock>();
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
                if (block is Tile || block is Stairs)
                {
                    block.Draw();
                }
            }

            foreach (IBlock block in blocks)
            {
                if (block is BlockTile || block is MovableTile || block is CrossableTile)
                {
                    block.Draw();
                }
            }
        }
    }
}