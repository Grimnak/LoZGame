namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;

    public partial class Stair : IBlock
    {
        private Point linkedRoom;
        private Point linkSpawn;
        private ISprite sprite;

        public Physics Physics { get; set; }

        public Point PointLinkedRoom => linkedRoom;

        public Point LinkSpawn => linkSpawn;

        public Stair(Vector2 location, Point room, Point spawn)
        {
            linkedRoom = room;
            linkSpawn = spawn;
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