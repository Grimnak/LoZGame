using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CrossableTile : IBlock
    {
        private const string WaterTile = "water_tile";
        private const string Lava5 = "lava5";

        private enum LiquidType
        {
            Water,
            Lava
        }

        private LiquidType type;

        private ISprite sprite;
        private Color spriteTint = LoZGame.Instance.DefaultTint;
        private Rectangle bounds;
        private BlockCollisionHandler blockCollisionHandler;

        public List<MovableTile.InvalidDirection> InvalidDirections { get { return null; } }

        public Physics Physics { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockTile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public CrossableTile(Vector2 location, string name)
        {
            this.blockCollisionHandler = new BlockCollisionHandler(this);
            this.Physics = new Physics(location);
            this.spriteTint = Color.Gray;
            this.sprite = this.CreateCorrectSprite(name);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)BlockSpriteFactory.Instance.TileWidth, (int)BlockSpriteFactory.Instance.TileHeight);
            this.Physics.Depth = GameData.Instance.RoomConstants.BlockTileDepth;
        }

        public ISprite CreateCorrectSprite(string name)
        {
            switch (name)
            {
                case WaterTile:
                    return BlockSpriteFactory.Instance.WaterTile();
                case Lava5:
                    return BlockSpriteFactory.Instance.Lava5();
                default:
                    return BlockSpriteFactory.Instance.WaterTile();
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, spriteTint, this.Physics.Depth);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {


            // EDIT THIS


            if (otherCollider is IPlayer)
            {
                this.blockCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IEnemy)
            {
                this.blockCollisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }
    }
}
