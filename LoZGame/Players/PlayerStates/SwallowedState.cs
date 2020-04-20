namespace LoZClone
{
    using System;
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
            this.player = playerInstance;
            this.likelike = likelike;
            this.player.Physics.Depth = 0.5f;
            this.sprite = this.CreateCorrectSprite();
            Point offset = ((likelike.Physics.Bounds.Size - player.Physics.Bounds.Size).ToVector2() / 2).ToPoint();
            this.player.Physics.Bounds = new Rectangle(likelike.Physics.Bounds.Location + offset, player.Physics.Bounds.Size);
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
            this.likelike.Physics.StopMovement();
            this.player.Physics.StopMovement();
            (likelike as Likelike).Timer++;
            if ((likelike as Likelike).Timer > this.timeout)
            {
                this.player.State = new IdleState(this.player);
                if (this.likelike.Health.CurrentHealth >= 0)
                {
                    this.likelike.UpdateState();
                }
                this.likelike.Physics.Bounds = new Rectangle(
                    new Point(this.likelike.Physics.Bounds.Location.X, this.likelike.Physics.Bounds.Location.Y), this.likelike.Physics.Bounds.Size);
                this.player.Physics.Location = new Vector2(this.player.Physics.Location.X, this.player.Physics.Location.Y);
                this.player.Physics.Bounds = new Rectangle((int)this.player.Physics.Location.X, (int)this.player.Physics.Location.Y, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
                (likelike as Likelike).Timer = 0;
                this.player.TakeDamage(likelike.Damage);
            }
        }

        private ISprite CreateCorrectSprite()
        {
            if (this.player.Physics.CurrentDirection == Physics.Direction.North)
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkUp(this.player.CurrentColor);
            }
            else if (this.player.Physics.CurrentDirection == Physics.Direction.South)
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkDown(this.player.CurrentColor);
            }
            else if (this.player.Physics.CurrentDirection == Physics.Direction.West)
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkLeft(this.player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkRight(this.player.CurrentColor);
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.Physics.Location, this.player.CurrentTint, this.player.Physics.Depth);
        }
    }
}