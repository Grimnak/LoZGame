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
        public void Update()
        {
            wallMaster.Physics.Location = player.Physics.Location;
            player.Physics.Velocity = wallMaster.Physics.Velocity;
            this.player.Physics.Move();
            if (this.player.Physics.Location.X < 0)
            {
                LoZGame.Instance.Dungeon.Reset();
                this.player.Physics.Location = new Vector2(
                    (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    (float)(BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 6)));
                this.player.Physics.ResetVelocity();
                this.player.State = new IdleState(this.player);
            }
            this.sprite.Update();
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.Physics.Location, this.player.CurrentTint);
        }

        private ISprite CreateCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkIdleUp(this.player.CurrentColor);
        }
    }
}