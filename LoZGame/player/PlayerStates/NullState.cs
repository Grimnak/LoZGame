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

        public void idle()
        {
            this.player.State = new IdleState(this.game, this.player);
        }

        public void moveUp()
        {
            this.player.State = new MoveUpState(this.game, this.player);
        }

        public void moveDown()
        {
            this.player.State = new MoveDownState(this.game, this.player);
        }

        public void moveLeft()
        {
            this.player.State = new MoveLeftState(this.game, this.player);
        }

        public void moveRight()
        {
            this.player.State = new MoveRightState(this.game, this.player);
        }

        public void attack()
        {
            this.player.State = new AttackState(this.game, this.player);
        }

        public void die()
        {
            this.player.State = new DieState(this.game, this.player);
        }

        public void pickupItem(int itemTime)
        {
            this.player.State = new PickupItemState(this.game, this.player, itemTime);
        }

        public void useItem(int waitTime)
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