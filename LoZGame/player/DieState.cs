using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DieState : IPlayerState
    {
        private LoZGame game;
        private Link player;
        private ISprite sprite;

        public DieState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            player = (Link)playerInstance;
            sprite = createCorrectSprite();
        }
        private ISprite createCorrectSprite()
        {
            return LinkSpriteFactory.Instance.createSpriteLinkAttackUp(player.CurrentColor);
        }
        public void idle()
        {
        }
        public void moveUp()
        {
        }
        public void moveDown()
        {
        }
        public void moveLeft()
        {
        }
        public void moveRight()
        {
        }
        public void attack()
        {
        }
        public void die()
        {
        }
        public void Update()
        {
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw(game.SpriteBatch, player.CurrentLocation, player.CurrentTint);
        }
    }
}
