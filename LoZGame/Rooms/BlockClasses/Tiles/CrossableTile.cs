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

        public bool IsTransparent { get { return this.isTransparent; } set { this.isTransparent = value; } }

        public List<MovableTile.InvalidDirection> InvalidDirections { get { return null; } }

        public Physics Physics { get; set; }

        public bool BeingCrossed { get { return this.playerCrossing; } }

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
            this.isTransparent = true;
            this.sprite = this.CreateCorrectSprite(name);
            this.crossingSprite = this.CreateCorrectCrossingSprite(name);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)BlockSpriteFactory.Instance.TileWidth, (int)BlockSpriteFactory.Instance.TileHeight);
            this.Physics.Depth = GameData.Instance.RoomConstants.BlockTileDepth;
            this.ladderTime = 30;
            this.playerCrossing = false;
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
            if (this.playerCrossing)
            {
                this.crossingSprite.Draw(this.Physics.Location, spriteTint, this.Physics.Depth);
            }
            else
            {
                this.sprite.Draw(this.Physics.Location, spriteTint, this.Physics.Depth);
            }
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.blockCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
                if (((IPlayer)otherCollider).Inventory.HasLadder && (!((IPlayer)otherCollider).Inventory.LadderInUse || this.playerCrossing))
                {
                    this.ladderTime = 0;
                }
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
            if (this.ladderTime < maxLadderTime)
            {
                this.ladderTime++;
                this.playerCrossing = true;
                LoZGame.Instance.Players[0].Inventory.LadderInUse = true;
            }
            else
            {
                if (this.playerCrossing == true)
                {
                    LoZGame.Instance.Players[0].Inventory.LadderInUse = false;
                }
                this.playerCrossing = false;
            }

            this.sprite.Update();
        }
    }
}
