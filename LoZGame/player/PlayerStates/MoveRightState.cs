namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class MoveRightState : IPlayerState
    {
        private readonly LoZGame game;
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public MoveRightState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = playerInstance;
            this.player.CurrentDirection = "Right";
            this.sprite = this.createCorrectSprite();
        }

        private ISprite createCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkMoveRight(this.player.CurrentColor);
        }

        public void Idle()
        {
            this.player.State = new IdleState(this.game, this.player);
        }

        public void MoveUp()
        {
            this.player.State = new MoveUpState(this.game, this.player);
        }

        public void MoveDown()
        {
            this.player.State = new MoveDownState(this.game, this.player);
        }

        public void MoveLeft()
        {
            this.player.State = new MoveLeftState(this.game, this.player);
        }

        public void MoveRight()
        {
        }

        public void Attack()
        {
            this.player.State = new AttackState(this.game, this.player);
        }

        public void Die()
        {
            this.player.State = new DieState(this.game, this.player);
        }

        public void PickupItem(int itemTime)
        {
            this.player.State = new PickupItemState(this.game, this.player, itemTime);
        }

        public void UseItem(int waitTime)
        {
            this.player.State = new UseItemState(this.game, this.player, waitTime);
        }

        public void Update()
        {
            this.player.CurrentLocation = new Vector2(this.player.CurrentLocation.X + this.player.CurrentSpeed, this.player.CurrentLocation.Y);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.game.SpriteBatch, this.player.CurrentLocation, this.player.CurrentTint);
        }
    }
}
