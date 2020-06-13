namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;

    public class Stairs : IBlock
    {
        private Point linkedRoom;
        private Point linkSpawn;
        private ISprite sprite;
        private Color spriteTint;
        private bool isHidden;
        private static int lockoutTimer;

        public Physics Physics { get; set; }

        public Point PointLinkedRoom => linkedRoom;

        public Point LinkSpawn => linkSpawn;

        public Stairs(Vector2 location, Point room, Point spawn, bool hidden)
        {
            linkedRoom = room;
            linkSpawn = spawn;
            isHidden = hidden;
            Physics = new Physics(location);
            Physics.Bounds = new Rectangle(location.ToPoint(), new Point((int)BlockSpriteFactory.Instance.TileWidth, BlockSpriteFactory.Instance.TileHeight));
            Physics.SetDepth();
            sprite = DungeonSpriteFactory.Instance.Stairs();
            spriteTint = LoZGame.Instance.DungeonTint;
            lockoutTimer = 0;
        }

        public bool IsTransparent { get { return false; } set { } }

        public List<MovableBlock.InvalidDirection> InvalidDirections { get { return null; } }

        public void Update()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoom.IsBasement)
            {
                lockoutTimer = 0;
            }

            if (lockoutTimer > 0)
            {
                lockoutTimer--;
            }

            if (!(LoZGame.Instance.Dungeon is null))
            {
                spriteTint = LoZGame.Instance.Dungeon.CurrentRoom.CurrentRoomTint;
            }
        }

        public void Draw()
        {
            if (!isHidden)
            {
                this.sprite.Draw(this.Physics.Location, spriteTint, this.Physics.Depth);
            }
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer && !isHidden && lockoutTimer <= 0)
            {
                lockoutTimer = LoZGame.Instance.UpdateSpeed * 2;
                SoundFactory.Instance.PlayClimbStairs();
                LoZGame.Instance.Dungeon.CurrentRoomX = this.PointLinkedRoom.X;
                LoZGame.Instance.Dungeon.CurrentRoomY = this.PointLinkedRoom.Y;
                Point newLoc;
                if (LoZGame.Instance.Dungeon.CurrentRoom.IsBasement)
                {
                    newLoc = new Point((int)((this.LinkSpawn.X * BlockSpriteFactory.Instance.TileWidth) + CollisionConstants.PlayerLocationXOffset), (this.LinkSpawn.Y * BlockSpriteFactory.Instance.TileHeight) + LoZGame.Instance.InventoryOffset + CollisionConstants.PlayerLocationYOffset);
                }
                else
                {
                    newLoc = new Point((int)((this.LinkSpawn.X * BlockSpriteFactory.Instance.TileWidth) + BlockSpriteFactory.Instance.HorizontalOffset), (this.LinkSpawn.Y * BlockSpriteFactory.Instance.TileHeight) + LoZGame.Instance.InventoryOffset + BlockSpriteFactory.Instance.VerticalOffset);
                }

                otherCollider.Physics.Bounds = new Rectangle(newLoc, otherCollider.Physics.Bounds.Size);
                otherCollider.Physics.SetLocation();
                LoZGame.Instance.Dungeon.LoadNewRoom();
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public ISprite CreateCorrectSprite(string name)
        {
            return DungeonSpriteFactory.Instance.Stairs();
        }

        public void Solve()
        {
            isHidden = false;
        }

        public bool IsHidden { get { return isHidden; } set { isHidden = value; } }
    }
}