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
            this.player.Physics.MovementVelocity = Vector2.Zero;
            if (item is Triforce)
            {
                this.sprite.SetFrame(2);
                LoZGame.Instance.GameState.WinGame();
            }
            else if (item is Key)
            {
                player.Inventory.GainKey();
            }
            else if (item is Bow)
            {
                player.Inventory.HasBow = true;
            }
            else if (item is Boomerang)
            {
                player.Inventory.HasBoomerang = true;
            }
            else if (item is MagicBoomerang)
            {
                player.Inventory.HasMagicBoomerang = true;
            }
            else if (item is SilverArrow)
            {
                player.Inventory.HasSilverArrow = true;
            }
            else if (item is RedCandle)
            {
                player.Inventory.HasRedFlame = true;
            }
            else if (item is BlueCandle)
            {
                player.Inventory.HasBlueFlame = true;
            }
        }

        /// <inheritdoc/>
        public void Idle()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.Physics.CurrentDirection = Physics.Direction.South;
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
                }
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.Physics.Location, this.player.CurrentTint, this.player.Physics.Depth);
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