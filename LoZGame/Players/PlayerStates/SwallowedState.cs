namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Immobilized state for player when Wall Master has control of him.
    /// </summary>
    public class SwallowedState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly IEnemy likelike;
        private readonly ISprite sprite;
        private int timeout = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwallowedState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of the player.</param>
        /// <param name="likelike">Instance of the colliding Wall Master.</param>
        public SwallowedState(IPlayer playerInstance, Likelike likelike)
        {
            player = playerInstance;
            this.likelike = likelike;
            player.Physics.Depth = 0.5f;
            sprite = CreateCorrectSprite();
            Point offset = ((likelike.Physics.Bounds.Size - player.Physics.Bounds.Size).ToVector2() / 2).ToPoint();
            player.Physics.Bounds = new Rectangle(likelike.Physics.Bounds.Location + offset, player.Physics.Bounds.Size);
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
            likelike.Physics.StopMovement();
            player.Physics.StopMovement();
            ((Likelike)likelike).Timer++;

            // If the LikeLike dies while swallowing the player, release the player.
            if (likelike.IsDead)
            {
                player.State = new IdleState(player);
            }

            // If the LikeLike finishes swallowing the player, deal the corresponding damage before releasing the player.
            if (((Likelike)likelike).Timer > timeout)
            {
                player.State = new IdleState(player);
                if (likelike.Health.CurrentHealth > 0)
                {
                    likelike.UpdateState();
                }
                likelike.Physics.Bounds = new Rectangle(
                    new Point(likelike.Physics.Bounds.Location.X, likelike.Physics.Bounds.Location.Y), likelike.Physics.Bounds.Size);
                player.Physics.Location = new Vector2(player.Physics.Location.X, player.Physics.Location.Y);
                player.Physics.Bounds = new Rectangle((int)player.Physics.Location.X, (int)player.Physics.Location.Y, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
                ((Likelike)likelike).Timer = 0;
                player.TakeDamage(likelike.Damage);
            }
        }

        private ISprite CreateCorrectSprite()
        {
            if (player.Physics.CurrentDirection == Physics.Direction.North)
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkUp(player.CurrentColor);
            }
            else if (player.Physics.CurrentDirection == Physics.Direction.South)
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkDown(player.CurrentColor);
            }
            else if (player.Physics.CurrentDirection == Physics.Direction.West)
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkLeft(player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkRight(player.CurrentColor);
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            sprite.Draw(player.Physics.Location, player.CurrentTint, player.Physics.Depth);
        }
    }
}