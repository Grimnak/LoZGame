namespace LoZClone
{
    public class CommandBomb : ICommand
    {
        readonly IPlayer player;
        readonly EntityManager entity;
        private static readonly int priority = 5;

        public CommandBomb(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        public void execute()
        {
            if (!this.player.IsDead)
            {
                this.player.useItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.Bomb, this.player);
            }
        }

        public int Priority => priority;
    }
}