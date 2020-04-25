namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Idle state for player.
    /// </summary>
    public class IdleState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdleState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of player.</param>
        public IdleState(IPlayer playerInstance)
        {
            player = playerInstance;
            sprite = CreateCorrectSprite();
            player.Physics.MovementVelocity = Vector2.Zero;
        }

        /// <inheritdoc/>
        public void Idle()
        {
        }

        /// <inheritdoc/>
        public void MoveUp()
        {
            player.State = new MoveUpState(player);
        }

        /// <inheritdoc/>
        public void MoveDown()
        {
            player.State = new MoveDownState(player);
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