namespace LoZGame
{
    /// <summary>
    /// Attack state for player.
    /// </summary>
    public class AttackState : IPlayerState
    {
        private readonly LoZGame game;
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private int lockoutTimer = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttackState"/> class.
        /// </summary>
        /// <param name="game">Current game.</param>
        /// <param name="playerInstance">Instance of the player.</param>
        public AttackState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = playerInstance;
            this.lockoutTimer = 15; // wait period
            this.sprite = this.CreateCorrectSprite();
        }

        /// <inheritdoc/>
        public void Idle()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new IdleState(this.game, this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveUp()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveUpState(this.game, this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveDown()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveDownState(this.game, this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveLeft()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveLeftState(this.game, this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveRight()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveRightState(this.game, this.player);
            }
        }

        /// <inheritdoc/>
        public void Attack()
        {
        }

        /// <inheritdoc/>
        public void Die()
        {
            this.player.State = new DieState(this.game, this.player);
        }

        /// <inheritdoc/>
        public void PickupItem(int itemTime)
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new PickupItemState(this.game, this.player, itemTime);
            }
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new UseItemState(this.game, this.player, waitTime);
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
            if (this.lockoutTimer > 0)
            {
                this.lockoutTimer--;
            }

            this.sprite.Update();
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.game.SpriteBatch, this.player.CurrentLocation, this.player.CurrentTint);
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