namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Command that makes the game reset to a default state.
    /// </summary>
    public class CommandReset : ICommand
    {
        private readonly IPlayer player;
        private readonly Dungeon dungeon;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandReset"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        /// <param name="dungeon">Dungeon to execute a command on.</param>
        public CommandReset(IPlayer player, Dungeon dungeon)
        {
            this.player = player;
            this.dungeon = dungeon;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.Physics.Bounds = new Rectangle(
                    (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 6),
                    this.player.Physics.Bounds.Width, 
                    this.player.Physics.Bounds.Height);
            this.player.Physics.SetLocation();
            this.player.CurrentDirection = "Up";
            this.player.State = new IdleState(this.player);
            this.player.Health.ResetHealth();
            this.player.DamageTimer = 0;
            this.player.CurrentTint = Color.White;

            LoZGame.Instance.GameState = "Default";

            this.dungeon.Reset();
        }
    }
}