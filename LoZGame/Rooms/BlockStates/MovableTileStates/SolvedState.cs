using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class SolvedState : IMovableBlockState
    {
        private MovableBlock Block;
        private ISprite sprite;

        public SolvedState(MovableBlock block)
        {
            Block = block;
            sprite = DungeonSpriteFactory.Instance.MovableTile();
        }

        public void Draw()
        {
            sprite.Draw(Block.Physics.Location, LoZGame.Instance.DungeonTint, Block.Physics.Depth);
        }

        public void Update()
        {
        }
    }
}
