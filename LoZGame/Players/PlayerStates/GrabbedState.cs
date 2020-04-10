namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Immobilized state for player when Wall Master has control of him.
    /// </summary>
    public class GrabbedState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly IEnemy wallMaster;
        private readonly ISprite sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="GrabbedState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of the player.</param>
        /// <param name="wallMaster">Instance of the colliding Wall Master.</param>
        public GrabbedState(IPlayer playerInstance, WallMaster wallMaster)
        {
            this.player = playerInstance;
            this.wallMaster = wallMaster;
            this.sprite = this.CreateCorrectSprite();
            Point offset = ((wallMaster.Physics.Bounds.Size - player.Physics.Bounds.Size).ToVector2() / 2).ToPoint();
            this.player.Physics.Bounds = new Rectangle(wallMaster.Physics.Bounds.Location + offset, player.Physics.Bounds.Size);
            this.player.Physics.SetLocation();
        }

        /// <inheritdoc/>
        public void Idle()
        {
        }

        /// <inheritdoc/>
        public void MoveUp()
        {
        }

        /// <inheritdoc/>
        public void MoveDown()
        {
        }

        /// <inheritdoc/>
        public void MoveLeft()
        {
        }

        /// <inheritdoc/>
        public void MoveRight()
        {
        }

        /// <inheritdoc/>
        public void Attack()
        {
        }

        /// <inheritdoc/>
        public void Die()
        {
        }

        /// <inheritdoc/>
        public void PickupItem(IItem item)
        {
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
        }

        /// <inheritdoc/>
        public void Stun(int stunTime)
        {
        }

        /// <inheritdoc/>
        public void Update()
        {
            player.Physics.MovementVelocity = wallMaster.Physics.MovementVelocity;
            if (this.player.Physics.Location.X < 0)
            {
                this.wallMaster.CurrentState = new RightMovingWallMasterState((WallMaster)this.wallMaster);
                this.wallMaster.Physics.Bounds = new Rectangle(new Point(this.wallMaster.Physics.Bounds.Location.X + (BlockSpriteFactory.Instance.TileWidth * 3), this.wallMaster.Physics.Bounds.Location.Y), this.wallMaster.Physics.Bounds.Size);
                this.player.Physics.StopVelocity();
                this.player.State = new IdleState(this.player);
                this.player.Physics.Location = new Vector2(
                    (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    (float)(BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 6)));
                this.player.Physics.Bounds = new Rectangle((int)this.player.Physics.Location.X, (int)this.player.Physics.Location.Y, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
                LoZGame.Instance.Dungeon.CurrentRoomX = 2;
                LoZGame.Instance.Dungeon.CurrentRoomY = 5;
                LoZGame.Instance.Dungeon.LoadNewRoom();
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.Physics.Location, this.player.CurrentTint, this.player.Physics.Depth);
        }

        private ISprite CreateCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkIdleUp(this.player.CurrentColor);
        }
    }
}