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

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandReset"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandReset(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.CurrentLocation = new Vector2(218, 184);
            this.player.CurrentDirection = "Down";
            this.player.State = new NullState(LoZGame.Instance, this.player);
            this.player.DamageCounter = 0;
            this.player.DamageTimer = 0;
            this.player.CurrentTint = Color.White;

            ItemManager.Instance.CurrentIndex = 1;
            ItemManager.Instance.CycleLeft();
            ItemManager.Instance.CurrentItem.Location = new Vector2(384, 184);

            EnemyManager.Instance.Clear();

            EntityManager.Instance.Clear();

            BlockManager.Instance.CurrentIndex = 1;
            BlockManager.Instance.CycleLeft();
        }
    }
}