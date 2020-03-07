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
            this.player.Physics.Location = new Vector2(
                    (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    (float)(BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 6)));
            this.player.CurrentDirection = "Up";
            this.player.State = new IdleState(this.player);
            this.player.Health = new HealthManager(4);
            this.player.DamageTimer = 0;
            this.player.CurrentTint = Color.White;

            LoZGame.Instance.GameState = "Default";

            this.dungeon.Reset();
        }
    }
}