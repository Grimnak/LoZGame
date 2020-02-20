namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Link : PlayerEssentials, IPlayer
    {
        public Link(LoZGame game)
        {
            this.Game = game;
            this.CurrentColor = "Green";
            this.CurrentDirection = "Down";
            this.CurrentWeapon = "Wood";
            this.CurrentLocation = new Vector2(150, 200);
            this.CurrentTint = Color.White;
            this.CurrentSpeed = 2;
            this.DamageTimer = 0;
            this.DamageCounter = 0;
            this.IsDead = false;

            this.State = new NullState(game, this);
        }

        public override void Idle()
        {
            this.State.Idle();
        }

        public override void MoveUp()
        {
            this.State.MoveUp();
        }

        public override void MoveDown()
        {
            this.State.MoveDown();
        }

        public override void MoveLeft()
        {
            this.State.MoveLeft();
        }

        public override void MoveRight()
        {
            this.State.MoveRight();
        }

        public override void Attack()
        {
            this.State.Attack();
        }

        public override void PickupItem(int itemTime)
        {
            this.State.PickupItem(itemTime);
        }

        public override void UseItem(int waitTime)
        {
            this.State.UseItem(waitTime);
        }
    }
}