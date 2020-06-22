﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Left moving state for player.
    /// </summary>
    public class MoveLeftState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveLeftState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of player.</param>
        public MoveLeftState(IPlayer playerInstance)
        {
            player = playerInstance;
            player.Physics.CurrentDirection = Physics.Direction.West;
            sprite = CreateCorrectSprite();
            player.Physics.MovementVelocity = new Vector2(-1 * player.MoveSpeed, 0);
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
            player.State = new MoveDownState(player);
        }

        /// <inheritdoc/>
        public void MoveLeft()
        {
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
            if (player.Inventory.HasMagicShield)
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkShieldLeft(player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkLeft(player.CurrentColor);
            }
        }
    }
}