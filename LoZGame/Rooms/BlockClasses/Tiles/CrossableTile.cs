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

        private const int maxLadderTime = 2;
        private int ladderTime;
        private bool playerCrossing;
        private ISprite sprite;
        private ISprite crossingSprite;
        private Color spriteTint = LoZGame.Instance.DefaultTint;
        private Rectangle bounds;
        private BlockCollisionHandler blockCollisionHandler;
        private bool isTransparent;

        public bool IsTransparent { get { return isTransparent; } set { isTransparent = value; } }

        public List<MovableBlock.InvalidDirection> InvalidDirections { get { return null; } }

        public Physics Physics { get; set; }

        public bool BeingCrossed { get { return playerCrossing; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockTile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public CrossableTile(Vector2 location, string name)
        {
            blockCollisionHandler = new BlockCollisionHandler(this);
            Physics = new Physics(location);
            spriteTint = Color.Gray;
            isTransparent = true;
            sprite = CreateCorrectSprite(name);
            crossingSprite = CreateCorrectCrossingSprite(name);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)BlockSpriteFactory.Instance.TileWidth, (int)BlockSpriteFactory.Instance.TileHeight);
            Physics.Depth = GameData.Instance.RoomConstants.BlockTileDepth;
            ladderTime = 30;
            playerCrossing = false;
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

        public ISprite CreateCorrectCrossingSprite(string name)
        {
            switch (name)
            {
                case WaterTile:
                    return BlockSpriteFactory.Instance.WaterTileLadder();
                case Lava5:
                    return BlockSpriteFactory.Instance.LavaTileLadder();
                default:
                    return BlockSpriteFactory.Instance.WaterTileLadder();
            }
        }

        public void Draw()
        {
            if (playerCrossing)
            {
                crossingSprite.Draw(Physics.Location, spriteTint, Physics.Depth);
            }
            else
            {
                sprite.Draw(Physics.Location, spriteTint, Physics.Depth);
            }
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                blockCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
                if (((IPlayer)otherCollider).Inventory.HasLadder && (!((IPlayer)otherCollider).Inventory.LadderInUse || playerCrossing))
                {
                    ladderTime = 0;
                }
            }
            else if (otherCollider is IEnemy)
            {
                blockCollisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void Update()
        {
            if (ladderTime < maxLadderTime)
            {
                ladderTime++;
                playerCrossing = true;
                LoZGame.Instance.Players[0].Inventory.LadderInUse = true;
            }
            else
            {
                if (playerCrossing == true)
                {
                    LoZGame.Instance.Players[0].Inventory.LadderInUse = false;
                }
                playerCrossing = false;
            }
            sprite.Update();
        }
    }
}
