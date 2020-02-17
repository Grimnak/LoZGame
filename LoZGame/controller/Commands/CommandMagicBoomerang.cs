namespace LoZClone
{
    public class CommandMagicBoomerang : ICommand
    {
        readonly IPlayer player;
        readonly EntityManager entity;
        private static readonly int PriorityValue = 6;

        public CommandMagicBoomerang(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        public void execute()
        {
            if (!this.entity.ProjectileManager.BoomerangOut && !this.player.IsDead)
            {
                this.player.useItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.MagicBoomerang, this.player);
            }
        }

        public int Priority => PriorityValue;
    }
}