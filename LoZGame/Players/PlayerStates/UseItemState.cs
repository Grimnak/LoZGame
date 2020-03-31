namespace LoZClone
{
    using Microsoft.Xna.Framework;
    /// <summary>
    /// Item using state for player.
    /// </summary>
    public class UseItemState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private int lockoutTimer = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="UseItemState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of player.</param>
        /// <param name="waitTime">Time for player to wait.</param>
        public UseItemState(IPlayer playerInstance, int waitTime)
        {
            this.player = playerInstance;
            this.lockoutTimer = waitTime; // wait period
            this.sprite = this.CreateCorrectSprite();
            this.sprite.CurrentFrame = 2;
            this.player.Physics.MovementVelocity = Vector2.Zero;
        }

        /// <inheritdoc/>
        public void Idle()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new IdleState(this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveUp()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveUpState(this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveDown()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveDownState(this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveLeft()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveLeftState(this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveRight()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveRightState(this.player);
            }
        }

        /// <inheritdoc/>
        public void Attack()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new AttackState(this.player);
            }
        }

        /// <inheritdoc/>
        public void Die()
        {
            this.player.State = new DieState(this.player);
        }

        /// <inheritdoc/>
        public void PickupItem(IItem item)
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new PickupItemState(this.player, item);
            }
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
        }

        /// <inheritdoc/>
        public void Update()
        {
            if (this.lockoutTimer > 0)
            {
                this.lockoutTimer--;
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.Physics.Location, this.player.CurrentTint, this.player.Physics.Depth);
        }

        private ISprite CreateCorrectSprite()
        {
            if (this.player.Physics.CurrentDirection == Physics.Direction.North)
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkUseItemUp(this.player.CurrentColor);
            }
            else if (this.player.Physics.CurrentDirection == Physics.Direction.South)
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkUseItemDown(this.player.CurrentColor);
            }
            else if (this.player.Physics.CurrentDirection == Physics.Direction.West)
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkUseItemLeft(this.player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkUseItemRight(this.player.CurrentColor);
            }
        }
    }
}