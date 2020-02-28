namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class BlockManager
    {
        private List<IBlock> blockList;
        public IBlock CurrentBlock;
        public Vector2 Location;

        private static readonly BlockManager instance = new BlockManager();

        public static BlockManager Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockManager()
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