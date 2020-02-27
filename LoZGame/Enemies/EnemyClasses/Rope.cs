namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Rope : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public LoZGame Game
        {
            get; set;
        }

        public Vector2 CurrentLocation
        {
            get; set;
        }
        public int VelocityX
        {
            get; set;
        }

        public int VelocityY
        {
            get; set;
        }

        public Boolean Attacking
        {
            get; set;
        }

        public int AttackFactor
        {
            get; set;
        }

        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        private List<IPlayer> players;

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }

        private Direction currentDirection;

        public Rope(Vector2 location)
        {
            this.Game = LoZGame.Instance;
            this.currentState = new LeftMovingRopeState(this);
            this.CurrentLocation = new Vector2(location.X, location.Y);
            this.Bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, 25, 25);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
            Attacking = false;
            AttackFactor = 1;
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (Direction)randomselect.Next(0, 3);
        }

        private void updateLoc()
        {
            switch (this.currentDirection)
            {
                case Direction.Up:
                    this.currentState.MoveUp();
                    break;

                case Direction.Down:
                    this.currentState.MoveDown();
                    break;

                case Direction.Left:
                    this.currentState.MoveLeft();
                    break;

                case Direction.Right:
                    this.currentState.MoveRight();
                    break;

                default:
                    break;
            }
            this.currentState.Update();
        }

        private void checkForLink()
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
        
        public void TakeDamage()
        {
            this.currentState.Die();
        }

        public void Die()
        {
            this.currentState.Die();
        }

        public void Update()
        {
            this.lifeTime++;
            checkForLink();
            if (!Attacking)
            {
                this.updateLoc();
                if (this.lifeTime > this.directionChange)
                {
                    this.getNewDirection();
                    this.lifeTime = 0;
                }
            }

            this.bounds.X = (int)this.CurrentLocation.X;
            this.bounds.Y = (int)this.CurrentLocation.Y;
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
    }
}
