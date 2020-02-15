using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class MoveDownState : IPlayerState
    {
        private LoZGame game;
        private Link player;
        private ISprite sprite;

        public MoveDownState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            player = (Link)playerInstance;
            player.CurrentDirection = "Down";
            sprite = createCorrectSprite();
        }
        private ISprite createCorrectSprite()
        {
            return LinkSpriteFactory.Instance.createSpriteLinkMoveDown(player.CurrentColor);
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
            player.CurrentLocation = new Vector2(player.CurrentLocation.X, player.CurrentLocation.Y + player.CurrentSpeed);
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw(game.SpriteBatch, player.CurrentLocation, player.CurrentTint);
        }
    }
}
