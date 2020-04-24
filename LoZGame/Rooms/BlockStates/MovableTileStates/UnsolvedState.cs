using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class UnsolvedState : IMovableBlockState
    {
        private MovableBlock Block;
        bool moved = false;
        private ISprite sprite;

        public UnsolvedState(MovableBlock block)
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
            HandlePush();
            SolveDoors();
            SolveStairs();
            if (!moved)
            {
                Block.Physics.SetDepth();
            }
        }

        private void HandlePush()
        {
            if (Block.Physics.MovementVelocity.X != 0)
            {
                if (Math.Abs(Block.Physics.Location.X - Block.OriginalLocation.X) <= Block.Physics.Bounds.Width && Block.Physics.Location.Y == Block.OriginalLocation.Y)
                {
                    Block.Physics.StopMovementY();
                    Block.Physics.Move();
                    Block.Physics.Accelerate();
                }
                else
                {
                    Block.CurrentState = new SolvedState(Block);
                    SoundFactory.Instance.PlaySolved();
                }
            }
            else if (Block.Physics.MovementVelocity.Y != 0)
            {
                if (Math.Abs(Block.Physics.Location.Y - Block.OriginalLocation.Y) <= Block.Physics.Bounds.Height && Block.Physics.Location.X == Block.OriginalLocation.X)
                {
                    Block.Physics.StopMovementX();
                    Block.Physics.Move();
                    Block.Physics.Accelerate();
                }
                else
                {
                    Block.CurrentState = new SolvedState(Block);
                    SoundFactory.Instance.PlaySolved();
                }
            }
        }

        private void SolveDoors()
        {
            if (Math.Abs(Block.Physics.Location.X - Block.OriginalLocation.X) >= Block.Physics.Bounds.Width || Math.Abs(Block.Physics.Location.Y - Block.OriginalLocation.Y) >= Block.Physics.Bounds.Height)
            {
                foreach (Door door in LoZGame.Instance.GameObjects.Doors.DoorList)
                {
                    if (door.State is PuzzleDoorState)
                    {
                        ((PuzzleDoorState)door.State).Solve();
                    }
                }
            }
        }

        private void SolveStairs()
        {
            if (Math.Abs(Block.Physics.Location.X - Block.OriginalLocation.X) >= Block.Physics.Bounds.Width || Math.Abs(Block.Physics.Location.Y - Block.OriginalLocation.Y) >= Block.Physics.Bounds.Height)
            {
                foreach (IBlock block in LoZGame.Instance.GameObjects.Blocks.BlockList)
                {
                    if (block is Stairs)
                    {
                        ((Stairs)block).Solve();
                    }
                }
            }
        }
    }
}
