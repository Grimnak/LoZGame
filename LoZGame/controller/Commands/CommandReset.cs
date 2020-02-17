namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class CommandReset : ICommand
    {
        readonly IPlayer player;
        readonly ItemManager item;
        readonly BlockManager block;
        readonly LoZGame game;
        readonly EntityManager entity;
        readonly EnemyManager enemy;
        private static readonly int priority = -1;

        public CommandReset(LoZGame game, IPlayer player, ItemManager item, BlockManager block, EntityManager entity, EnemyManager enemy)
        {
            this.game = game;
            this.player = player;
            this.item = item;
            this.block = block;
            this.entity = entity;
            this.enemy = enemy;
        }

        public void execute()
        {
            this.player.CurrentLocation = new Vector2(218, 184);
            this.player.CurrentDirection = "Down";
            this.player.State = new NullState(this.game, this.player);
            this.player.DamageCounter = 0;
            this.player.DamageTimer = 0;
            this.player.IsDead = false;
            this.player.CurrentTint = Color.White;

            this.item.CurrentIndex = 1;
            this.item.cycleLeft();
            this.item.currentItem.location = new Vector2(384, 184);

            this.entity.Clear();

            this.block.CurrentIndex = 1;
            this.block.cycleLeft();

            this.enemy.clear();
        }

        public int Priority => priority;
    }
}