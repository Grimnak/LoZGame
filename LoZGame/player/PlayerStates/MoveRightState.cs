using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class MoveRightState : IPlayerState
    {
        private LoZGame game;
        private IPlayer player;
        private ISprite sprite;

        public MoveRightState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = playerInstance;
            this.player.CurrentDirection = "Right";
            sprite = createCorrectSprite();
        }
        private ISprite createCorrectSprite()
        {
            return LinkSpriteFactory.Instance.createSpriteLinkMoveRight(player.CurrentColor);
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
        }
        public void attack()
        {
            player.State = new AttackState(game, player);
        }
        public void die()
        {
            player.State = new DieState(game, player);
        }
        public void pickupItem(int itemTime)
        {
            player.State = new PickupItemState(game, player, itemTime);
        }
        public void useItem(int waitTime)
        {
            player.State = new UseItemState(game, player, waitTime);
        }
        public void Update()
        {
            player.CurrentLocation = new Vector2(player.CurrentLocation.X + player.CurrentSpeed, player.CurrentLocation.Y);
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw(game.SpriteBatch, player.CurrentLocation, player.CurrentTint);
        }
    }
}
