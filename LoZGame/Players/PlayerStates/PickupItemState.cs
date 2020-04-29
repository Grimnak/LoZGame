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
            player = playerInstance;
            this.item = item;
            lockoutTimer = item.PickUpItemTime;
            sprite = CreateCorrectSprite();
            player.Physics.MovementVelocity = Vector2.Zero;
            if (item is Triforce)
            {
                sprite.SetFrame(GameData.Instance.PlayerConstants.MaximumFrames);
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
            else if (item is Arrow)
            {
                player.Inventory.HasArrow = true;
            }
            else if (item is SilverArrow)
            {
                player.Inventory.HasSilverArrow = true;
            }
            else if (item is MagicRod)
            {
                player.Inventory.HasRod = true;
            }
            else if (item is Boomerang)
            {
                player.Inventory.HasBoomerang = true;
            }
            else if (item is MagicBoomerang)
            {
                player.Inventory.HasMagicBoomerang = true;
            }
            else if (item is RedCandle)
            {
                player.Inventory.HasRedFlame = true;
            }
            else if (item is BlueCandle)
            {
                player.Inventory.HasBlueFlame = true;
            }
            else if (item is Map)
            {
                player.Inventory.HasMap = true;
            }
            else if (item is Compass)
            {
                player.Inventory.HasCompass = true;
            }
            else if (item is Ladder)
            {
                player.Inventory.HasLadder = true;
            }
            else if (item is Flute)
            {
                player.Inventory.HasFlute = true;
            }
        }

        /// <inheritdoc/>
        public void Idle()
        {
            if (lockoutTimer <= 0)
            {
                player.Physics.CurrentDirection = Physics.Direction.South;
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
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
            if (lockoutTimer <= 0)
            {
                player.State = new UseItemState(player, waitTime);
            }
        }

        /// <inheritdoc/>
        public void Stun(int stunTime)
        {
            if (lockoutTimer <= 0)
            {
                player.State = new StunnedState(player, player.State, stunTime);
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
            if (item is Triforce)
            {
                if (sprite.CurrentFrame == 0)
                {
                    sprite.NextFrame();
                }
            }
            if (lockoutTimer > 0)
            {
                lockoutTimer--;
                if (lockoutTimer == 0)
                {
                    item.Expired = true;
                }
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            sprite.Draw(player.Physics.Location, player.CurrentTint, player.Physics.Depth);
        }

        private ISprite CreateCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkPickupItem(player.CurrentColor);
        }
    }
}