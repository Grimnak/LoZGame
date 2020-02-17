namespace LoZClone
{
    public class CommandAttackB : ICommand
    {
        readonly IPlayer player;
        readonly EntityManager entity;
        private static readonly int priority = 7;

        public CommandAttackB(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        public void execute()
        {
            if (!this.player.IsDead)
            {
                this.player.attack();
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.Swordbeam, this.player);
            }
        }

        public int Priority => priority;
    }
}