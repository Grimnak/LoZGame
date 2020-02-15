namespace LoZClone
{
    public class NullState : IPlayerState
    {
        private LoZGame game;
        private Link player;

        public NullState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = (Link)playerInstance;
        }
        public void idle()
        {
            player.State = new IdleState(game, player);
        }
        public void moveUp()
        {
            player.State = new MoveUpState(game, player);
        }
        public void moveDown()
        {
            player.State = new MoveDownState(game, player);
        }
        public void moveLeft()
        {
            player.State = new MoveLeftState(game, player);
        }
        public void moveRight()
        {
            player.State = new MoveRightState(game, player);
        }
        public void attack()
        {
            player.State = new AttackState(game, player);
        }
        public void die()
        {
            player.State = new DieState(game, player);
        }
        public void pickupItem()
        {
            player.State = new PickupItemState(game, player);
        }
        public void useItem()
        {
            player.State = new UseItemState(game, player);
        }
        public void Update()
        {
        }
        public void Draw()
        {
        }
    }
}