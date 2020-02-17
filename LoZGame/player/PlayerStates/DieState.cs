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
            return LinkSpriteFactory.Instance.CreateSpriteLinkDie(this.player.CurrentColor);
        }

        public void Idle()
        {
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void Attack()
        {
        }

        public void Die()
        {
        }

        public void PickupItem(int itemTime)
        {
        }

        public void UseItem(int waitTime)
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