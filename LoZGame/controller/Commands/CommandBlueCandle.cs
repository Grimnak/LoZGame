namespace LoZClone
{
    public class CommandBlueCandle : ICommand
    {
        readonly IPlayer player;
        readonly EntityManager entity;
        private static readonly int PriorityValue = 6;

        public CommandBlueCandle(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        public void execute()
        {
            if (!this.entity.ProjectileManager.FlameInUse && !this.player.IsDead)
            {
                this.player.useItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.BlueCandle, this.player);
            }
        }

        public int Priority => PriorityValue;
    }
}