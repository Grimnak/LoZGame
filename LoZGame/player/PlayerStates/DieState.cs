namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class DieState : IPlayerState
    {
        private readonly LoZGame game;
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public DieState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = playerInstance;
            this.player.IsDead = true;
            this.sprite = this.createCorrectSprite();
        }

        private ISprite createCorrectSprite()
        {
            return LinkSpriteFactory.Instance.createSpriteLinkDie(this.player.CurrentColor);
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

        public void pickupItem(int itemTime)
        {
        }

        public void useItem(int waitTime)
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.game.SpriteBatch, this.player.CurrentLocation, this.player.CurrentTint);
        }
    }
}