namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class MoveLeftState : IPlayerState
    {
        private readonly LoZGame game;
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public MoveLeftState(LoZGame gameInstance, IPlayer playerInstance)
        {
            this.game = gameInstance;
            this.player = playerInstance;
            this.player.CurrentDirection = "Left";
            this.sprite = this.createCorrectSprite();
        }

        private ISprite createCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkMoveLeft(this.player.CurrentColor);
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
            this.player.CurrentLocation = new Vector2(this.player.CurrentLocation.X - this.player.CurrentSpeed, this.player.CurrentLocation.Y);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.game.SpriteBatch, this.player.CurrentLocation, this.player.CurrentTint);
        }
    }
}
