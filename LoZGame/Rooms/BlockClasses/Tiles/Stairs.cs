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
        private bool isTransparent;

        public Physics Physics { get; set; }

        public Point PointLinkedRoom => linkedRoom;

        public Point LinkSpawn => linkSpawn;

        public Stairs(Vector2 location, Point room, Point spawn)
        {
            linkedRoom = room;
            linkSpawn = spawn;
            isTransparent = true;
            Physics = new Physics(location);
            Physics.Bounds = new Rectangle(location.ToPoint(), new Point((int)BlockSpriteFactory.Instance.TileWidth, BlockSpriteFactory.Instance.TileHeight));
            Physics.SetDepth();
            sprite = DungeonSpriteFactory.Instance.Stairs();
        }

        public bool IsTransparent { get { return false; } set { } }

        public List<MovableTile.InvalidDirection> InvalidDirections { get { return null; } }

        public void Update()
        {
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint, this.Physics.Depth);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
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
    }
}