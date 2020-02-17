using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class MoveUpState : IPlayerState
    {
        private LoZGame game;
        private IPlayer player;
        private ISprite sprite;

        public MoveUpState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = playerInstance;
            this.player.CurrentDirection = "Up";
            sprite = createCorrectSprite();
        }
        private ISprite createCorrectSprite()
        {
            return LinkSpriteFactory.Instance.createSpriteLinkMoveUp(player.CurrentColor);
        }
        public void idle()
        {
            player.State = new IdleState(game, player);
        }
        public void moveUp()
        {
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
            player.CurrentLocation = new Vector2(player.CurrentLocation.X, player.CurrentLocation.Y - player.CurrentSpeed);
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw(game.SpriteBatch, player.CurrentLocation, player.CurrentTint);
        }
    }
}
