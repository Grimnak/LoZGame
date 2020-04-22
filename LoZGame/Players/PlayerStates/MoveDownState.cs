namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class MoveDownState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveDownState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of player.</param>
        public MoveDownState(IPlayer playerInstance)
        {
            player = playerInstance;
            player.Physics.CurrentDirection = Physics.Direction.South;
            sprite = CreateCorrectSprite();
            player.Physics.MovementVelocity = new Vector2(0, player.MoveSpeed);
        }

        /// <inheritdoc/>
        public void Idle()
        {
            player.State = new IdleState(player);
        }

        /// <inheritdoc/>
        public void MoveUp()
        {
            player.State = new MoveUpState(player);
        }

        /// <inheritdoc/>
        public void MoveDown()
        {
        }

        /// <inheritdoc/>
        public void MoveLeft()
        {
            player.State = new MoveLeftState(player);
        }

        /// <inheritdoc/>
        public void MoveRight()
        {
            player.State = new MoveRightState(player);
        }

        /// <inheritdoc/>
        public void Attack()
        {
            player.State = new AttackState(player);
        }

        /// <inheritdoc/>
        public void Die()
        {
            player.State = new DieState(player);
        }

        /// <inheritdoc/>
        public void PickupItem(IItem item)
        {
            player.State = new PickupItemState(player, item);
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
            player.State = new UseItemState(player, waitTime);
        }

        /// <inheritdoc/>
        public void Stun(int stunTime)
        {
            player.State = new StunnedState(player, player.State, stunTime);
        }

        /// <inheritdoc/>
        public void Update()
        {
            sprite.Update();
            if (sprite.CurrentFrame >= GameData.Instance.PlayerConstants.MaximumFrames)
            {
                sprite.SetFrame(0);
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            sprite.Draw(player.Physics.Location, player.CurrentTint, player.Physics.Depth);
        }

        private ISprite CreateCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkDown(player.CurrentColor);
        }
    }
}