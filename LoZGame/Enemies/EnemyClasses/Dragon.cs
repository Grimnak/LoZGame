namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Dragon : IEnemy
    {
        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        private readonly EntityManager entity;
        private Vector2 currentLocation;

        public EntityManager EntityManager { get { return this.entity; } }

        private enum StateEnum
        {
            Idle,
            Left,
            Right,
            Attacking,
        }

        private StateEnum currentStateEnum;

        public Dragon(EntityManager entity)
        {
            this.entity = entity;
            this.currentState = new LeftMovingDragonState(this);
            this.CurrentLocation = new Vector2(650, 200);
        }

        private void GetNewDirection()
        {
            Random randomselect = new Random();
            this.currentStateEnum = (StateEnum)randomselect.Next(0, 5);
        }

        private void UpdateLoc()
        {
            switch (this.currentStateEnum)
            {
                case StateEnum.Attacking:
                    this.currentState.Attack();
                    break;

                case StateEnum.Idle:
                    this.currentState.Stop();
                    break;

                case StateEnum.Left:
                    this.currentState.MoveLeft();
                    break;

                case StateEnum.Right:
                    this.currentState.MoveRight();
                    break;

                default:
                    break;
            }

            this.CheckBorder();
            this.currentState.Update();
        }

        private void CheckBorder()
        {
            if (this.CurrentLocation.Y < 0)
            {
                this.CurrentLocation = new Vector2(this.CurrentLocation.X, 0);
                this.lifeTime = this.directionChange + 1;
            }

            if (this.CurrentLocation.Y > 430)
            {
                this.CurrentLocation = new Vector2(this.CurrentLocation.X, 430);
                this.lifeTime = this.directionChange + 1;
            }

            if (this.CurrentLocation.X < 0)
            {
                this.CurrentLocation = new Vector2(0, this.CurrentLocation.Y);
                this.lifeTime = this.directionChange + 1;
            }

            if (this.CurrentLocation.X > 750)
            {
                this.CurrentLocation = new Vector2(750, this.CurrentLocation.Y);
                this.lifeTime = this.directionChange + 1;
            }
        }

        public void TakeDamage()
        {
            this.currentState.TakeDamage();
        }

        public void Die()
        {
            this.currentState.Die();
        }

        public void Update()
        {
            this.lifeTime++;
            this.UpdateLoc();
            if (this.lifeTime > this.directionChange)
            {
                this.GetNewDirection();
                this.lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            this.currentState.Draw(sb);
        }

        public IEnemyState CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }
        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        public Vector2 CurrentLocation { get => this.currentLocation; set => this.currentLocation = value; }
    }
}