using Microsoft.Xna.Framework.Audio;

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
            SoundFactory.Instance.PlaySwordSlash();
            this.player = playerInstance;
            this.lockoutTimer = GameData.Instance.PlayerConstants.LockoutWaitTime; // wait period
            this.sprite = this.CreateCorrectSprite();
            this.sprite.SetFrame(GameData.Instance.PlayerConstants.MaximumFrames);
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
        public void Stun(int stunTime)
        {
            this.player.State = new StunnedState(this.player, this.player.State, stunTime);
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
    }
}