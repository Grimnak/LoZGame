namespace LoZClone
{
    using System;
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
            if (block is FireSprite);
           
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
                if (block is Tile)
                {
                    block.Draw();
                }
            }

            foreach (IBlock block in blocks)
            {
                if (block is BlockTile || block is MovableTile)
                {
                    block.Draw();
                }
            }
        }
    }
}