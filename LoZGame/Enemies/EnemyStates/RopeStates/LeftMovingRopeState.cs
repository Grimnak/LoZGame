namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    public class LeftMovingRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private int directionChange;
        private RandomStateGenerator randomStateGenerator;
        private List<IPlayer> players;

        public LeftMovingRopeState(Rope rope)
        {
            this.rope = rope;
            this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingRopeSprite();
            this.rope.CurrentState = this;
            this.rope.Physics.CurrentDirection = Physics.Direction.West;
            this.rope.MoveSpeed = GameData.Instance.EnemySpeedData.RopeSpeed;
            this.directionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            randomStateGenerator = new RandomStateGenerator(this.rope, 2, 6);
            this.rope.Physics.MovementVelocity = new Vector2(-1 * this.rope.MoveSpeed, 0);
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

            if (Math.Abs(ropeX - linkX) <= GameData.Instance.EnemyMiscData.RopeLinkPixelBuffer)
            {
                if ((linkY - ropeY) > 0)
                {
                    this.rope.Physics.CurrentDirection = Physics.Direction.South;
                    this.rope.MoveSpeed = GameData.Instance.EnemySpeedData.RopeAttackSpeed;
                }
                else
                {
                    this.rope.Physics.CurrentDirection = Physics.Direction.North;
                    this.rope.MoveSpeed = GameData.Instance.EnemySpeedData.RopeAttackSpeed * -1;
                }
                this.rope.CurrentState.Attack();
            }
            else if (Math.Abs(ropeY - linkY) <= GameData.Instance.EnemyMiscData.RopeLinkPixelBuffer)
            {
                if ((linkX - ropeX) > 0)
                {
                    this.rope.Physics.CurrentDirection = Physics.Direction.East;
                    this.rope.MoveSpeed = GameData.Instance.EnemySpeedData.RopeAttackSpeed;
                }
                else
                {
                    this.rope.Physics.CurrentDirection = Physics.Direction.West;
                    this.rope.MoveSpeed = GameData.Instance.EnemySpeedData.RopeAttackSpeed * -1;
                }
                this.rope.CurrentState.Attack();
            }
        }
    }
}