namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    public class LeftMovingRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        private RandomStateGenerator randomStateGenerator;
        private List<IPlayer> players;

        public LeftMovingRopeState(Rope rope)
        {
            this.rope = rope;
            this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingRopeSprite();
            this.rope.CurrentState = this;
            randomStateGenerator = new RandomStateGenerator(this.rope, 2, 6);
        }

        public void MoveLeft()
        {
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
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.rope.CurrentState = new DeadRopeState(this.rope);
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                this.lifeTime = 0;
            }
            this.rope.Physics.Location = new Vector2(this.rope.Physics.Location.X - this.rope.MoveSpeed, this.rope.Physics.Location.Y);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.rope.Physics.Location, this.rope.CurrentTint);
        }

        private void CheckForLink()
        { /*
            players = Game.Players;
            foreach (IPlayer player in players)
            {
                if (CurrentLocation.X <= player.CurrentLocation.X + 10 || CurrentLocation.X >= player.CurrentLocation.X - 10)
                {
                    Attacking = true;
                    AttackFactor = 3;
                    if (CurrentLocation.Y > player.CurrentLocation.Y)
                    {
                        this.currentState.MoveDown();
                    }
                    else
                    {
                        this.currentState.MoveUp();
                    }
                }
                else if (CurrentLocation.Y == player.CurrentLocation.Y)
                {
                    Attacking = true;
                    AttackFactor = 3;
                    if (CurrentLocation.Y <= player.CurrentLocation.Y + 10 || CurrentLocation.Y >= player.CurrentLocation.Y - 10)
                    {
                        this.currentState.MoveRight();
                    }
                    else
                    {
                        this.currentState.MoveLeft();
                    }
                }
                else
                {
                    AttackFactor = 1;
                    Attacking = false;
                }
                this.currentState.Update();
            }
                */
        }
    }
}