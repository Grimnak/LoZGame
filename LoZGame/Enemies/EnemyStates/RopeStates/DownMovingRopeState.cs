namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    public class DownMovingRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        private RandomStateGenerator randomStateGenerator;
        private List<IPlayer> players;

        public DownMovingRopeState(Rope rope)
        {
            this.rope = rope;
            this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingRopeSprite();
            this.rope.CurrentState = this;
            this.rope.Direction = "down";
            this.rope.MoveSpeed = 1;
            randomStateGenerator = new RandomStateGenerator(this.rope, 2, 6);
            this.rope.Physics.MovementVelocity = new Vector2(0, this.rope.MoveSpeed);
        }

        public void MoveLeft()
        {
            this.rope.CurrentState = new LeftMovingRopeState(this.rope);
        }

        public void MoveRight()
        {
            this.rope.CurrentState = new RightMovingRopeState(this.rope);
        }

        public void MoveUp()
        {
            this.rope.CurrentState = new UpMovingRopeState(this.rope);
        }

        public void MoveDown()
        {
        }

        public void MoveUpLeft()
        {
        }

        public void MoveUpRight()
        {
        }

        public void MoveDownLeft()
        {
        }

        public void MoveDownRight()
        {
        }

        public void Attack()
        {
            this.rope.CurrentState = new AttackingRopeState(this.rope);
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.rope.CurrentState = new DeadRopeState(this.rope);
        }

        public void Stun(int stunTime)
        {
            this.rope.CurrentState = new StunnedRopeState(this.rope, this, stunTime);
        }

        public void Update()
        {
            this.CheckForLink();
            this.lifeTime++;
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                this.lifeTime = 0;
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.rope.Physics.Location, this.rope.CurrentTint, this.rope.Physics.Depth);
        }

        private void CheckForLink()
        {
            int ropeX = (int)this.rope.Physics.Location.X;
            int ropeY = (int)this.rope.Physics.Location.Y;
            int linkX = (int)LoZGame.Instance.Link.Physics.Location.X;
            int linkY = (int)LoZGame.Instance.Link.Physics.Location.Y;

            if (ropeX == linkX)
            {
                this.rope.MoveSpeed = 3 * (linkY - ropeY) / Math.Abs(linkY - ropeY);
                this.rope.Direction = "vertical";
                this.rope.CurrentState.Attack();
            }
            else if (ropeY == linkY)
            {
                this.rope.MoveSpeed = 3 * (linkX - ropeX) / Math.Abs(linkX - ropeX);
                this.rope.Direction = "horizontal";
                this.rope.CurrentState.Attack();
            }
        }
    }
}