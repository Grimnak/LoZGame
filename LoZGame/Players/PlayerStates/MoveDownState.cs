namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

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
            this.player = playerInstance;
            this.player.Physics.CurrentDirection = Physics.Direction.South;
            this.sprite = this.CreateCorrectSprite();
            this.player.Physics.MovementVelocity = new Vector2(0, this.player.MoveSpeed);
        }

        /// <inheritdoc/>
        public void Idle()
        {
            this.player.State = new IdleState(this.player);
        }

        /// <inheritdoc/>
        public void MoveUp()
        {
            this.player.State = new MoveUpState(this.player);
        }

        /// <inheritdoc/>
        public void MoveDown()
        {
        }

        /// <inheritdoc/>
        public void MoveLeft()
        {
            this.player.State = new MoveLeftState(this.player);
        }

        /// <inheritdoc/>
        public void MoveRight()
        {
            this.player.State = new MoveRightState(this.player);
        }

        /// <inheritdoc/>
        public void Attack()
        {
            this.player.State = new AttackState(this.player);
        }

        /// <inheritdoc/>
        public void Die()
        {
            this.player.State = new DieState(this.player);
        }

        /// <inheritdoc/>
        public void PickupItem(IItem item)
        {
            this.player.State = new PickupItemState(this.player, item);
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
            this.player.State = new UseItemState(this.player, waitTime);
        }

        /// <inheritdoc/>
        public void Update()
        {
            this.sprite.Update();
            if (this.sprite.CurrentFrame >= 2)
            {
                this.sprite.SetFrame(0);
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.Physics.Location, this.player.CurrentTint, this.player.Physics.Depth);
        }

        private ISprite CreateCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkMoveDown(this.player.CurrentColor);
        }
    }
}