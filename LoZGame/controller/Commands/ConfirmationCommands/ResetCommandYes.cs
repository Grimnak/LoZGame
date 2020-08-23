namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Command that confirms the resetting of the game.
    /// </summary>
    public class ResetCommandYes : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResetCommandYes"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public ResetCommandYes(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            player.Physics.Bounds = new Rectangle(
                    (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 6),
                    player.Physics.Bounds.Width,
                    player.Physics.Bounds.Height);
            player.Physics.SetLocation();
            player.Physics.CurrentDirection = Physics.Direction.North;
            player.State = new IdleState(player);
            player.DamageTimer = 0;
            player.CurrentTint = Color.White;

            LoZGame.Instance.Profiles.ResetSaveFile();

            InventoryComponents.Instance.Reset();
            LoZGame.Instance.GameState.TitleScreen();
        }
    }
}