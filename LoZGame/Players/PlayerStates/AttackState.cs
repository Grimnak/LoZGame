namespace LoZClone
{
    using Microsoft.Xna.Framework;
    /// <summary>
    /// Attack state for player.
    /// </summary>
    public class AttackState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private int lockoutTimer = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttackState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of the player.</param>
        public AttackState(IPlayer playerInstance)
        {
            this.player = playerInstance;
            this.lockoutTimer = 15; // wait period
            this.sprite = this.CreateCorrectSprite();
            this.sprite.SetFrame(2);
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
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.Physics.Location, this.player.CurrentTint, this.player.Physics.Depth);
        }

        /// <summary>
        /// Creates the correct sprite.
        /// </summary>
        /// <returns>The correct sprite to draw.</returns>
        private ISprite CreateCorrectSprite()
        {
            if (this.player.CurrentDirection.Equals("Up"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkAttackUp(this.player.CurrentColor, this.player.CurrentWeapon);
            }
            else if (this.player.CurrentDirection.Equals("Down"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkAttackDown(this.player.CurrentColor, this.player.CurrentWeapon);
            }
            else if (this.player.CurrentDirection.Equals("Left"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkAttackLeft(this.player.CurrentColor, this.player.CurrentWeapon);
            }
            else
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkAttackRight(this.player.CurrentColor, this.player.CurrentWeapon);
            }
        }
    }
}