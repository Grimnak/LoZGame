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
        private int timeout = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="GrabbedState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of the player.</param>
        /// <param name="wallMaster">Instance of the colliding Wall Master.</param>
        public GrabbedState(IPlayer playerInstance, WallMaster wallMaster)
        {
            player = playerInstance;
            this.wallMaster = wallMaster;
            sprite = CreateCorrectSprite();
            Point offset = ((wallMaster.Physics.Bounds.Size - player.Physics.Bounds.Size).ToVector2() / 2).ToPoint();
            player.Physics.Bounds = new Rectangle(wallMaster.Physics.Bounds.Location + offset, player.Physics.Bounds.Size);
            player.Physics.SetLocation();
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
            // If the Wall Master dies while grabbing the player, release the player.
            if (wallMaster.IsDead)
            {
                player.State = new IdleState(player);
            }

            // If the Wall Master finishes grabbing the player, travel to the edge of the screen and drop the player at the dungeon entrance.
            if (((WallMaster)wallMaster).Timer > timeout)
            {
                ((WallMaster)wallMaster).Physics.MovementVelocity = new Vector2(-2, 0);
                player.Physics.MovementVelocity = wallMaster.Physics.MovementVelocity;
                player.DisarmedTimer = LoZGame.Instance.UpdateSpeed * 3;
                if (player.Physics.Location.X < 0)
                {
                    ((WallMaster)wallMaster).Expired = true;
                    player.DisarmedTimer = 0;
                    player.Physics.StopVelocity();
                    player.State = new IdleState(player);
                    player.Physics.Location = new Vector2(
                        (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                        (float)(BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 6)));
                    player.Physics.Bounds = new Rectangle((int)player.Physics.Location.X, (int)player.Physics.Location.Y, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
                    LoZGame.Instance.Dungeon.CurrentRoomX = LoZGame.Instance.Dungeon.StartRoomX;
                    LoZGame.Instance.Dungeon.CurrentRoomY = LoZGame.Instance.Dungeon.StartRoomY;
                    LoZGame.Instance.Dungeon.LoadNewRoom();
                }
            }
            else
            {
                player.Physics.CurrentDirection = Physics.Direction.North;
                wallMaster.Physics.StopMovement();
                player.Physics.StopMovement();
                ((WallMaster)wallMaster).Timer++;
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            sprite.Draw(player.Physics.Location, player.CurrentTint, player.Physics.Depth);
        }

        private ISprite CreateCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkUp(player.CurrentColor);
        }
    }
}