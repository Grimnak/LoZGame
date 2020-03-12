namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Item pickup state for player.
    /// </summary>
    public class PickupItemState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly IItem item;
        private readonly ISprite sprite;
        private int lockoutTimer = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="PickupItemState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of player.</param>
        /// <param name="item">Item that player picked up.</param>
        public PickupItemState(IPlayer playerInstance, IItem item)
        {
            this.player = playerInstance;
            this.item = item;
            this.lockoutTimer = item.PickUpItemTime;
            this.sprite = this.CreateCorrectSprite();
            if (item is Triforce)
            {
                LoZGame.Instance.GameState = "Win";
            }
        }

        /// <inheritdoc/>
        public void Idle()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.CurrentDirection = "Down";
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
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new UseItemState(this.player, waitTime);
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
            if (this.lockoutTimer > 0)
            {
                this.lockoutTimer--;
                if (this.lockoutTimer == 0)
                {
                    item.Expired = true;
                    if (this.item is Triforce)
                    {
                        LoZGame.Instance.Reset();
                    }
                }
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
            if (item is Triforce)
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkPickupTriforce(this.player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkPickupItem(this.player.CurrentColor);
            }
        }
    }
}