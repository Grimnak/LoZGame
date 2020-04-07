namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    public class AttackingRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly ISprite sprite;
        private RandomStateGenerator randomStateGenerator;
        private List<IPlayer> players;

        public AttackingRopeState(Rope rope)
        {
            this.rope = rope;
            if (this.rope.MoveSpeed > 0)
            {
                this.sprite = EnemySpriteFactory.Instance.CreateRightMovingRopeSprite();
            }else
            {
                this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingRopeSprite();
            }
            this.rope.CurrentState = this;
            randomStateGenerator = new RandomStateGenerator(this.rope, 2, 6);
            this.rope.Attacking = true;
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
            this.rope.CurrentState = new DownMovingRopeState(this.rope);
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
            if (this.rope.Direction.Equals("horizontal"))
            {
                this.rope.Physics.Location = new Vector2(this.rope.Physics.Location.X + this.rope.MoveSpeed, this.rope.Physics.Location.Y);

            }
            else
            {
                this.rope.Physics.Location = new Vector2(this.rope.Physics.Location.X, this.rope.Physics.Location.Y + this.rope.MoveSpeed);
            }
            if (this.rope.Attacking == false)
            {
                this.randomStateGenerator.Update();
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.rope.Physics.Location, this.rope.CurrentTint, this.rope.Physics.Depth);
        }
    }
}