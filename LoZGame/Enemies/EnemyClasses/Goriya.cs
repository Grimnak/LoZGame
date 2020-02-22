﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Goriya : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        private IEnemyState currentState;
        private int health = 10;
        private int coolDown;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        public Vector2 CurrentLocation;
        private string currentDirection = "Left";
        private readonly EntityManager entity;

        private enum StateEnum
        {
            Up,
            Down,
            Left,
            Right,
            Attacking,
        }

        private StateEnum state;

        public Goriya(EntityManager entity)
        {
            this.currentState = new LeftMovingGoriyaState(this);
            this.CurrentLocation = new Vector2(650, 200);
            this.entity = entity;
            this.coolDown = 0;
            this.Bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, 25, 30);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
        }

        private void GetNewState()
        {
            Random randomselect = new Random();
            this.state = (StateEnum)randomselect.Next(0, 5);
        }

        private void UpdateLoc()
        {
            switch (this.state)
            {
                case StateEnum.Up:
                    this.currentDirection = "Up";
                    this.currentState.MoveUp();
                    break;

                case StateEnum.Down:
                    this.currentDirection = "Down";
                    this.currentState.MoveDown();
                    break;

                case StateEnum.Left:
                    this.currentDirection = "Left";
                    this.currentState.MoveLeft();
                    break;

                case StateEnum.Right:
                    this.currentDirection = "Right";
                    this.currentState.MoveRight();
                    break;

                case StateEnum.Attacking:
                    this.currentState.Attack();
                    if (this.coolDown == 0)
                    {
                        this.coolDown = 240;
                        this.entity.EnemyProjectileManager.AddEnemyRang(this, this.currentDirection);
                    }

                    break;

                default:
                    break;
            }

            this.CheckBorder();
            this.currentState.Update();
        }

        private void CheckBorder()
        {
            if (this.CurrentLocation.Y < 30)
            {
                this.CurrentLocation = new Vector2(this.CurrentLocation.X, 30);
                this.lifeTime = this.directionChange + 1;
            }

            if (this.CurrentLocation.Y > 450)
            {
                this.CurrentLocation = new Vector2(this.CurrentLocation.X, 450);
                this.lifeTime = this.directionChange + 1;
            }

            if (this.CurrentLocation.X < 30)
            {
                this.CurrentLocation = new Vector2(30, this.CurrentLocation.Y);
                this.lifeTime = this.directionChange + 1;
            }

            if (this.CurrentLocation.X > 770)
            {
                this.CurrentLocation = new Vector2(770, this.CurrentLocation.Y);
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
            if (this.coolDown > 0)
            {
                this.coolDown--;
            }
            if (this.lifeTime > this.directionChange)
            {
                this.GetNewState();
                this.lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            this.currentState.Draw(sb);
        }

        public void OnCollisionResponse(ICollider otherCollider)
        {
            if (otherCollider is IProjectile)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider);
            }
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

        public string Direction
        {
            get { return this.currentDirection; }
            set { this.currentDirection = value; }
        }
    }
}