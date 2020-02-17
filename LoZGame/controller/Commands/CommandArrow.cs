namespace LoZClone
{
    public class CommandArrow : ICommand
    {
        private readonly IPlayer player;
        private readonly EntityManager entity;
        private static readonly int PriorityValue = 5;

        public CommandArrow(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        public void execute()
        {
            if (!this.player.IsDead)
            {
                this.player.useItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.Arrow, this.player);
            }
        }

        public int Priority => PriorityValue;
    }
}