namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Command that makes the game reset to a default state.
    /// </summary>
    public class CommandReset : ICommand
    {
        private readonly IPlayer player;
        private Profiles profile;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandReset"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        /// <param name="dungeon">Dungeon to execute a command on.</param>
        public CommandReset(IPlayer player)
        {
            this.player = player;
            profile = new Profiles();
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

            profile.ResetSaveFile();

            InventoryComponents.Instance.Reset();
            LoZGame.Instance.GameState.TitleScreen();
        }
    }
}