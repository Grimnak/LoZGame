namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class MoveDownState : IPlayerState
    {
        private readonly LoZGame game;
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public MoveDownState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = playerInstance;
            this.player.CurrentDirection = "Down";
            this.sprite = this.createCorrectSprite();
        }

        private ISprite createCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkMoveDown(this.player.CurrentColor);
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
            this.player.CurrentLocation = new Vector2(this.player.CurrentLocation.X, this.player.CurrentLocation.Y + this.player.CurrentSpeed);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.game.SpriteBatch, this.player.CurrentLocation, this.player.CurrentTint);
        }
    }
}
