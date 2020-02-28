namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Command that makes the game reset to a default state.
    /// </summary>
    public class CommandReset : ICommand
    {
        private static readonly int PriorityValue = -1;
        private readonly IPlayer player;
        private readonly Dungeon dungeon;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandReset"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandReset(IPlayer player, Dungeon dungeon)
        {
            this.player = player;
            this.dungeon = dungeon;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.CurrentLocation = new Vector2(218, 184);
            this.player.CurrentDirection = "Down";
            this.player.State = new NullState(this.player);
            this.player.DamageCounter = 0;
            this.player.DamageTimer = 0;
            this.player.CurrentTint = Color.White;

            LoZGame.Instance.Items.CurrentIndex = 1;
            LoZGame.Instance.Items.CycleLeft();
            LoZGame.Instance.Items.CurrentItem.Location = new Vector2(384, 184);

            this.dungeon.Reset();
        }
    }
}