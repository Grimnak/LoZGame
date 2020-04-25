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
            player = playerInstance;
            lockoutTimer = waitTime; // wait period
            sprite = CreateCorrectSprite();
            sprite.CurrentFrame = GameData.Instance.PlayerConstants.MaximumFrames;
            player.Physics.MovementVelocity = Vector2.Zero;
            sprite.SetFrame(GameData.Instance.PlayerConstants.MaximumFrames);
        }

        /// <inheritdoc/>
        public void Idle()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new IdleState(player);
            }
        }

        /// <inheritdoc/>
        public void MoveUp()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new MoveUpState(player);
            }
        }

        /// <inheritdoc/>
        public void MoveDown()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new MoveDownState(player);
            }
        }

        /// <inheritdoc/>
        public void MoveLeft()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new MoveLeftState(player);
            }
        }

        /// <inheritdoc/>
        public void MoveRight()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new MoveRightState(player);
            }
        }

        /// <inheritdoc/>
        public void Attack()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new AttackState(player);
            }
        }

        /// <inheritdoc/>
        public void Die()
        {
            player.State = new DieState(player);
        }

        /// <inheritdoc/>
        public void PickupItem(IItem item)
        {
            if (lockoutTimer <= 0)
            {
                player.State = new PickupItemState(player, item);
            }
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
        }

        /// <inheritdoc/>
        public void Update()
        {
            if (lockoutTimer > 0)
            {
                lockoutTimer--;
            }
        }

        /// <inheritdoc/>
        public void Stun(int stunTime)
        {
            player.State = new StunnedState(player, player.State, stunTime);
        }

        /// <inheritdoc/>
        public void Draw()
        {
            sprite.Draw(player.Physics.Location, player.CurrentTint, player.Physics.Depth);
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
    }
}