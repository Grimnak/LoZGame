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
        private readonly ItemManager item;
        private readonly BlockManager block;
        private readonly LoZGame game;
        private readonly EntityManager entity;
        private readonly EnemyManager enemy;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandReset"/> class.
        /// </summary>
        /// <param name="game">Game to execute a command on.</param>
        /// <param name="player">Player to execute a command on.</param>
        /// <param name="item">Item manager to execute a command on.</param>
        /// <param name="block">Block manager to execute a command on.</param>
        /// <param name="entity">Entity manager to execute a command on.</param>
        /// <param name="enemy">Enemy manager to execute a command on.</param>
        public CommandReset(LoZGame game, IPlayer player, ItemManager item, BlockManager block, EntityManager entity, EnemyManager enemy)
        {
            this.game = game;
            this.player = player;
            this.item = item;
            this.block = block;
            this.entity = entity;
            this.enemy = enemy;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.CurrentLocation = new Vector2(218, 184);
            this.player.CurrentDirection = "Down";
            this.player.State = new NullState(this.game, this.player);
            this.player.DamageCounter = 0;
            this.player.DamageTimer = 0;
            this.player.CurrentTint = Color.White;

            this.item.CurrentIndex = 1;
            this.item.CycleLeft();
            this.item.CurrentItem.Location = new Vector2(384, 184);

            this.enemy.Clear();

            this.entity.Clear();

            this.block.CurrentIndex = 1;
            this.block.CycleLeft();
        }
    }
}