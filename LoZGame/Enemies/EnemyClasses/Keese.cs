namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Keese : IEnemy
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

        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private readonly int directionChange = 40;

        private enum direction
        {
            Up,
            Down,
            Left,
            Right,
            UpLeft,
            UpRight,
            DownLeft,
            DownRight
        }
;

        private direction currentDirection;

        public Keese(LoZGame game)
        {
            this.Game = game;
            this.currentState = new LeftMovingKeeseState(this);
            this.CurrentLocation = new Vector2(650, 200);
            this.Bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, 20, 20);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (direction)randomselect.Next(0, 7);
        }

        private void updateLoc()
        {
            switch (this.currentDirection)
            {
                case direction.Up:
                    this.currentState.MoveUp();
                    break;

                case direction.Down:
                    this.currentState.MoveDown();
                    break;

                case direction.Left:
                    this.currentState.MoveLeft();
                    break;

                case direction.Right:
                    this.currentState.MoveRight();
                    break;

                case direction.UpLeft:
                    this.currentState.MoveUpLeft();
                    break;

                case direction.UpRight:
                    this.currentState.MoveUpRight();
                    break;

                case direction.DownLeft:
                    this.currentState.MoveDownLeft();
                    break;

                case direction.DownRight:
                    this.currentState.MoveDownRight();
                    break;

                default:
                    break;
            }
            this.currentState.Update();
        }

        public void TakeDamage()
        {
            this.currentState.TakeDamage();
        }

        public void Die()
        {
            this.currentState.Die();
        }

        /* public void Update()
         {
             currentState.Update();
         } */

        public void Update()
        {
            this.lifeTime++;
            this.updateLoc();
            if (this.lifeTime > this.directionChange)
            {
                this.getNewDirection();
                this.lifeTime = 0;
            }
            this.bounds.X = (int)this.CurrentLocation.X;
            this.bounds.Y = (int)this.CurrentLocation.Y;
        }

        /* if (lifeTime % frameChange == 0)
         {
             this.nextFrame();
         }
     } */

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