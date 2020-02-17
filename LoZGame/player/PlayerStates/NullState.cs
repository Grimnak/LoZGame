namespace LoZClone
{
    public class NullState : IPlayerState
    {
        private readonly LoZGame game;
        private readonly IPlayer player;

        public NullState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = playerInstance;
        }

        public void Idle()
        {
            this.player.State = new IdleState(this.game, this.player);
        }

        public void MoveUp()
        {
            this.player.State = new MoveUpState(this.game, this.player);
        }

        public void MoveDown()
        {
            this.player.State = new MoveDownState(this.game, this.player);
        }

        public void MoveLeft()
        {
            this.player.State = new MoveLeftState(this.game, this.player);
        }

        public void MoveRight()
        {
            this.player.State = new MoveRightState(this.game, this.player);
        }

        public void Attack()
        {
            this.player.State = new AttackState(this.game, this.player);
        }

        public void Die()
        {
            this.player.State = new DieState(this.game, this.player);
        }

        public void PickupItem(int itemTime)
        {
            this.player.State = new PickupItemState(this.game, this.player, itemTime);
        }

        public void UseItem(int waitTime)
        {
            this.player.State = new UseItemState(this.game, this.player, waitTime);
        }

        public void Update()
        {
        }

        public void Draw()
        {
        }
    }
}