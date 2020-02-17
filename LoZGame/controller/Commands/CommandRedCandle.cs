namespace LoZClone
{
    public class CommandRedCandle : ICommand
    {
        readonly IPlayer player;
        readonly EntityManager entity;
        private static readonly int priority = 5;

        public CommandRedCandle(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        public void execute()
        {
            if (!this.player.IsDead)
            {
                this.player.useItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.RedCandle, this.player);
            }
        }

        public int Priority => priority;
    }
}